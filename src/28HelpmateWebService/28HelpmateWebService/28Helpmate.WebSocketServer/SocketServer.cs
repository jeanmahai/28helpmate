using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WebSocket.WebSocket.Server;

namespace _28Helpmate.WebSocketServer
{
    public class SocketServer:SupperWebSocketServerBase
    {
        protected override void OnNewSessionConnected(SuperWebSocket.WebSocketSession session)
        {
            var response = new WebSocketResponse();
            response.RemoteHandler = string.Format(@"appendMsg('{0}')","有新用户进入!");
            string json = new JavaScriptSerializer().Serialize(response);

            foreach (var s in Sessions)
            {
                s.Send(json);
            }
        }

        protected override void OnSessionClosed(SuperWebSocket.WebSocketSession session,SuperSocket.SocketBase.CloseReason value)
        {
            var response = new WebSocketResponse();
            response.RemoteHandler = string.Format(@"appendMsg('{0}')","用户退出!");
            string json = new JavaScriptSerializer().Serialize(response);

            foreach (var s in Sessions)
            {
                s.Send(json);
            }
        }
    }
}