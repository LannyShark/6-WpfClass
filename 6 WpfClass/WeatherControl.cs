using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _6_WpfClass
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string windDirection;
        private int windSpeed;
        public enum Rainfall
        {
            sun = 0,
            cloud = 1,
            rain = 2,
            snow = 3,
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public string WindDirection
        {
            get => windDirection;
            set => windDirection = value;
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
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.AffectsMeasure,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -213)
                return t;
            else
                return (0);
        }
    }
}
