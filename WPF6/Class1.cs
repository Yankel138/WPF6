using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF6
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private int windSpeed;
        private string windDirection;
        private string weather;
        public enum WeatherType
        {
            Sun,
            Cloud,
            Rain,
            Snow
        }

        public WeatherControl(int temperature, string windDirection, int windSpeed, WeatherType wheater)
        {
            this.Temperature = temperature;
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
            this.Weather = weather;
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public string Weather
        {
            get
            {
                return weather;
            }
            set
            {
                weather = value;
            }
        }


        public string WindDirection
        {
            get
            {
                return windDirection;
            }
            set
            {
                windDirection = value;
            }
        }
        public int WindSpeed
        {
            get
            {
                return windSpeed;
            }
            set
            {
                if (value >= 0)
                {
                    windSpeed = value;
                }
                else
                {
                    windSpeed = 0;
                }
            }
        }



        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)));

        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return 0;
            }
        }

    }
}
