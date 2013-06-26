using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Transactions;

namespace Common.Utility.DataAccess.DbProvider
{
    internal static class TransactionScopeConnections
    {
        private static Dictionary<Transaction, Dictionary<string, DbConnection>> transactionConnections = new Dictionary<Transaction, Dictionary<string, DbConnection>>();

        /// <summary>
        ///		Returns a connection for the current transaction. This will be an existing <see cref="DbConnection"/>
        ///		instance or a new one if there is a <see cref="TransactionScope"/> active. Otherwise this method
        ///		returns null.
        /// </summary>
        /// <param name="db"></param>
        /// <returns>Either a <see cref="DbConnection"/> instance or null.</returns>
        public static DbConnection GetConnection(string connectionString, IDbFactory dbFactory)
        {
            Transaction currentTransaction = Transaction.Current;

            if (currentTransaction == null)
            {
                return null;
            }

            Dictionary<string, DbConnection> connectionList;
            transactionConnections.TryGetValue(currentTransaction, out connectionList);

            DbConnection connection;
            if (connectionList != null)
            {
                connectionList.TryGetValue(connectionString, out connection);
                if (connection != null)
                {
                    return connection;
                }
            }
            else
            {									// We don't have a list for this transaction, so create a new one
                connectionList = new Dictionary<string, DbConnection>();
                lock (transactionConnections)
                {
                    transactionConnections.Add(currentTransaction, connectionList);
                }
            }

            //
            // Next we'll see if there is already a connection. If not, we'll create a new connection and add it
            // to the transaction's list of connections.
            //
            if (connectionList.ContainsKey(connectionString))
            {
                connection = connectionList[connectionString];
            }
            else
            {
                connection = dbFactory.CreateConnection(connectionString);
                connection.Open();
                currentTransaction.TransactionCompleted += new TransactionCompletedEventHandler(OnTransactionCompleted);
                connectionList.Add(connectionString, connection);
            }

            return connection;
        }

        /// <summary>
        ///		This event handler is called whenever a transaction is about to be disposed, which allows
        ///		us to remove the transaction from our list and dispose the connection instance we created.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnTransactionCompleted(object sender, TransactionEventArgs e)
        {
            Dictionary<string, DbConnection> connectionList; // = connections[e.Transaction];

            transactionConnections.TryGetValue(e.Transaction, out connectionList);
            if (connectionList == null)
            {
                return;
            }

            lock (transactionConnections)
            {
                transactionConnections.Remove(e.Transaction);
            }

            foreach (DbConnection conneciton in connectionList.Values)
            {
                try
                {
                    conneciton.Dispose();
                }
                catch { }
            }
        }
    }
}
