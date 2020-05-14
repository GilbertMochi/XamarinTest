using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreFoundation;
using Foundation;
using SmoothieApp.Data;
using SmoothieApp.iOS.Data;
using SystemConfiguration;
using UIKit;


[assembly:Xamarin.Forms.Dependency(typeof(NetworkConnection))]
namespace SmoothieApp.iOS.Data
{
    public class NetworkConnection : INetworkConnection
    {
        private NetworkReachability defaultReachability;
        public bool isConnected { get; set; }

        public void CheckNetworkConnection()
        {
            InternetStatus();
        }

        public bool InternetStatus()
        {
            NetworkReachabilityFlags flags;
            bool defaultNetworkAvailable = IsNetworkAvailalble(out flags);
            if(defaultNetworkAvailable &&((flags & NetworkReachabilityFlags.IsDirect) != 0))
            {
                return false;
            }
            else if ((flags&NetworkReachabilityFlags.IsWWAN)!=0)
            {
                return true;
            }
            else if (flags==0)
            {
                return false;
            }
            return true;
        }

        public bool IsNetworkAvailalble (out NetworkReachabilityFlags flags)
        {
            if (defaultReachability == null)
            {
                defaultReachability = new NetworkReachability(new System.Net.IPAddress(0));
                defaultReachability.SetNotification(OnChange);
                defaultReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);                
            }
            if (!defaultReachability.TryGetFlags(out flags))
            {
                return false;
            }
            return isReachableWithoutRequiringConnection(flags);
        }

        private bool isReachableWithoutRequiringConnection(NetworkReachabilityFlags flags)
        {
            bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;
            bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;
            if((flags & NetworkReachabilityFlags.IsWWAN) != 0)
            {
                noConnectionRequired = true;
            }

            return isReachableWithoutRequiringConnection(flags);
        }

        private event EventHandler ReachabilityChanged;
        private void OnChange(NetworkReachabilityFlags flags)
        {
            var handler = ReachabilityChanged;
            if(handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }
    }
}