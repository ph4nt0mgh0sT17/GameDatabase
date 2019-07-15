using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameDatabase
{
    /// <summary>
    /// Interaction logic for ProgressCircle.xaml
    /// </summary>
    public partial class ProgressCircleControl : UserControl
    {
        public ProgressCircleControl()
        {
            InitializeComponent();
            DataContext = this;
        }



        public string PercentText
        {
            get { return (string)GetValue(PercentTextProperty); }
            set { SetValue(PercentTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PercentText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentTextProperty =
            DependencyProperty.Register("PercentText", typeof(string), typeof(ProgressCircleControl), new PropertyMetadata(""));



        public double ProgressPercent
        {
            get { return (double)GetValue(ProgressPercentProperty); }
            set { SetValue(ProgressPercentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressPercent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressPercentProperty =
            DependencyProperty.Register("ProgressPercent", typeof(double), typeof(ProgressCircleControl), new PropertyMetadata(0.0, new PropertyChangedCallback(OnProgressProperty)));

        private static void OnProgressProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProgressCircleControl control = d as ProgressCircleControl;

            control.PercentText = $"{e.NewValue}%";
        }
    }
}
