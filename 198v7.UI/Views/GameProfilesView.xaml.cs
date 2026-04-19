using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace _198v7.UI.Views
{
    public partial class GameProfilesView : UserControl
    {
        public GameProfilesView()
        {
            InitializeComponent();
        }

        private void BtnAutoDetect_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn) return;
            btn.Content = "SCANNING...";
            var t = new DispatcherTimer { Interval = System.TimeSpan.FromSeconds(2) };
            t.Tick += (s, ev) => { btn.Content = "AUTO-DETECT GAME"; t.Stop(); };
            t.Start();
        }

        private void BtnSaveProfile_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn) return;
            btn.Content = "ĐANG LƯU...";
            var t = new DispatcherTimer { Interval = System.TimeSpan.FromSeconds(1) };
            t.Tick += (s, ev) => { btn.Content = "SAVE &amp; APPLY PROFILE"; t.Stop(); };
            t.Start();
        }

        private void BtnRestoreProfile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Đã hoàn tác về cài đặt mặc định.", "198v7",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}