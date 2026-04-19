using _198v7.UI.Views;
using System.Windows;
using System.Windows.Input;

namespace _198v7.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new DashboardView();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
            => WindowState = WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;

        private void BtnClose_Click(object sender, RoutedEventArgs e)
            => Application.Current.Shutdown();

        private void Nav_Dashboard(object sender, RoutedEventArgs e)
        {
            TabDashboard.IsChecked = true;
            MainFrame.Content = new DashboardView();
        }

        private void Nav_MyComputer(object sender, RoutedEventArgs e)
        {
            TabMyComputer.IsChecked = true;
            MainFrame.Content = new MyComputerView();
        }

        private void Nav_Cpu(object sender, RoutedEventArgs e)
        {
            TabCpu.IsChecked = true;
            MainFrame.Content = new CpuOptimizerView();
        }

        private void Nav_Gpu(object sender, RoutedEventArgs e)
        {
            TabGpu.IsChecked = true;
            MainFrame.Content = new GpuView();
        }

        private void Nav_Ram(object sender, RoutedEventArgs e)
        {
            TabRam.IsChecked = true;
            MainFrame.Content = new RamView();
        }

        private void Nav_Network(object sender, RoutedEventArgs e)
        {
            TabNetwork.IsChecked = true;
            MainFrame.Content = new NetworkView();
        }

        private void Nav_Thermal(object sender, RoutedEventArgs e)
        {
            TabThermal.IsChecked = true;
            MainFrame.Content = new ThermalView();
        }

        private void Nav_Profiles(object sender, RoutedEventArgs e)
        {
            TabProfiles.IsChecked = true;
            MainFrame.Content = new GameProfilesView();
        }
    }
}