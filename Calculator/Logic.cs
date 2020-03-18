using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    static class Logic
    {
        public static void Resize(TextBox sender)
        {
            if (sender.Text.Length >= 22)
            {
                sender.FontSize = 16;
            }
            else if (sender.Text.Length > 13 && sender.Text.Length < 22)
            {
                sender.FontSize = 23;
            }
            else
            {
                sender.FontSize = 35;
            }
        }
        public static void PerformClick(Button btn)
        {
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        public static void DoMath(TextBox input, TextBox output, char action, ref bool error, ref bool read, ref string last)
        {
            string _in = input.Text;
            string _out = output.Text;
            if (_in.EndsWith(","))
            {
                _in = _in.Replace(",", "");
                input.Text = _in;
            }
            if (action != '=')
            {
                if (_out.Length == 0)
                {
                    output.Text = _in + ' ' + action;
                    read = false;
                }
                else
                {
                    if ((_out.EndsWith("+") || _out.EndsWith("/") || _out.EndsWith("-") || _out.EndsWith("*")) && read == false)
                    {
                        output.Text = _out.Remove(_out.Length - 1, 1) + action;
                    }
                    else if (_out.EndsWith("="))
                    {
                        output.Text = _in + ' ' + action;
                    }
                    else
                    {
                        output.Text = _out + ' ' + _in  + ' ' + action;
                        input.Text = Logic.Calculate(_out + ' ' + _in, ref error);
                        read = false;
                    }
                }
            }
            else
            {
                if (_out.Length == 0)
                {
                    output.Text = _in + " =";
                }
                else
                {
                    if (_out.Last() == '=')
                    {
                        output.Text = _in + last + " =";
                        input.Text = Logic.Calculate(_in + last, ref error);
                    }
                    else
                    {
                        last = ' '+ _out.Last().ToString() + ' ' + _in;
                        input.Text = Logic.Calculate(_out + ' ' + _in, ref error);
                        output.Text = _out + ' ' + _in + " =";
                    }
                }
                read = false;
            }
            output.Select(output.Text.Length, 0);
            output.Focus();
        }

        private static string Calculate(string calc, ref bool error)
        {
            try
            {
                List<string> elements = calc.Split(' ').ToList();
                int index;
                double tmp;
                while (elements.Count() > 1)
                {
                    if (elements.Contains("/") || elements.Contains("*"))
                    {
                        index = elements.FindIndex(x => x == "/" || x == "*");
                    }
                    else
                    {
                        index = elements.FindIndex(x => x == "+" || x == "-");
                    }
                    if (elements[index] == "/")
                    {
                        tmp = Double.Parse(elements[index - 1].Replace(',', '.'), CultureInfo.InvariantCulture) / Double.Parse(elements[index + 1].Replace(',', '.'), CultureInfo.InvariantCulture);
                    }
                    else if (elements[index] == "*")
                    {
                        tmp = Double.Parse(elements[index - 1].Replace(',', '.'), CultureInfo.InvariantCulture) * Double.Parse(elements[index + 1].Replace(',', '.'), CultureInfo.InvariantCulture);
                    }
                    else if (elements[index] == "+")
                    {
                        tmp = Double.Parse(elements[index - 1].Replace(',', '.'), CultureInfo.InvariantCulture) + Double.Parse(elements[index + 1].Replace(',', '.'), CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        tmp = Double.Parse(elements[index - 1].Replace(',', '.'), CultureInfo.InvariantCulture) - Double.Parse(elements[index + 1].Replace(',', '.'), CultureInfo.InvariantCulture);
                    }
                    elements[index] = Math.Round(tmp, 12).ToString().Replace('.', ',');
                    elements.RemoveAt(index + 1);
                    elements.RemoveAt(index - 1);
                }

                return elements[0];
            }
            catch
            {
                error = true;
                return "Error";
            }
        }
    }
}
