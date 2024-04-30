using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProductBridge.Services
{
    class NavigationService
    {
        public static void NavigateToWindow(Window window)
        {
            window.Show();
        }

        public static void CloseWindow(Window window)
        {
            window.Close();
        }

        public static void NavigateToView(UserControl view)
        {
            
        }


    }
}
