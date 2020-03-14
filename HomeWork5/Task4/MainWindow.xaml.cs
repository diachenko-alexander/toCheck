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

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Settings settings;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            TextSizeBox.ItemsSource = new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            StyleBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(x => x.Source);
            settings = new Settings();
            FillSettings();

        }


        private void ComboBox_TextSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock.FontSize = Convert.ToInt32(TextSizeBox.SelectedItem);
        }

        private void ComboBox_Style_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock.FontFamily = StyleBox.SelectedItem as FontFamily;
        }

        private void cp_SelectedTextColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var bc = new BrushConverter();
            TextBlock.Foreground = (Brush)bc.ConvertFromString(ColorPickerTextColor.SelectedColor.ToString());
        }

        private void cp_SelectedBackColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var bc = new BrushConverter();
            TextBlock.Background = (Brush)bc.ConvertFromString(ColorPickerBackgroundColor.SelectedColor.ToString());
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            settings.BackColor = TextBlock.Background;
            settings.TextColor = TextBlock.Foreground;
            settings.TextSize = (int)TextBlock.FontSize;
            settings.TextFont = TextBlock.FontFamily;

            settings.SaveSettings();
        }

        private void FillSettings()
        {
            TextBlock.Background = settings.BackColor;
            TextBlock.Foreground = settings.TextColor;
            TextBlock.FontSize = settings.TextSize;
            TextBlock.FontFamily = settings.TextFont;
        }
    }
}
