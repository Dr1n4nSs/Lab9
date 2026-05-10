using System;
using System.Windows;
using System.Windows.Media;

namespace TriangleWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a1, b1, c1, a2, b2, c2;
                double perimeter, area;
                bool isLess, isGreater;
                bool isA1Parsed = double.TryParse(txtA1.Text, out a1);
                bool isB1Parsed = double.TryParse(txtB1.Text, out b1);
                bool isC1Parsed = double.TryParse(txtC1.Text, out c1);
                bool isA2Parsed = double.TryParse(txtA2.Text, out a2);
                bool isB2Parsed = double.TryParse(txtB2.Text, out b2);
                bool isC2Parsed = double.TryParse(txtC2.Text, out c2);

                if (!isA1Parsed || !isB1Parsed || !isC1Parsed || !isA2Parsed || !isB2Parsed || !isC2Parsed)
                {
                    MessageBox.Show("Введите корректные числа во все поля.");
                    return;
                }
                
                Triangle tri1 = new Triangle(a1, b1, c1);
                Triangle tri2 = new Triangle(a2, b2, c2);
                
                if (!(bool)tri1)
                {
                    lblResult11.Text = "Треугольник 1 не существует";
                    lblResult11.Foreground = Brushes.Red;
                    lblResult12.Text = " ";
                }
                else
                {
                    perimeter = tri1;
                    area = -tri1;
                    lblResult11.Text = "Периметр 1 треугольника = " + perimeter.ToString("F2");
                    lblResult11.Foreground = Brushes.Black;
                    lblResult12.Text = "Площадь 1 треугольника = " + area.ToString("F2");
                    lblResult12.Foreground = Brushes.Black;
                    
                }
                if (!(bool)tri2)
                {
                    lblResult21.Text = "Треугольник 2 не существует";
                    lblResult21.Foreground = Brushes.Red;
                    lblResult22.Text = " ";
                }
                else
                {
                    perimeter = tri2;
                    area = -tri2;
                    lblResult21.Text = "Периметр 2 треугольника = " + perimeter.ToString("F2");
                    lblResult21.Foreground = Brushes.Black;
                    lblResult22.Text = "Площадь 2 треугольника = " + area.ToString("F2");
                    lblResult22.Foreground = Brushes.Black;
                }

                if (!(bool)tri1 || !(bool)tri2)
                {
                    lblResult31.Text = "Треугольники нельзя сравнить ";
                    lblResult31.Foreground = Brushes.Red;
                }
                else
                {
                    isLess = tri1 < tri2;
                    isGreater = tri1 > tri2;
                    if (!isLess && !isGreater)
                    {
                        lblResult31.Text = "Треугольники равны ";
                        lblResult31.Foreground = Brushes.Black;
                    }
                    else
                    {
                        if (isLess)
                        {
                            lblResult31.Text = "Площадь треугольника 1 больше ";
                            lblResult31.Foreground = Brushes.Black;
                        }
                        else
                        {
                            lblResult31.Text = "Площадь треугольника 2 больше ";
                            lblResult31.Foreground = Brushes.Black;
                        }
                    }
                }
                
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
    }
}