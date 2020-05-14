using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieApp.Data
{
    public interface INetworkConnection
    {
        bool isConnected { get; }
        void CheckNetworkConnection();
    }
}
