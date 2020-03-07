using System;
using System.Collections.Generic;
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
            if (sender.Text.Length > 13)
            {
                sender.FontSize = 23;
            }
            else
            {
                sender.FontSize = 35;
            }
        }
        public static void PerformClick(this Button btn)
        {
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }
}
