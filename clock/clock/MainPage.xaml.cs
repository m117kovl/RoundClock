using System;
using System.Timers;
using Xamarin.Forms;

namespace clock
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var timeNow = DateTime.Now;
            SecondHand.RotateTo(360 / 3600 * timeNow.Second);
            MinuteHand.RotateTo(360 / 60 * timeNow.Minute);
            HourHand.RotateTo(360 / 12 * timeNow.Hour);

            InitTimer();
        }

        private void InitTimer()
        {
            var timer = new Timer(100);
            timer.Elapsed += Update;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Update(object sender, ElapsedEventArgs e)
        {
            var timeNow = DateTime.Now;
            SecondHand.Rotation = ((360 * timeNow.Second) / 60);
            MinuteHand.Rotation = ((360 * timeNow.Minute ) / 60);
            HourHand.Rotation = ((360 * timeNow.Hour ) / 12);
        }
    }
}
