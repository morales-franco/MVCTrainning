using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TestSite.Hubs
{
    public class TestHub : Hub
    {
        public TestHub()
        {
            //Example - send data in real time
            SendCoordinates();
        }

        private void SendCoordinates()
        {
            var task = Task.Factory.StartNew(async () =>
            {
               
                var coordinate = 0;
                while (true)
                {
                    if (coordinate > 100)
                        coordinate = 0;

                    Clients.All.newCoordinate(coordinate);
                    await Task.Delay(10);
                    coordinate = coordinate + 1;
                }
            }, TaskCreationOptions.LongRunning);


            

        }

        public void Hello()
        {
            //Send Hello to every JS Client
            Clients.All.hello();
        }

        //Send() is invoked from JS Client
        //SignalR generate a JS Proxy (TestHub Proxy) and all clients can call this proxy.
        //This proxy has all Methods declared here
        public void Send(string message)
        {
            //Hub invoke at newMessage() --> newMessage is a JS Method in the client
            Clients.All.newMessage(string.Format("Someone Says: {0}", message));
        }
    }
}