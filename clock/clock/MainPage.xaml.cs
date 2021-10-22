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
            var timer = new Timer(1000);
            timer.Elapsed += Update;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Update(object sender, ElapsedEventArgs e)
        {
            var timeNow = DateTime.Now;
            int s = ((360 * timeNow.Second) / 60);
            int m= ((360 * timeNow.Minute) / 60);
            int h= ((360 * timeNow.Hour) / 12);
            
            if (s==0 || m==0 || h==0)
            {
                SecondHand.Rotation =s;
                MinuteHand.Rotation = m;
                HourHand.Rotation = h;
            }
            else
            {
                SecondHand.RotateTo(s);
                MinuteHand.RotateTo(m);
                HourHand.RotateTo(h);
            }
            //SecondHand.Rotation = ((360 * timeNow.Second) / 60);
            //MinuteHand.Rotation = ((360 * timeNow.Minute ) / 60);
            //HourHand.Rotation = ((360 * timeNow.Hour ) / 12);
            //SecondHand.RotateTo
        }
    }
}
