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

namespace SmartSchool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;   //hide the Frame Navigation
                                                                              // XAML-אפשר גם ישירות מקובץ ה
        }

        private void HamburgerMenuItem_Selected_3(object sender, RoutedEventArgs e)
        {
            if (myFrame.NavigationService.CanGoBack)
                myFrame.NavigationService.GoBack();
        }

        private void HamburgerMenuItem_Selected_4(object sender, RoutedEventArgs e)
        {

            if (myFrame.NavigationService.CanGoForward)
                myFrame.NavigationService.GoForward();

        }
        private void HomeItem_Selected(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new HomePage());   // Frame-דיפדוף תוך שימוש ישיר בשם ה
        }

        private void Item1_Selected(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new StudentList_Page1());
        }

        private void Item2_Selected(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new StudentList_Page2());
        }
    }
}
