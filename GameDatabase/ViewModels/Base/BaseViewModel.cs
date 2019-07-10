using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Private fields

        // Resolution of the window -> every view model will have these variables
        private int mWidth;
        private int mHeight;
        private int mMinWidth;
        private int mMinHeight;

        #endregion

        #region Public events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public properties

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

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
