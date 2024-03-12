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
using Model;
using ViewModel;
using ViewModell;

namespace SmartSchool
{
    /// <summary>
    /// Interaction logic for StudentPage1.xaml
    /// </summary>
    public partial class StudentPage1 : Page
    {
        private ServiceClient srv = new ServiceClient();
        private Student usr;
        private CityList cityLst;
        public StudentPage1()
        {
            InitializeComponent();
            cityLst = srv.GetAllCity();  // ממלא את רשימת הערים בדף
            this.CityCbox.ItemsSource = cityLst;
        }

        public StudentPage1(Student usr):this()
        {
            // מתבצע בבנאי ברירת מחדל
            //InitializeComponent();
            //cityLst = srv.GetAllCity();  // ממלא את רשימת הערים בדף
            //this.CityCbox.ItemsSource = cityLst;

            this.usr = usr;

            if (usr.City != null) // אם מדובר במשתמש קיים
            {
                // .המתאים, כדי שיוצג כעיר שנבחרה city את המשתנה usr שם במשתנה 
                usr.City = cityLst.Find(c => c.Id == usr.City.Id);
            }

            this.DataContext = usr;
        }

        

        private void BackButton_Click(object sender, RoutedEventArgs e)  // כפתור זהה להוספה ולעדכון
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            if (nav.CanGoBack)
                nav.GoBack();
        }


    }
}
