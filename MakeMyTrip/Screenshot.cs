//-----------------------------------------------------------------------
// <copyright file="Screenshot.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using OpenQA.Selenium;
using System;

namespace MakeMyTrip
{
    /// <summary>
    /// create Screenshot class
    /// </summary>
   public class Screenshot
    {
        /// <summary>
        /// create Capture method
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="ScreenShotName"></param>
        /// <returns>localpath</returns>
        public static string Capture(IWebDriver driver, string ScreenShotName)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            var ts = ((ITakesScreenshot)driver).GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string uptobinpath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshot images\\" + (ScreenShotName + "   " + time) + ".png";
            string localPath = new Uri(uptobinpath).LocalPath;
            ts.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }
    }
}
