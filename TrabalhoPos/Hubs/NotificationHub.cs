﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TrabalhoPos.Hubs
{
    public class NotificationHub : Hub
    {
        public void Mensagem(string msg)
        {
            Clients.All.mensagem(msg);
        }
    }
}