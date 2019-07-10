using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameDatabase
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Private fields

        #region Resolution of the window

        private int mWidth;
        private int mHeight;
        private int mMinWidth;
        private int mMinHeight;

        #endregion

        #region Margin of the window

        private int mLeftWindow;
        private int mTopWindow;

        #endregion

        private string mTitleApplication;

        #endregion

        #region Public events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /// <summary>
        /// Constructor sets title as default name of the application
        /// </summary>
        public BaseViewModel()
        {
            // Gets text from Resource folder
            TitleApplication = Resource.Title;

            Width = 1024;
            Height = 768;

            CenterScreen();
        }

        #region Private helper methods

        private void CenterScreen()
        {
            int screenWidth = (int)SystemParameters.PrimaryScreenWidth;
            int screenHeight = (int)SystemParameters.PrimaryScreenHeight;

            int windowWidth = this.Width;
            int windowHeight = this.Height;

            this.LeftWindow = (screenWidth / 2) - (windowWidth / 2);
            this.TopWindow = (screenHeight / 2) - (windowHeight / 2);
        }

        #endregion

        #region Public properties

        #region Resolution of the window

        /// <summary>
        /// The width of the window
        /// </summary>
        public int Width
        {
            get
            {
                return mWidth;
            }

            set
            {
                mWidth = value;
                RaisePropertyChanged(nameof(Width));
            }
        }
        
        /// <summary>
        /// The height of the window
        /// </summary>
        public int Height
        {
            get
            {
                return mHeight;
            }

            set
            {
                mHeight = value;
                RaisePropertyChanged(nameof(Height));
            }
        }

        /// <summary>
        /// Min width of the window
        /// </summary>
        public int MinWidth
        {
            get
            {
                return mMinWidth;
            }

            set
            {
                mMinWidth = value;
            }
        }

        /// <summary>
        /// Minimal height of the window
        /// </summary>
        public int MinHeight
        {
            get
            {
                return mMinHeight;
            }

            set
            {
                mMinHeight = value;
            }
        }

        #endregion

        #region Margin of the window

        public int LeftWindow
        {
            get
            {
                return mLeftWindow;
            }

            set
            {
                mLeftWindow = value;
            }
        }

        public int TopWindow
        {
            get
            {
                return mTopWindow;
            }

            set
            {
                mTopWindow = value;
            }
        }

        #endregion

        /// <summary>
        /// A title of the application
        /// </summary>
        public string TitleApplication
        {
            get
            {
                return mTitleApplication;
            }

            private set
            {
                mTitleApplication = value;
            }
        }

        #endregion

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
