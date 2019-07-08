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
    /// Interaction logic for GameInformationWindow.xaml
    /// </summary>
    public partial class GameInformationWindow : Window
    {
        public GameInformationWindow()
        {
            InitializeComponent();
            DataContext = new GameInformationWindowViewModel();
        }
    }
}
