using System;
using System.Globalization;
using System.Resources;

namespace GameDatabaseResources.Footer
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
                    mResourceManager = new ResourceManager("GameDatabaseResources.Footer.Texts", typeof(Texts).Assembly);
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

        /// <summary>
        /// Version of the game displayed in the footer
        /// </summary>
        public static string FooterVersion
        {
            get
            {
                return TextManager.GetString(nameof(FooterVersion), CultureInformation);
            }
        }

        /// <summary>
        /// The name of the author of the application
        /// </summary>
        public static string Author
        {
            get
            {
                return TextManager.GetString(nameof(Author), CultureInformation);
            }
        }

        /// <summary>
        /// A string for displaying name of author
        /// </summary>
        public static string AuthorString
        {
            get
            {
                return TextManager.GetString(nameof(AuthorString), CultureInformation);
            }
        }
    }
}
