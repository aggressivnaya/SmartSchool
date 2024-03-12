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
    /// Interaction logic for StudentPage2.xaml
    /// </summary>
    public partial class StudentPage2 : Page
    {
        private ServiceClient srv = new ServiceClient();
        private Student usr;
        private CityList cityLst;

        private event EventHandler afterAdd;
        public StudentPage2()  // מומלץ להשאיר תמיד את בנאי ברירת מחדל
        {
            InitializeComponent();

            cityLst = srv.GetAllCity();  // ממלא את רשימת הערים בדף
            this.CityCbox.ItemsSource = cityLst;
        }
        public StudentPage2(EventHandler afterAdd):this()
        {
            // מתבצע בבנאי ברירת מחדל
            //InitializeComponent();

            //cityLst = srv.GetAllCity();  // ממלא את רשימת הערים בדף
            //this.CityCbox.ItemsSource = cityLst;

            this.usr = new Student();  // יצירת משתמש (עצם) חדש
            this.DataContext = usr;

            this.afterAdd = afterAdd;
        }

        public StudentPage2(Student usr) : this()
        {
            // מתבצע בבנאי ברירת מחדל
            //InitializeComponent();

            //cityLst = srv.GetAllCity();  // ממלא את רשימת הערים בדף
            //this.CityCbox.ItemsSource = cityLst;
            
            this.usr = usr;

            if (usr.City != null) // אם מדובר במשתמש קיים
            {
                // .המתאים, כדי שיוצג כעיר שנבחרה city את המשתנה   usr שם במשתנה 
                usr.City = cityLst.Find(c => c.Id == usr.City.Id);
            }

            this.DataContext = usr;
        }

        

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.afterAdd != null)
                afterAdd(this.usr, null);


            //NavigationService nav = NavigationService.GetNavigationService(this);
            //if (nav.CanGoBack)
            //    nav.GoBack();
            UpdButton_Click(null, null);  // go back to calling page
        }

        private void UpdButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            if (nav.CanGoBack)
                nav.GoBack();
        }
    }
}
