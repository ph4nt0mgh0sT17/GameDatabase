﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GameDatabaseResources.Application;

namespace GameDatabase
{
    public class SettingsPageViewModel : BaseViewModel
    {
        private ObservableCollection<Language> mLanguageItems;
        private Language mSelectedLanguage;

        /// <summary>
        /// Settings contructor - sets some default values
        /// </summary>
        public SettingsPageViewModel()
        {
            TitleApplication = Texts.SettingsTitle;
            LanguageItems = new ObservableCollection<Language>() { new Language("Czech", "cs-cz"), new Language("English", "en-US") };

            // Finds the language which is set as default language of the application
            mSelectedLanguage = LanguageItems.Single(language => language.Name == Setting.Language);
        }

        private void ChangeLanguage(Language changedLanguage)
        {
            string applicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string settingPath = Path.Combine(applicationPath, "Setting.txt");

            // Writes the language into Setting.txt file
            using (StreamWriter writer = new StreamWriter(settingPath))
            {
                writer.WriteLine($"Language={changedLanguage.Name}");
                writer.Flush();
                writer.Close();
            }

            // Restarts the application
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }

        #region Properties

        /// <summary>
        /// Gets the LanguageText from <see cref="GameDatabaseResources.Settings.Texts"/>
        /// </summary>
        public string LanguageText
        {
            get
            {
                return GameDatabaseResources.Settings.Texts.LanguageText;
            }
        }

        public ObservableCollection<Language> LanguageItems
        {
            get
            {
                return mLanguageItems;
            }

            set
            {
                mLanguageItems = value;
            }
        }

        /// <summary>
        /// Gets selected language item by user
        /// </summary>
        public Language SelectedLanguage
        {
            get
            {
                return mSelectedLanguage;
            }

            set
            {
                // If language gets changed
                if (mSelectedLanguage != value)
                {
                    mSelectedLanguage = value;
                    RaisePropertyChanged(nameof(SelectedLanguage));
                    ChangeLanguage(value);
                }
            }
        }

        #endregion
    }
}
