using POC.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Apps.Login
{

    /// <summary>
    /// The TenprintAppsLogin
    /// </summary>
    /// <param name="userLevel">The userLevel<see cref="string"/></param>
    public class TenprintLogin : General
    {
        /// <summary>
        /// The TenprintAppsLogin
        /// </summary>
        /// <param name="userLevel">The userLevel<see cref="string"/></param>
        public void TenprintAppsLogin(string userLevel)
        {
            IBW5Login(Constants.TP_APP_NAME, "Tenprint", "Input Queue", userLevel);
        }
    }
}

