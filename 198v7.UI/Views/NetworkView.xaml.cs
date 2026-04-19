using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace _198v7.UI.Views
{
    public partial class NetworkView : UserControl
    {
        private readonly DispatcherTimer _timer = new();
        private readonly Random _rnd = new();

        public NetworkView()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += (s, e) =>
            {
                TxtPing.Text = $"{_rnd.Next(14, 24)}ms";
                TxtJitter.Text = $"{_rnd.Next(1, 4)}ms";
                TxtRiot.Text = $"{_rnd.Next(14, 24)}ms";
                TxtSteam.Text = $"{_rnd.Next(18, 28)}ms";
                TxtBnet.Text = $"{_rnd.Next(20, 32)}ms";
                TxtEa.Text = $"{_rnd.Next(35, 48)}ms";
            };
            _timer.Start();
        }

        private void BtnApplyNet_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn) return;
            btn.Content = "ĐANG ÁP DỤNG...";
            var t = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            t.Tick += (s, ev) => { btn.Content = "APPLY NETWORK"; t.Stop(); };
            t.Start();
        }
    }
}