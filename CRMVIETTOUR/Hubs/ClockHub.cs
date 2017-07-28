using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMVIETTOUR.Hubs
{
    public class ClockHub : Hub
    {
        public void getTime()
        {
            Clients.Caller.setTime(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
        }

        public void getTimeVisa()
        {
            Clients.Caller.setTimeVisa(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
        }
    }
}