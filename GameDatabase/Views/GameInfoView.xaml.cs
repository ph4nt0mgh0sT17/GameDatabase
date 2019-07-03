﻿using GameDatabase.Models.ApiModel;
using GameDatabase.ViewModels;
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

namespace GameDatabase.Views
{
    /// <summary>
    /// Interaction logic for GameInfoView.xaml
    /// </summary>
    public partial class GameInfoView : UserControl
    {
        public GameInfoView(GameInformationModel game)
        {
            InitializeComponent();
            DataContext = new GameInfoViewModel(game);
        }
    }
}
