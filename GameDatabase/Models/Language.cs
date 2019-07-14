using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase
{
    public class Language
    {
        #region Private fields

        private string mTitle;
        private string mName;

        #endregion

        public Language(string mTitle, string mName)
        {
            this.mTitle = mTitle;
            this.mName = mName;
        }

        public string Title
        {
            get
            {
                return mTitle;
            }

            set
            {
                mTitle = value;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }
    }
}
