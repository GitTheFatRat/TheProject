using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace _198v7.UI.Views
{
    public partial class CpuOptimizerView : UserControl
    {
        private readonly ObservableCollection<CoreBarItem> _s0 = new();
        private readonly ObservableCollection<CoreBarItem> _s1 = new();
        private readonly DispatcherTimer _timer = new();
        private readonly Random _rnd = new();

        private static Brush GetColor(int v) => v switch
        {
            < 50 => new SolidColorBrush(Color.FromRgb(0x00, 0xBB, 0x55)),
            < 75 => new SolidColorBrush(Color.FromRgb(0xF0, 0xA5, 0x00)),
            _ => new SolidColorBrush(Color.FromRgb(0xFF, 0x40, 0x40))
        };

        public CpuOptimizerView()
        {
            InitializeComponent();
            for (int i = 0; i < 18; i++)
            {
                int v0 = _rnd.Next(5, 90), v1 = _rnd.Next(5, 90);
                _s0.Add(new CoreBarItem { Label = $"Core {i}", ValueText = $"{v0}%", BarWidth = v0 * 1.2, BarColor = GetColor(v0) });
                _s1.Add(new CoreBarItem { Label = $"Core {i}", ValueText = $"{v1}%", BarWidth = v1 * 1.2, BarColor = GetColor(v1) });
            }
            CpuS0Bars.ItemsSource = _s0;
            CpuS1Bars.ItemsSource = _s1;

            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += (s, e) =>
            {
                for (int i = 0; i < 18; i++)
                {
                    int v0 = Math.Clamp(_rnd.Next((int)(_s0[i].BarWidth / 1.2) - 10, (int)(_s0[i].BarWidth / 1.2) + 10), 5, 95);
                    int v1 = Math.Clamp(_rnd.Next((int)(_s1[i].BarWidth / 1.2) - 10, (int)(_s1[i].BarWidth / 1.2) + 10), 5, 95);
                    _s0[i] = new CoreBarItem { Label = $"Core {i}", ValueText = $"{v0}%", BarWidth = v0 * 1.2, BarColor = GetColor(v0) };
                    _s1[i] = new CoreBarItem { Label = $"Core {i}", ValueText = $"{v1}%", BarWidth = v1 * 1.2, BarColor = GetColor(v1) };
                }
                CpuS0Bars.ItemsSource = new ObservableCollection<CoreBarItem>(_s0);
                CpuS1Bars.ItemsSource = new ObservableCollection<CoreBarItem>(_s1);
                TxtF0.Text = $"{(3.0 + _rnd.NextDouble() * 0.4):F1} GHz";
                TxtF1.Text = $"{(2.9 + _rnd.NextDouble() * 0.3):F1} GHz";
            };
            _timer.Start();
        }

        private void BtnApplyCpu_Click(object sender, RoutedEventArgs e) => ShowApplied(sender as Button, "CPU TWEAKS");
        private void BtnApplyNuma_Click(object sender, RoutedEventArgs e) => ShowApplied(sender as Button, "NUMA");
        private void BtnApplyScheduler_Click(object sender, RoutedEventArgs e) => ShowApplied(sender as Button, "SCHEDULER");

        private void ShowApplied(Button? btn, string label)
        {
            if (btn == null) return;
            var orig = btn.Content;
            btn.Content = "ĐANG ÁP DỤNG...";
            var t = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            t.Tick += (s, e) => {
                btn.Content = $"XONG — {label}"; t.Stop();
                var t2 = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.5) };
                t2.Tick += (s2, e2) => { btn.Content = orig; t2.Stop(); };
                t2.Start();
            };
            t.Start();
        }
    }
}