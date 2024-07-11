using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Lab04_OOP
{
    public class CustomTextBox : TextBox
    {
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(CustomTextBox),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None, MinValuePropertyChanged, CoerceMinValue));

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(CustomTextBox),
                new FrameworkPropertyMetadata(double.MaxValue, FrameworkPropertyMetadataOptions.None, MaxValuePropertyChanged, CoerceMaxValue));

        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        private static object CoerceMinValue(DependencyObject d, object baseValue)
        {
            var textBox = d as CustomTextBox;
            double minValue = (double)baseValue;
            double maxValue = textBox.MaxValue;
            return Math.Min(minValue, maxValue);
        }

        private static object CoerceMaxValue(DependencyObject d, object baseValue)
        {
            var textBox = d as CustomTextBox;
            double minValue = textBox.MinValue;
            double maxValue = (double)baseValue;
            return Math.Max(minValue, maxValue);
        }

        private static void MinValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as CustomTextBox;
            textBox.CoerceValue(MaxValueProperty);
        }

        private static void MaxValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as CustomTextBox;
            textBox.CoerceValue(MinValueProperty);
        }
    }

}
