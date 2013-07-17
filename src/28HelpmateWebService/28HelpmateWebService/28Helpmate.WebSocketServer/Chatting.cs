using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSocket.WebSocket.Server;

namespace _28Helpmate.WebSocketServer
{
    public class Chatting:IWebSocketHandler
    {
        public WebSocketResponse Analyze(WebSocketRequest request,WebSocketResponse response)
        {
            response.Data = request.Body;
            return response;
        }
    }
}