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

        public MainWindow()
        {
            InitializeComponent();

            currentTimeBuilder = new StringBuilder();
            currentDateBuilder = new StringBuilder();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += OnTick;

            timer.Start();
            
        }

        private void OnTick(object sender, EventArgs e)
        {
            currentTimeBuilder.Clear();
            currentDateBuilder.Clear();

            var currentTime = DateTime.Now;

            currentTimeBuilder.Append(currentTime.ToString("HH:mm:ss"));
            currentDateBuilder.Append(currentTime.ToString("dddd, MMMM d"));

            currentTimeText.Text = currentTimeBuilder.ToString();
            currentDateText.Text = currentDateBuilder.ToString();
        }
    }
}
