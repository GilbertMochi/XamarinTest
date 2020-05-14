using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SmoothieApp.Data;
using SmoothieApp.Droid.Data;

[assembly:Xamarin.Forms.Dependency(typeof(NetworkConnection))]
namespace SmoothieApp.Droid.Data
{
    class NetworkConnection : INetworkConnection
    {
        public bool isConnected { get; set; }

        public void CheckNetworkConnection()
        {
            var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            if (activeNetworkInfo == null && activeNetworkInfo.IsConnectedOrConnecting)
            {
                isConnected = true;
            }
            else
            {
                isConnected = false;
            }
        }
    }
}