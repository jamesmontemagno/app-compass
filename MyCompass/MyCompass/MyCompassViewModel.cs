using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyCompass
{
    public class MyCompassViewModel : MvvmHelpers.BaseViewModel
    {
        public MyCompassViewModel()
        {
            StopCommand = new Command(Stop);
            StartCommand = new Command(Start);
        }
        string headingDisplay;
        public string HeadingDisplay
        {
            get => headingDisplay;
            set => SetProperty(ref headingDisplay, value);
        }

        double heading = 0;
        public double Heading
        {
            get => heading;
            set => SetProperty(ref heading, value);
        }

        public Command StopCommand { get; }

        void Stop()
        {
            if (!Compass.IsMonitoring)
                return;

            Compass.ReadingChanged -= Compass_ReadingChanged;
            Compass.Stop();
        }


        public Command StartCommand { get; }

        void Start()
        {
            if (Compass.IsMonitoring)
                return;

            
            Compass.ReadingChanged += Compass_ReadingChanged;
            Compass.Start(SensorSpeed.UI, true);

        }

        void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            Heading = e.Reading.HeadingMagneticNorth;
            HeadingDisplay = $"Heading: {Heading.ToString()}";
        }
    }
}
