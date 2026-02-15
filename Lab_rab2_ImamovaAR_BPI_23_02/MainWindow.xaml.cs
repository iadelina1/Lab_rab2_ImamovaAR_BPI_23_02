using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab_rab2_ImamovaAR_BPI_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                var culture = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");

                if (Radio1.IsChecked.GetValueOrDefault())
                {
                    double a = double.Parse(R1TextA.Text, culture);
                    double f = double.Parse(((ComboBoxItem)R1ComboF.SelectedItem).Content.ToString(), culture);

                    Formula1 f1 = new Formula1(a, f);
                    result = f1.Calculate();

                    ResultText1.Text = $"Результат: {result:F4}";
                    ResultText1.Visibility = Visibility.Visible;
                }
                else if (Radio2.IsChecked.GetValueOrDefault())
                {
                    double a = double.Parse(R2TextA.Text, culture);
                    double b = double.Parse(R2TextB.Text, culture);
                    double f = double.Parse(((ComboBoxItem)R2ComboF.SelectedItem).Content.ToString(), culture);

                    Formula2 f2 = new Formula2(a, b, f);
                    result = f2.Calculate();

                    ResultText2.Text = $"Результат: {result:F4}";
                    ResultText2.Visibility = Visibility.Visible;
                }
                else if (Radio3.IsChecked.GetValueOrDefault())
                {
                    double a = double.Parse(R3TextA.Text, culture);
                    double b = double.Parse(R3TextB.Text, culture);
                    double c = double.Parse(((ComboBoxItem)R3ComboC.SelectedItem).Content.ToString(), culture);
                    double d = double.Parse(((ComboBoxItem)R3ComboD.SelectedItem).Content.ToString(), culture);

                    Formula3 f3 = new Formula3(a, b, c, d);
                    result = f3.Calculate();

                    ResultText3.Text = $"Результат: {result:F4}";
                    ResultText3.Visibility = Visibility.Visible;
                }
                else if (Radio4.IsChecked.GetValueOrDefault())
                {
                    double a = double.Parse(R4TextA.Text, culture);
                    double d_raw = double.Parse(R4TextD.Text, culture);
                    double c = double.Parse(((ComboBoxItem)R4ComboC.SelectedItem).Content.ToString(), culture);

                    Formula4 f4 = new Formula4(a, (int)d_raw, c);
                    result = f4.Calculate();

                    ResultText4.Text = $"Результат: {result:F4}";
                    ResultText4.Visibility = Visibility.Visible;
                }
            
                else if (Radio5.IsChecked.GetValueOrDefault())
                {
                    int n = int.Parse(R5TextN.Text);
                    int k = int.Parse(R5TextK.Text);
                    double f = double.Parse(R5TextF.Text, culture);
                    double p = double.Parse(R5TextP.Text, culture);
                    double x = double.Parse(R5TextX.Text, culture);
                    double y = double.Parse(R5TextY.Text, culture);

                    Formula5 f5 = new Formula5(n, k, f, p, x, y);
                    result = f5.Calculate();

                    ResultText5.Text = $"Результат: {result:F4}";
                    ResultText5.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
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
            if (themeButton == null || themeButton.Tag == null) return;

            string themeFile = themeButton.Tag.ToString();

            try
            {
                ResourceDictionary newTheme = new ResourceDictionary();
                newTheme.Source = new Uri(themeFile, UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(newTheme);
                this.Resources.MergedDictionaries.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки темы: {ex.Message}");
            }
        }
    }
}