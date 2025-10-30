using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab_rab2_ImamovaAR_BPI_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplyTheme("LightTheme.xaml");
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = false;
                return;
            }

            TextBox textBox = sender as TextBox;

            if (e.Text == "." || e.Text == ",")
            {
                if (textBox.Text.Contains(".") || textBox.Text.Contains(","))
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
                return;
            }

            if (e.Text == "-")
            {
                if (textBox.SelectionStart == 0 && !textBox.Text.Contains("-"))
                {
                    e.Handled = false;
                    return;
                }
                e.Handled = true;
                return;
            }

            e.Handled = true;
        }

        private void TextBox_PreviewOnlyDigits(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
        private void Input_GotFocus1(object sender, RoutedEventArgs e) { Radio1.IsChecked = true; }
        private void Input_GotFocus2(object sender, RoutedEventArgs e) { Radio2.IsChecked = true; }
        private void Input_GotFocus3(object sender, RoutedEventArgs e) { Radio3.IsChecked = true; }
        private void Input_GotFocus4(object sender, RoutedEventArgs e) { Radio4.IsChecked = true; }
        private void Input_GotFocus5(object sender, RoutedEventArgs e) { Radio5.IsChecked = true; }


        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            double result = 0.0;
            HideAllResults();

            try
            {
                if (Radio1.IsChecked.GetValueOrDefault())
                {
                    double a = Convert.ToDouble(R1TextA.Text);
                    double f = Convert.ToDouble(((ComboBoxItem)R1ComboF.SelectedItem).Content);
                    Formula1 calculator = new Formula1(a, f);
                    result = calculator.Calculate();
                    ResultText1.Text = $"Результат: {result:F}";
                    ResultText1.Visibility = Visibility.Visible;
                }
                else if (Radio2.IsChecked.GetValueOrDefault())
                {
                    double a = Convert.ToDouble(R2TextA.Text);
                    double b = Convert.ToDouble(R2TextB.Text);
                    double f = Convert.ToDouble(((ComboBoxItem)R2ComboF.SelectedItem).Content);
                    Formula2 calculator = new Formula2(a, b, f);
                    result = calculator.Calculate();
                    ResultText2.Text = $"Результат: {result:F}";
                    ResultText2.Visibility = Visibility.Visible;
                }
                else if (Radio3.IsChecked.GetValueOrDefault())
                {
                    double a = Convert.ToDouble(R3TextA.Text);
                    double b = Convert.ToDouble(R3TextB.Text);
                    double c = Convert.ToDouble(((ComboBoxItem)R3ComboC.SelectedItem).Content);
                    double d = Convert.ToDouble(((ComboBoxItem)R3ComboD.SelectedItem).Content);
                    Formula3 calculator = new Formula3(a, b, c, d);
                    result = calculator.Calculate();
                    ResultText3.Text = $"Результат: {result:F}";
                    ResultText3.Visibility = Visibility.Visible;
                }
                else if (Radio4.IsChecked.GetValueOrDefault())
                {
                    double a = Convert.ToDouble(R4TextA.Text);
                    int d = Int32.Parse(R4TextD.Text);
                    double c = Convert.ToDouble(((ComboBoxItem)R4ComboC.SelectedItem).Content);
                    Formula4 calculator = new Formula4(a, d, c);
                    result = calculator.Calculate();
                    ResultText4.Text = $"Результат: {result:F}";
                    ResultText4.Visibility = Visibility.Visible;
                }
                else if (Radio5.IsChecked.GetValueOrDefault())
                {
                    int n;
                    int k;

                    if (!Int32.TryParse(R5TextN.Text, out n) || !Int32.TryParse(R5TextK.Text, out k))
                    {
                        MessageBox.Show("N и K должны быть целыми числами.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (n < 1 || k < 1)
                    {
                        MessageBox.Show("Для Формулы 5 параметры N и K должны быть целыми числами не меньше 1 (N ≥ 1 и K ≥ 1).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    double p = Convert.ToDouble(R5TextP.Text);
                    double x = Convert.ToDouble(R5TextX.Text);
                    double f = Convert.ToDouble(R5TextF.Text);
                    double y = Convert.ToDouble(R5TextY.Text);

                    Formula5 calculator = new Formula5(n, k, p, x, f, y);
                    result = calculator.Calculate();
                    ResultText5.Text = $"Результат: {result:F}";
                    ResultText5.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите одну из формул для расчета.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода: Убедитесь, что все поля заполнены корректными числами.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HideAllResults()
        {
            ResultText1.Visibility = Visibility.Collapsed;
            ResultText2.Visibility = Visibility.Collapsed;
            ResultText3.Visibility = Visibility.Collapsed;
            ResultText4.Visibility = Visibility.Collapsed;
            ResultText5.Visibility = Visibility.Collapsed;
        }
        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            Button themeButton = sender as Button;
            if (themeButton == null) return;
            string themeUri = themeButton.Tag.ToString();
            ApplyTheme(themeUri);
        }

        private void ApplyTheme(string themeUri)
        {
            ResourceDictionary newTheme = new ResourceDictionary()
            {
                Source = new Uri(themeUri, UriKind.Relative)
            };

            var dictionaries = this.Resources.MergedDictionaries;
            var oldTheme = dictionaries.FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Theme.xaml"));
            if (oldTheme != null)
            {
                dictionaries.Remove(oldTheme);
            }
            dictionaries.Add(newTheme);
            if (this.Resources.Contains("WindowBackgroundBrush"))
            {
                this.Background = (Brush)this.Resources["WindowBackgroundBrush"];
            }
        }
        

        private void R1TextA_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}