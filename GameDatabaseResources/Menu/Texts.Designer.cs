using System;
using System.Globalization;
using System.Resources;

namespace GameDatabaseResources.Menu
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
                    mResourceManager = new ResourceManager("GameDatabaseResources.Menu.Texts", typeof(Texts).Assembly);
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

        public static string ApplicationName
        {
            get
            {
                return TextManager.GetString(nameof(ApplicationName), CultureInformation);
            }
        }

        public static string SettingsMenu
        {
            get
            {
                return TextManager.GetString(nameof(SettingsMenu), CultureInformation);
            }
        }
    }
}
