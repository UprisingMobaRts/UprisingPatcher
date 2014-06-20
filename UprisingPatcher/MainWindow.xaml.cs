using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UprisingPatcher.Windows;
using UprisingPatcher.Logic;

namespace UprisingPatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Client.Pages = new List<Page>();
            Client.MainGrid = MainGrid;
            Client.MainWin = this;
            Client.Container = Container;
            Client.OverlayContainer = OverlayContainer;
            Client.ChatContainer = ChatContainer;
            Client.StatusContainer = StatusContainer;
            Client.NotificationOverlayContainer = NotificationOverlayContainer;
            Client.SwitchPage(new PatcherPage());
            //Client.SwitchPage(new PatcherPage());
        }
    }
}
