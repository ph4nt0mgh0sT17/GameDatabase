using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase
{
    public class GameInformationPageViewModel
    {
        #region Private fields

        private GameInformationModel mGameModel;

        #endregion

        public GameInformationPageViewModel(GameInformationModel model)
        {
            GameModel = model;
        }

        public GameInformationModel GameModel
        {
            get
            {
                return mGameModel;
            }

            set
            {
                if (value != null)
                {
                    mGameModel = value;
                }
            }
        }
    }
}
