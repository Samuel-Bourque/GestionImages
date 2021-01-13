using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace GestIMG_UI
{
    public class AugmenterIntensite : ICommand
    {
        public BitmapImage BitmapOrigine { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            MainWindow source = parameter as MainWindow;
            return source != null && source.BitmapOrigine != null;
        }

        public void Execute(object parameter)
        {
            MainWindow source = parameter as MainWindow;
            source.imgRouge.Source = ManipImage.transformerExposition(source.BitmapOrigine, +25);
            source.imgVert.Source = ManipImage.transformerExposition(source.BitmapOrigine, +50);
            source.imgBleu.Source = ManipImage.transformerExposition(source.BitmapOrigine, +75);
        }
    }
}
