using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace _198v7.UI.Views
{
    public partial class GpuView : UserControl
    {
        private readonly DispatcherTimer _timer = new();
        private readonly Random _rnd = new();

        public GpuView()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += (s, e) =>
            {
                TxtGpuLoad.Text = $"{_rnd.Next(60, 85)}%";
                TxtGpuTemp.Text = $"{_rnd.Next(62, 72)}°C";
                TxtGpuClock.Text = $"{_rnd.Next(1700, 1900)} MHz";
            };
            _timer.Start();
        }

        private void BtnApplyGpu_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn) return;
            var orig = btn.Content;
            btn.Content = "ĐANG ÁP DỤNG...";
            var t = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            t.Tick += (s, ev) =>
            {
                btn.Content = "XONG — GPU";
                t.Stop();
                var t2 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.5) };
                t2.Tick += (s2, ev2) => { btn.Content = orig; t2.Stop(); };
                t2.Start();
            };
            t.Start();
        }
    }
}