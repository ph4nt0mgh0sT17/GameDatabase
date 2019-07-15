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
using System.Windows.Shapes;

namespace GameDatabase
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
            ProgressCircle.ProgressPercent = 0;
            ProgressCircle.PercentText = "0%";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            while (ProgressCircle.ProgressPercent < 100)
            {
                
                ProgressCircle.ProgressPercent++;
               
                await Task.Delay(15);
            }
        }
    }
}
