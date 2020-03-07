using System;
using System.IO;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
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

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.OpenOrCreate, storage);

            StreamWriter streamWriter = new StreamWriter(userStream);
            streamWriter.WriteLine(ColorPicker.SelectedColor);
            streamWriter.Close();
            userStream.Close();
            MessageBox.Show("Color saved", "INFO");

        }

        private void IsLoaded(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.OpenOrCreate, storage);

            StreamReader reader = new StreamReader(userStream);
            string color = reader.ReadToEnd();
            reader.Close();
            userStream.Close();

            BrushConverter brushConverter = new BrushConverter();

            if (!string.IsNullOrEmpty(color))
            {
                Label.Background = (Brush)brushConverter.ConvertFromString(color);
            }


        }

        private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Label.Content = ColorPicker.SelectedColorText;

            var bc = new BrushConverter();
            Label.Background = (Brush)bc.ConvertFromString(ColorPicker.SelectedColor.ToString());
        }
    }
}
