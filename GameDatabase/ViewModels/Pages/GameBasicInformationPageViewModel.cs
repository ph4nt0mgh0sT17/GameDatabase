using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase
{
    public class GameBasicInformationPageViewModel
    {
        #region Private members

        private GameInformationModel mGameModel;

        #endregion

        public GameBasicInformationPageViewModel(GameInformationModel gameModel)
        {
            mGameModel = gameModel;
        }

        public GameInformationModel GameModel
        {
            get
            {
                return mGameModel;
            }
        }

    }
}
