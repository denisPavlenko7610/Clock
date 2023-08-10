using System;
using System.Windows;
using System.Windows.Threading;

namespace CurrentTimeApp
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateCurrentTime();
            UpdateCurrentDate();
        }

        private void UpdateCurrentTime()
        {
            currentTimeText.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void UpdateCurrentDate()
        {
            currentDateText.Text = DateTime.Now.ToString("dddd, MMMM d");
        }
    }
}
