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
            response.Data = "Welcome!";
            response.RemoteHandler = string.Format(@"alert('{0}')","Welcome!");
            session.Send(new JavaScriptSerializer().Serialize(response));
        }
    }
}