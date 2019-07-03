using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GameDatabase.Models.ApiModel;

namespace GameDatabase.ViewModels
{
    public class GameInfoViewModel : DependencyObject
    {
        private GameInformationModel game;

        /// <summary>
        /// Will set all information about game
        /// </summary>
        public GameInfoViewModel(GameInformationModel game)
        {
            Game = game;
        }

        public static DependencyProperty GameDependency =
            DependencyProperty.Register("Game", 
                typeof(GameInformationModel), 
                typeof(GameInfoViewModel), 
                new PropertyMetadata(
                    new GameInformationModel()));
        public GameInformationModel Game
        {
            get
            {
                return (GameInformationModel)GetValue(GameDependency);
            }

            set
            {
                if (value != null)
                {
                    SetValue(GameDependency, value);
                }
            }
        }
    }
}
