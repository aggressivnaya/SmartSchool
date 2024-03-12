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

    public enum Mode { None, Update, Insert };

    /// <summary>
    /// Interaction logic for StudentList_Page1.xaml
    /// </summary>
    public partial class StudentList_Page1 : Page
    {
        
        private List<Student> lst = new List<Student>();
        private Student usr;  // "עצם "בטיפול
        private ServiceClient srv = new ServiceClient();

        private Mode mode;

        public StudentList_Page1()
        {
            InitializeComponent();
            //lst.Add(srv.GetUser1());
            //lst.Add(srv.GetUser2());
            this.lstView.ItemsSource = lst;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigating += NavigationService_Navigating;
        }


        private void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                if (mode == Mode.Insert)  //insert Mode
                {
                    this.lst.Add(usr);
                }
                if (mode == Mode.Update)
                {
                    // .....   לא צריך לעשות כלום, כרגע, כי זה אותו העצם
                }


                //this.lstView.ItemsSource = null;  // force refresh
                //this.lstView.ItemsSource = list;
                RefreshUserList();

                mode = Mode.None;
            }
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            Student usr = new Student();            // נשתמש במשתנה גלובלי
            mode = Mode.Insert;

            // בו הדף הזה נמצא, שבו השתמשו כדי לנווט לפה Frame-מביא את ה
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new StudentPage1(usr));  // נשלח את המשתמש החדש כפרמטר לבנאי של הדף
        }

        private void LstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usr = this.lstView.SelectedItem as Student;   // קבלה של העצם שנבחר מהרשימה
        }

        private void MenuItem_Upd(object sender, RoutedEventArgs e)
        {
            //usr = this.lstView.SelectedItem as User;   // LstView_SelectionChanged-מתבצע ב
            mode = Mode.Update;

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new StudentPage1(usr));   // נשלח את המשתמש שנבחר כפרמטר לבנאי של הדף
        }


        private void MenuItem_Del(object sender, RoutedEventArgs e)
        {
            //usr = this.lstView.SelectedItem as User;

            this.lst.Remove(usr);

            //this.lstView.ItemsSource = null;  // force refresh
            //this.lstView.ItemsSource = lst;
            RefreshUserList();
        }

        private void RefreshUserList()
        {
            this.lstView.ItemsSource = null;  // force refresh
            this.lstView.ItemsSource = lst;
        }

       
    }
}
