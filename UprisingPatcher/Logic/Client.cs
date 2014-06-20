using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using UprisingPatcher;
using UprisingPatcher.Windows;

namespace UprisingPatcher.Logic
{
    /// <summary>
    /// Any logic that needs to be reused over multiple pages
    /// </summary>
    internal static class Client
    {


        internal static Grid MainGrid;
        internal static Grid NotificationGrid;
        internal static Label StatusLabel;
        internal static Label InfoLabel;
        internal static ContentControl OverlayContainer;
        internal static Button PlayButton;
        internal static ContentControl ChatContainer;
        internal static ContentControl StatusContainer;
        internal static ContentControl NotificationOverlayContainer;
        internal static ListView ChatListView;

        internal static Image MainPageProfileImage;

        #region WPF Tab Change

        /// <summary>
        /// The container that contains the page to display
        /// </summary>
        internal static ContentControl Container;

        /// <summary>
        /// Page cache to stop having to recreate all information if pages are overwritted
        /// </summary>
        internal static List<Page> Pages;

        internal static bool IsOnPlayPage = false;

        /// <summary>
        /// Switches the contents of the frame to the requested page. Also sets background on
        /// the button on the top to show what section you are currently on.
        /// </summary>
        internal static void SwitchPage(Page page)
        {
            foreach (Page p in Pages) //Cache pages
            {
                if (p.GetType() == page.GetType())
                {
                    Container.Content = p.Content;
                    return;
                }
            }
            Container.Content = page.Content;
            if (!(page is FakePage))
                Pages.Add(page);
        }

        /// <summary>
        /// Clears the cache of a certain page if not used anymore
        /// </summary>
        internal static void ClearPage(Page page)
        {
            foreach (Page p in Pages.ToArray())
            {
                if (p.GetType() == page.GetType())
                {
                    Pages.Remove(p);
                    return;
                }
            }
        }

        #endregion WPF Tab Change


        internal static MainWindow MainWin;

        #region Public Helper Methods
        internal static void FocusClient()
        {
            if (MainWin.WindowState == WindowState.Minimized)
            {
                MainWin.WindowState = WindowState.Normal;
            }

            MainWin.Activate();
            MainWin.Topmost = true;  // important
            MainWin.Topmost = false; // important
            MainWin.Focus();         // important
        }

        public static String TitleCaseString(String s)
        {
            if (s == null) return s;

            String[] words = s.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 0) continue;

                Char firstChar = Char.ToUpper(words[i][0]);
                String rest = "";
                if (words[i].Length > 1)
                {
                    rest = words[i].Substring(1).ToLower();
                }
                words[i] = firstChar + rest;
            }
            return String.Join(" ", words);
        }

        public static DateTime JavaTimeStampToDateTime(double javaTimeStamp)
        {
            // Java timestamp is millisecods past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(Math.Round(javaTimeStamp / 1000)).ToLocalTime();
            return dtDateTime;
        }
        #endregion Public Helper Methods
    }
}