using System;
using System.Windows;
using System.Windows.Controls;
using Lab_rab2_ImamovaAR_BPI_23_02;

namespace Lab_rab2_ImamovaAR_BPI_23_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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
                    int n = Int32.Parse(R5TextN.Text);
                    int k = Int32.Parse(R5TextK.Text);
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
    }
}