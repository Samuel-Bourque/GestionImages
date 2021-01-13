using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace GestIMG_UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BitmapImage BitmapOrigine { get; set; }
        public TeintesGris TeintesGris { get; set; }
        public ReduireIntensite ReduireIntensite { get; set; }
        public AugmenterIntensite AugmenterIntensite { get; set; }
        public SeparerCouleurs SeparerCouleurs { get; set; }

        public MainWindow()
        {
            TeintesGris = new TeintesGris();
            ReduireIntensite = new ReduireIntensite();
            AugmenterIntensite = new AugmenterIntensite();
            SeparerCouleurs = new SeparerCouleurs();
            InitializeComponent();
            this.DataContext = this;
        }
        private void FichierOuvrir_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.png ...)";
            if (dlg.ShowDialog() == true)
            {
                BitmapOrigine = new BitmapImage(new Uri(dlg.FileName));
                imgOrigine.Source = BitmapOrigine;
            }
        }
        private void FichierOuvrir_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            e.CanExecute = dlg.CheckFileExists;
        }

        private void FlipHoriz_Executed(object sender, RoutedEventArgs e)
        {
            imgCourante.Source = ManipImage.FlipHorizontal(BitmapOrigine);
        }

        private void FlipVert_Executed(object sender, RoutedEventArgs e)
        {
            imgCourante.Source = ManipImage.FlipVertical(BitmapOrigine);
        }
    }
}
