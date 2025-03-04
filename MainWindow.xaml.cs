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

namespace WpfApp1RomRom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void EyeFocusButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ((RadialGradientBrush)LabelEE.Background).GradientOrigin = new Point(0.3, 0.5);
        //    ((RadialGradientBrush)LabelWW.Background).GradientOrigin = new Point(0.7, 0.5);
        //    ((RadialGradientBrush)LabelSS.Background).GradientOrigin = new Point(0.5, 0.3);
        //    ((RadialGradientBrush)LabelNN.Background).GradientOrigin = new Point(0.5, 0.7);
        //}

        private void FontFamilyButton_Click(object sender, RoutedEventArgs e)
        {
            OutText.FontFamily = ((Button)sender).FontFamily;
            if (FontFamily.Source != "GothicE")
            {
                OutText.Padding = new Thickness(0, 5, 0, 0);
            }
        }

        private void FontStyleButton_Click(object sender, RoutedEventArgs e)
        {
            OutText.FontStyle = ((Button)sender).FontStyle;
        }

        private void FontWeightButton_Click(object sender, RoutedEventArgs e)
        {
            OutText.FontWeight = ((Button)sender).FontWeight;
        }

        private void TextSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OutText.FontSize = ((Slider)sender).Value;
            if (SliderValue != null)
                SliderValue.Text = ((Slider)sender).Value.ToString();
        }

        private void BackgroundSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MyShowBord.Background = new SolidColorBrush(Color.FromArgb((byte)((int)SliderA.Value), (byte)((int)SliderR.Value), (byte)((int)SliderG.Value), (byte)((int)SliderB.Value)));
            switch (((Slider)sender).Name)
            {
                case "SliderA":
                    SlACount.Content = SliderA.Value;
                    break;
                case "SliderB":
                    SlBCount.Content = SliderB.Value;
                    break;
                case "SliderG":
                    SlGCount.Content = SliderG.Value;
                    break;
                case "SliderR":
                    SlRCount.Content = SliderR.Value;
                    break;
                default:
                    break;
            }
            HexColorBox.Text = $"#{((SolidColorBrush)MyShowBord.Background).Color.A:X2}{((SolidColorBrush)MyShowBord.Background).Color.R:X2}{((SolidColorBrush)MyShowBord.Background).Color.G:X2}{((SolidColorBrush)MyShowBord.Background).Color.B:X2}";
        }

        private void AddHexColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (HexColorBox.Text.First() != '#')
            {
                HexColorBox.Text = "";
                return;
            }
            if (HexColorBox.Text.Length > 9 || HexColorBox.Text.Length < 6)
            {
                HexColorBox.Text = "error";
                return;
            }
            MyShowBord.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(HexColorBox.Text));
            HexColorBox.Text = $"#{((SolidColorBrush)MyShowBord.Background).Color.A:X2}{((SolidColorBrush)MyShowBord.Background).Color.R:X2}{((SolidColorBrush)MyShowBord.Background).Color.G:X2}{((SolidColorBrush)MyShowBord.Background).Color.B:X2}";

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyShowBord.Background = (((ColorBox.SelectedItem as ComboBoxItem).Content as Grid).Children[0] as Label).Background;
            HexColorBox.Text = $"#{((SolidColorBrush)MyShowBord.Background).Color.A:X2}{((SolidColorBrush)MyShowBord.Background).Color.R:X2}{((SolidColorBrush)MyShowBord.Background).Color.G:X2}{((SolidColorBrush)MyShowBord.Background).Color.B:X2}";
        }

        private void ForegroungSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OutText.Foreground = new SolidColorBrush((Color.FromArgb((byte)((int)SliderA2.Value), (byte)((int)SliderR2.Value), (byte)((int)SliderG2.Value), (byte)((int)SliderB2.Value))));
            switch (((Slider)sender).Name)
            {
                case "SliderA2":
                    SlA2Count.Content = SliderA2.Value;
                    break;
                case "SliderB2":
                    SlB2Count.Content = SliderB2.Value;
                    break;
                case "SliderG2":
                    SlG2Count.Content = SliderG2.Value;
                    break;
                case "SliderR2":
                    SlR2Count.Content = SliderR2.Value;
                    break;
                default:
                    break;
            }
        }
    }
}

