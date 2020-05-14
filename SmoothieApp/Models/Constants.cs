using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmoothieApp.Models
{
    public class Constants
    {
        public static bool isDev = true;

        #region colours

        public static Color BackgroundColour = Color.FromRgba(64, 143, 226, 1);
        public static Color MainTextColour = Color.FromRgba(255, 255, 255, 1);

        #endregion

        #region logo sizes
        public static int LoginIconHeight = 100;
        #endregion

        #region login
        public static string LoginUrl = "https://test.com/api/Auth/Login";
        #endregion
    }
}
