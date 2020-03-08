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
        private bool isFull = false;
        private bool read = false;
        private string last;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string num = button.Content.ToString();
            if (read == false)
            {
                if (memory.Text.Length != 0 && memory.Text.Last() == '=')
                {
                    memory.Text = "";
                }
                input.Text = num;
                read = true;
            }
            else
            {
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
            }
            Logic.Resize(input);
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Logic.DoMath(input, memory, btn.Content.ToString().First(), ref isFull, ref read, ref last);
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Logic.DoMath(input, memory, '=', ref isFull, ref read, ref last);
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (!input.Text.Equals("0") && input.Text.Length < 21)
            {
                input.Text += '0';
                Logic.Resize(input);
                read = true;
            }
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (read != false)
            {
                if (!input.Text.Equals("0"))
                {
                    if ((input.Text.Length == 2 && Decimal.Parse(input.Text) < 0) || input.Text.Length == 1)
                    {
                        input.Text = "0";
                    }
                    else
                    {
                        input.Text = input.Text.Remove(input.Text.Length - 1, 1);
                    }
                }
            }
            else
            {
                if (memory.Text.Length != 0)
                {
                    memory.Text = "";
                }
            }
            Logic.Resize(input);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            input.Text = "0";
            read = true;
            Logic.Resize(input);
        }
        
        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            input.Text = "0";
            memory.Text = "";
            read = false;
            Logic.Resize(input);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (!(Keyboard.IsKeyDown(Key.RightShift) || Keyboard.IsKeyDown(Key.LeftShift)))
            {
                if (e.Key == Key.D1 || e.Key == Key.NumPad1)
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
                else if (e.Key == Key.OemComma || e.Key == Key.OemPeriod)
                {
                    Logic.PerformClick(point);
                }
                else if (e.Key == Key.OemMinus)
                {
                    Logic.PerformClick(minus);
                }
                else if (e.Key == Key.Enter || e.Key == Key.OemPlus)
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
            else
            {
                if (e.Key == Key.OemPlus)
                {
                    Logic.PerformClick(add);
                }
            }
        }

        private void Negation_Click(object sender, RoutedEventArgs e)
        {
            if (Decimal.Parse(input.Text) != 0)
            {
                if (Decimal.Parse(input.Text) < 0)
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
            read = true;
            Logic.Resize(input);
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            if (!input.Text.Contains(',') && input.Text.Length < 21)
            {
                input.Text += ',';
                Logic.Resize(input);
                read = true;
            }
        }

        private void Block_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
