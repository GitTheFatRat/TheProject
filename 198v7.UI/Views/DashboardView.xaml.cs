using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace _198v7.UI.Views
{
    // Model cho các thanh Bar
    public class CoreBarItem
    {
        public string Label { get; set; } = "";
        public string ValueText { get; set; } = "";
        public double BarWidth { get; set; }
        public Brush BarColor { get; set; } = Brushes.Green;
    }

    public partial class DashboardView : UserControl
    {
        private readonly ObservableCollection<CoreBarItem> _socket0 = new();
        private readonly ObservableCollection<CoreBarItem> _socket1 = new();
        private readonly DispatcherTimer _timer = new();
        private readonly Random _rnd = new();

        public DashboardView()
        {
            InitializeComponent();

            // Khởi tạo dữ liệu mẫu cho 9 cores mỗi Socket
            for (int i = 0; i < 9; i++)
            {
                _socket0.Add(new CoreBarItem { Label = $"C{i}", ValueText = "0%", BarWidth = 0 });
                _socket1.Add(new CoreBarItem { Label = $"C{i}", ValueText = "0%", BarWidth = 0 });
            }

            // Gán nguồn dữ liệu cho ItemsControl trong XAML
            Socket0Bars.ItemsSource = _socket0;
            Socket1Bars.ItemsSource = _socket1;

            // Chạy timer cập nhật UI
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // 1. Cập nhật các thanh Bar (Dữ liệu giả lập)
            for (int i = 0; i < 9; i++)
            {
                int v0 = _rnd.Next(5, 95);
                int v1 = _rnd.Next(5, 95);

                _socket0[i] = new CoreBarItem
                {
                    Label = $"Core {i}",
                    ValueText = $"{v0}%",
                    BarWidth = v0 * 1.5, // Tỉ lệ độ dài thanh bar
                    BarColor = GetColorByValue(v0)
                };

                _socket1[i] = new CoreBarItem
                {
                    Label = $"Core {i}",
                    ValueText = $"{v1}%",
                    BarWidth = v1 * 1.5,
                    BarColor = GetColorByValue(v1)
                };
            }

            // 2. Cập nhật các thẻ Metric (Khớp với x:Name trong XAML của bạn)
            TxtCpuLoad.Text = $"{_rnd.Next(20, 45)}%";
            TxtCpuTemp.Text = $"{_rnd.Next(45, 55)}°C";
            TxtGpuTemp.Text = $"{_rnd.Next(60, 70)}°C";
            TxtRam.Text = $"{_rnd.Next(25, 30)}.{_rnd.Next(0, 9)} GB";

            // Cập nhật QPI Traffic trong bảng System Status
            if (TxtQpi != null)
                TxtQpi.Text = $"{_rnd.Next(1, 5)}.{_rnd.Next(0, 9)} GB/s";
        }

        private Brush GetColorByValue(int value)
        {
            if (value < 50) return (Brush)FindResource("BrushGood");
            if (value < 80) return (Brush)FindResource("BrushWarn");
            return Brushes.Red;
        }

        private void BtnGamingMode_Click(object sender, RoutedEventArgs e)
        {
            BtnGamingMode.Content = "APPLYING...";
            var t = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1.5) };
            t.Tick += (s, ev) => {
                BtnGamingMode.Content = "GAMING MODE ON";
                t.Stop();
            };
            t.Start();
        }

        private void BtnRestore_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Restored to system defaults.", "198v7", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}