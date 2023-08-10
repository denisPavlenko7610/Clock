using System;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace CurrentTimeApp
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private StringBuilder currentTimeBuilder = new StringBuilder();
        private StringBuilder currentDateBuilder = new StringBuilder();

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
            currentTimeBuilder.Clear();
            currentDateBuilder.Clear();

            currentTimeBuilder.Append(DateTime.UtcNow.ToString("HH:mm:ss"));
            currentDateBuilder.Append(DateTime.UtcNow.Date.ToString("dddd, MMMM d"));

            currentTimeText.Text = currentTimeBuilder.ToString();
            currentDateText.Text = currentDateBuilder.ToString();
        }
    }
}
