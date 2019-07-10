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
    /// Interaction logic for FooterControl.xaml
    /// </summary>
    public partial class FooterControl : UserControl
    {
        public FooterControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string FooterContent { get; } = Resource.Version;

        public int FooterWidth
        {
            get { return (int)GetValue(FooterWidthProperty); }
            set { SetValue(FooterWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FooterWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FooterWidthProperty =
            DependencyProperty.Register("FooterWidth", typeof(int), typeof(FooterControl), new PropertyMetadata(0));


    }
}
