using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameDatabase
{
    public class GameInfoViewModel : BaseViewModel
    {
        private GameInformationModel mGame;


        public GameInfoViewModel(GameInformationModel game)
        {
            mGame = game;
        }

        public GameInformationModel Game
        {
            get
            {
                return mGame;
            }

            set
            {
                if (value != null)
                {
                    mGame = value;
                    RaisePropertyChanged(nameof(Game));
                }
            }
        }
    }
}
