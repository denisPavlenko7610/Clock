using System;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;

namespace Time
{
    public partial class MainWindow
    {
        private readonly DispatcherTimer _timer;
        private DateTime _lastDate = DateTime.MinValue;

        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer(DispatcherPriority.Background, Dispatcher)
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += OnTick;

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object? sender, RoutedEventArgs e)
        {
            UpdateNow(DateTime.Now);
            AlignAndStart();
        }

        private void OnUnloaded(object? sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _timer.Tick -= OnTick;
            Loaded -= OnLoaded;
            Unloaded -= OnUnloaded;
        }

        private void AlignAndStart()
        {
            var now = DateTime.Now;
            var delay = TimeSpan.FromMilliseconds(1000 - now.Millisecond);
            _timer.Stop();
            _timer.Interval = delay;
            _timer.Start();
        }

        private void OnTick(object? sender, EventArgs e)
        {
            var now = DateTime.Now;

            if (_timer.Interval != TimeSpan.FromSeconds(1))
                _timer.Interval = TimeSpan.FromSeconds(1);

            UpdateNow(now);
        }

        private void UpdateNow(DateTime now)
        {
            var culture = CultureInfo.CurrentCulture;

            currentTimeText.Text = now.ToString("HH:mm:ss", culture);

            if (now.Date != _lastDate.Date)
            {
                currentDateText.Text = now.ToString("dddd, MMMM d", culture);
                _lastDate = now.Date;
            }
        }
    }
}
