using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace _198v7.UI.Views
{
    public partial class MyComputerView : UserControl
    {
        private readonly DispatcherTimer _scanTimer = new();
        private readonly Random _rnd = new();
        private int _scanStep = 0;

        private readonly string[] _scanSteps =
        {
            "Đọc SMBIOS / DMI table...",
            "Phát hiện CPU dual-socket (CPUID)...",
            "Đọc NUMA topology...",
            "Phân tích RAM slot (64GB + 32GB)...",
            "Detect GPU via NVML...",
            "Kiểm tra mainboard (Huananzhi F8D)...",
            "Load WinRing0 — MSR access...",
            "Kết nối Intel PCM...",
            "Ghost Spectre WMI check...",
            "Hoàn tất!"
        };

        public MyComputerView()
        {
            InitializeComponent();

            // Bắt đầu scan ngay khi load
            StartScan();
        }

        private void StartScan()
        {
            _scanStep = 0;
            ScanBar.Visibility = Visibility.Visible;
            MainContent.Visibility = Visibility.Collapsed;
            InfoBox.Visibility = Visibility.Collapsed;

            _scanTimer.Interval = TimeSpan.FromMilliseconds(320);
            _scanTimer.Tick += ScanTimer_Tick;
            _scanTimer.Start();
        }

        private void ScanTimer_Tick(object? sender, EventArgs e)
        {
            if (_scanStep >= _scanSteps.Length)
            {
                _scanTimer.Stop();
                ScanBar.Visibility = Visibility.Collapsed;
                InfoBox.Visibility = Visibility.Visible;
                MainContent.Visibility = Visibility.Visible;

                // Cập nhật freq live giả
                TxtFreqS0.Text = $"{(3.0 + _rnd.NextDouble() * 0.4):F1} GHz";
                TxtFreqS1.Text = $"{(2.9 + _rnd.NextDouble() * 0.3):F1} GHz";
                return;
            }

            TxtScanStatus.Text = _scanSteps[_scanStep];
            TxtScanPct.Text =
                $"{(int)((_scanStep + 1.0) / _scanSteps.Length * 100)}%";
            _scanStep++;
        }

        private void BtnRescan_Click(object sender, RoutedEventArgs e)
        {
            StartScan();
        }
    }
}