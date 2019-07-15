﻿using System;
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
    /// Interaction logic for SearchGamePage.xaml
    /// </summary>
    public partial class SearchGamePage : Page
    {
        public SearchGamePage(MainWindowViewModel model)
        {
            InitializeComponent();
            DataContext = new SearchGameViewModel(model);
        }
    }
}
