using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace _198v7.UI.Views
{
    public partial class ThermalView : UserControl
    {
        private readonly DispatcherTimer _timer = new();
        private readonly Random _rnd = new();

        public ThermalView()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += (s, e) =>
            {
                int s0 = _rnd.Next(48, 57), s1 = _rnd.Next(45, 54), gpu = _rnd.Next(63, 72);
                Brush good = new SolidColorBrush(Color.FromRgb(0x00, 0xBB, 0x55));
                Brush warn = new SolidColorBrush(Color.FromRgb(0xF0, 0xA5, 0x00));

                TxtS0.Text = TxtS0b.Text = $"{s0}°C";
                TxtS1.Text = TxtS1b.Text = $"{s1}°C";
                TxtGpu.Text = TxtGpub.Text = $"{gpu}°C";
                TxtS0.Foreground = TxtS0b.Foreground = s0 < 65 ? good : warn;
                TxtS1.Foreground = TxtS1b.Foreground = s1 < 65 ? good : warn;
                TxtGpu.Foreground = TxtGpub.Foreground = gpu < 75 ? warn : warn;
            };
            _timer.Start();
        }
    }
}