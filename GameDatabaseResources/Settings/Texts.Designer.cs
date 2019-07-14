using System;
using System.Globalization;
using System.Resources;

namespace GameDatabaseResources.Settings
{
    public class Texts
    {

        private static ResourceManager mResourceManager;
        private static CultureInfo mCultureInfo;

        public Texts()
        {
        }

        private static ResourceManager TextManager
        {
            get
            {
                if (object.Equals(mResourceManager, null))
                {
                    mResourceManager = new ResourceManager("GameDatabaseResources.Settings.Texts", typeof(Texts).Assembly);
                }

                return mResourceManager;
            }
        }

        private static CultureInfo CultureInformation
        {
            get
            {
                return mCultureInfo;
            }

            set
            {
                mCultureInfo = value;
            }
        }

        public static string LanguageText
        {
            get
            {
                return TextManager.GetString(nameof(LanguageText), CultureInformation);
            }
        }
    }
}
