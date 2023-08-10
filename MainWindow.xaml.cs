using System;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace CurrentTimeApp
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private StringBuilder currentTimeBuilder;
        private StringBuilder currentDateBuilder;
        private DateTime currentTime;
        private DateTime currentDate;
        public MainWindow()
        {
            InitializeComponent();

            currentTimeBuilder = new StringBuilder();
            currentDateBuilder = new StringBuilder();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            timer.Start();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentTimeBuilder.Clear();
            currentDateBuilder.Clear();

            currentTime = DateTime.Now;
            currentDate = currentTime.Date;

            currentTimeBuilder.Append(currentTime.ToString("HH:mm:ss"));
            currentDateBuilder.Append(currentDate.ToString("dddd, MMMM d"));

            currentTimeText.Text = currentTimeBuilder.ToString();
            currentDateText.Text = currentDateBuilder.ToString();
        }
    }
}
