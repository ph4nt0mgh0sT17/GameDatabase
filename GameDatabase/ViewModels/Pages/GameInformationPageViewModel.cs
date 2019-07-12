using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameDatabase
{
    public class GameInformationPageViewModel : BaseViewModel
    {
        #region Private fields

        private GameInformationModel mGameModel;
        private Page mContent;

        #endregion

        public GameInformationPageViewModel(GameInformationModel model)
        {
            GameModel = model;
            BasicInformation = new RelayCommand(ShowBasicInfo);
        }

        private void ShowBasicInfo()
        {
           InformationContent =  new GameBasicInformationPage(mGameModel);
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

        public RelayCommand BasicInformation
        {
            get; set;
        }

        public Page InformationContent
        {
            get
            {
                return mContent;
            }

            set
            {
                mContent = value;
                RaisePropertyChanged(nameof(InformationContent));
            }
        }
    }
}
