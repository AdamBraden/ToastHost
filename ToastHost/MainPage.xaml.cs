using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ToastHost
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string _myPackageId = "";
        private string _myPackagePath = "";

        public MainPage()
        {
            this.InitializeComponent();

            _myPackageId = Windows.ApplicationModel.Package.Current.Id.FullName;
            _myPackagePath = Windows.ApplicationModel.Package.Current.InstalledPath;
            textblockPackageId.Text = _myPackageId;
            textblockPackagePath.Text = _myPackagePath;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string toastXml = $@"<toast>
                            <visual>
                                <binding template='ToastGeneric'>
                                    <text>From ToastHost!</text>
                                    <text>My App Identity is: {_myPackageId}</text>
                                </binding>
                            </visual>
                        </toast>";

            XmlDocument toastDoc = new XmlDocument();
            toastDoc.LoadXml(toastXml);

            ToastNotification toast = new ToastNotification(toastDoc);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

    }
}
