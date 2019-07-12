using System;
using System.Globalization;
using System.Resources;

namespace GameDatabaseResources.Application
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
                    mResourceManager = new ResourceManager("GameDatabaseResources.Application.Texts", typeof(Texts).Assembly);
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

        public static string FooterVersion
        {
            get
            {
                return TextManager.GetString(nameof(FooterVersion), CultureInformation);
            }
        }

        public static string Author
        {
            get
            {
                return TextManager.GetString(nameof(Author), CultureInformation);
            }
        }
    }
}
