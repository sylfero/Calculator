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

namespace Calculator
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

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string num = button.Content.ToString();
            if (input.Text.Equals("0"))
            {
                input.Text = num;
            }
            else
            {
                if (input.Text.Length < 21)
                {
                    input.Text += num;
                }
            }
            Logic.Resize(input);
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (!input.Text.Equals("0"))
            {
                if ((input.Text.Length == 2 && Double.Parse(input.Text) < 0) || input.Text.Length == 1)
                {
                    input.Text = "0";
                }
                else
                {

                    input.Text = input.Text.Remove(input.Text.Length - 1, 1);
                }
            }
            Logic.Resize(input);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            input.Text = "0";
            Logic.Resize(input);
        }
        
        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            input.Text = "0";
            memory.Text = "";
            Logic.Resize(input);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.D1 || e.Key == Key.NumPad1)
            {
                Logic.PerformClick(one);
            }
            else if (e.Key == Key.D2 || e.Key == Key.NumPad2)
            {
                Logic.PerformClick(two);
            }
            else if (e.Key == Key.D3 || e.Key == Key.NumPad3)
            {
                Logic.PerformClick(three);
            }
            else if (e.Key == Key.D4 || e.Key == Key.NumPad4)
            {
                Logic.PerformClick(four);
            }
            else if (e.Key == Key.D5 || e.Key == Key.NumPad5)
            {
                Logic.PerformClick(five);
            }
            else if (e.Key == Key.D6 || e.Key == Key.NumPad6)
            {
                Logic.PerformClick(six);
            }
            else if (e.Key == Key.D7 || e.Key == Key.NumPad7)
            {
                Logic.PerformClick(seven);
            }
            else if (e.Key == Key.D8 || e.Key == Key.NumPad8)
            {
                Logic.PerformClick(eight);
            }
            else if (e.Key == Key.D9 || e.Key == Key.NumPad9)
            {
                Logic.PerformClick(nine);
            }
            else if (e.Key == Key.D0 || e.Key == Key.NumPad0)
            {
                Logic.PerformClick(zero);
            }
            else if (e.Key == Key.Back)
            {
                Logic.PerformClick(backspace);
            }
            else if (e.Key == Key.OemPlus)
            {
                Logic.PerformClick(add);
            }
            else if (e.Key == Key.OemComma || e.Key == Key.OemPeriod)
            {
                Logic.PerformClick(point);
            }
            else if (e.Key == Key.OemMinus)
            {
                Logic.PerformClick(minus);
            }
            else if (e.Key == Key.OemFinish)
            {
                Logic.PerformClick(equals);
            }
            else if (e.Key == Key.OemTilde)
            {
                Logic.PerformClick(divide);
            }
            else if (e.Key == Key.Multiply)
            {
                Logic.PerformClick(multiply);
            }
        }

        private void Negation_Click(object sender, RoutedEventArgs e)
        {
            if (!input.Text.Equals("0"))
            {
                if (Double.Parse(input.Text) < 0)
                {
                    input.Text = input.Text.Remove(0, 1);
                }
                else
                {
                    if (input.Text.Length < 21)
                    {
                        input.Text = '-' + input.Text;
                    }
                }
            }
            Logic.Resize(input);
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if (!input.Text.Contains(',') && input.Text.Length < 21)
            {
                input.Text += ',';
                Logic.Resize(input);
            }
        }
    }
}
