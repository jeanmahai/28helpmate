using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Common.Utility
{
    public static class EventPublisher
    {
        public static void Publish<T>(T eventMessage) where T : IEventMessage
        {
            var subscriptions = Subscription<T>.GetSubscribers();
            subscriptions.ForEach(x => PublishToConsumer(x, eventMessage));
        }

        private static void PublishToConsumer<T>(IConsumer<T> x, T eventMessage) where T : IEventMessage
        {
            if (x.ExecuteMode == ExecuteMode.Sync ||
                (x.ExecuteMode == ExecuteMode.AccordingToTransaction && Transaction.Current != null))
                // 同步执行
            {
                x.HandleEvent(eventMessage);
            }
            else // 异步执行
            {
                Action<T> act = new Action<T>(x.HandleEvent);
                act.BeginInvoke(eventMessage, ar =>
                {
                    Action<T> tmp = ar.AsyncState as Action<T>;
                    if (tmp != null)
                    {
                        tmp.EndInvoke(ar);
                    }
                }, act);
            }
        }
    }
}
