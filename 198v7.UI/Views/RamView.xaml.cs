using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace _198v7.UI.Views
{
    public partial class RamView : UserControl
    {
        private readonly DispatcherTimer _timer = new();
        private readonly Random _rnd = new();

        public RamView()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += (s, e) =>
            {
                double used = 25 + _rnd.NextDouble() * 6;
                TxtRamUsed.Text = $"{used:F1} GB";
                TxtRamFree.Text = $"{96 - used:F1} GB";
            };
            _timer.Start();
        }

        private void BtnCleanRam_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn) return;
            btn.Content = "ĐANG DỌN...";
            var t = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.5) };
            t.Tick += (s, ev) => { btn.Content = "CLEAN RAM NOW"; t.Stop(); };
            t.Start();
        }
    }
}