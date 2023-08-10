using System;
using System.Windows;
using System.Windows.Threading;

namespace CurrentTimeApp
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DateTime currentTime;
        private DateTime currentDate;

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
            currentTime = DateTime.Now;
            currentDate = currentTime.Date;

            currentTimeText.Text = currentTime.ToString("HH:mm:ss");
            currentDateText.Text = currentDate.ToString("dddd, MMMM d");
        }
    }
}
