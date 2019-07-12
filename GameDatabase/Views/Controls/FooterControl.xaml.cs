using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameDatabaseResources.Footer;

namespace GameDatabase
{
    /// <summary>
    /// Footer user control 
    /// </summary>
    public partial class FooterControl : UserControl
    {
        /// <summary>
        /// Constructor which sets FooterWidth if in designer
        /// </summary>
        public FooterControl()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                FooterWidth = 800;
            }

            DataContext = this;
        }

        #region Properties

        /// <summary>
        /// Footer content -> Footer version of the application
        /// </summary>
        public string FooterContent
        {
            get
            {
                return Texts.FooterVersion;
            }
        }

        /// <summary>
        /// Gets the author of the application
        /// </summary>
        public string ApplicationAuthor
        {
            get
            {
                return $"{Texts.AuthorString}: {Texts.Author}";
            }
        }

        /// <summary>
        /// Gets the width of a footer
        /// </summary>
        public int FooterWidth
        {
            get
            {
                return (int)GetValue(FooterWidthProperty);
            }

            set { SetValue(FooterWidthProperty, value); }
        }

        #endregion

        #region Dependency properties

        // Using a DependencyProperty as the backing store for FooterWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FooterWidthProperty =
            DependencyProperty.Register("FooterWidth", typeof(int), typeof(FooterControl), new PropertyMetadata(0));

        #endregion


    }
}
