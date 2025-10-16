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

namespace Lab_rab2_ImamovaAR_BPI_23_02
{
    public partial class MainWindow : Window
    {
        private Function function;

        public MainWindow()
        {
            InitializeComponent();
            function = new Function { Name = "DoubleSum" };
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double p = double.Parse(txtP.Text);
                double x = double.Parse(txtX.Text);
                double f = double.Parse(txtF.Text);
                double y = double.Parse(txtY.Text);
                int n = int.Parse(txtN.Text);
                int k = int.Parse(txtK.Text);

                if (n <= 0 || k <= 0)
                {
                    MessageBox.Show("N и K должны быть больше 0!");
                    return;
                }

                double result = function.Calculate(p, x, f, y, n, k);
                txtResult.Text = $"Результат: {result:F6}";
                this.Title = $"Z = {result:F6}";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}