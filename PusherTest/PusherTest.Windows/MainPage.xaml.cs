using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PusherTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		public MainPage()
		{
			this.InitializeComponent();
			connectToPusher();


		}

		private async void connectToPusher()
		{
			var pusher = new Pusher.Pusher(new Pusher.Connections.WindowsStore.WebSocketConnectionFactory(), "652d113537502af070e5");
			pusher.EventEmitted += pusher_EventEmitted;
			await pusher.ConnectAsync();

		}

		void pusher_EventEmitted(object sender, Pusher.IIncomingEvent e)
		{
			System.Diagnostics.Debug.WriteLine(e.Data);
		}
    }
}
