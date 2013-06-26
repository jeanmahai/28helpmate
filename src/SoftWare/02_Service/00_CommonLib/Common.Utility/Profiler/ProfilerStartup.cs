using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;

namespace Common.Utility
{
    public class ProfilerStartup : IStartup, IShutdown
    {
        private string m_ConnStr;
        private string m_DatabaseStr;
        private string m_CollectionStr;

        public ProfilerStartup()
        {
            m_ConnStr = ProfilerConfig.GetValue("connectionString");
            if (m_ConnStr == null || m_ConnStr.Trim().Length <= 0)
            {
                m_ConnStr = null;
            }
            m_DatabaseStr = ProfilerConfig.GetValue("database");
            if (m_DatabaseStr == null || m_DatabaseStr.Trim().Length <= 0)
            {
                m_DatabaseStr = null;
            }
            m_CollectionStr = ProfilerConfig.GetValue("collection");
            if (m_CollectionStr == null || m_CollectionStr.Trim().Length <= 0)
            {
                m_CollectionStr = null;
            }
        }

        public void Start()
        {
            ProfilerManager.ExceptionHandler = ex =>
            {
                ExceptionHelper.HandleException(ex);
            };
            ProfilerManager.QueueItemHandler = list =>
            {
                if (m_ConnStr == null || m_DatabaseStr == null || m_CollectionStr == null)
                {
                    return;
                }
                var client = new MongoClient(m_ConnStr);
                var database = client.GetServer().GetDatabase(m_DatabaseStr);
                var collection = database.GetCollection(m_CollectionStr);
                collection.InsertBatch<ProfilerMessage>(list, WriteConcern.Unacknowledged);
            };
        }

        public void Shut()
        {
            ProfilerManager.StopDequeue();
        }
    }
}
