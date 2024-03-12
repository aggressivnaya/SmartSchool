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
    /// Interaction logic for StudentList_Page2.xaml
    /// </summary>
    public partial class StudentList_Page2 : Page
    {
        
        private List<Student> lst = new List<Student>();
        private Student usr;
        private ServiceClient srv = new ServiceClient();


        public StudentList_Page2()
        {
            InitializeComponent();

            lst.Add((Student)srv.GetUser1());
            lst.Add((Student)srv.GetUser2());
            this.lstView.ItemsSource = lst;
        }

       
        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
       //     /*User*/  usr = new User();            // נעביר את יצירת העצם לדף שמטפל ביצירה + מילוי הפרטים
 
            // בו הדף הזה נמצא, שבו השתמשו כדי לנווט לפה Frame-מביא את ה
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new StudentPage2(afterAdd));  //נשלח את פעולת ההמשך כפרמטר לבנאי
        }

        private void afterAdd(object sender, EventArgs e)  // פעולת המשך
        {
            usr = sender as Student; // החדש usr נקבל את העצם 
            this.lst.Add(usr);    // ונוסיף אותו לרשימה

            //this.lstView.ItemsSource = null;  // force refresh
            //this.lstView.ItemsSource = list;
            RefreshUserList();
        }


        private void LstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usr = this.lstView.SelectedItem as Student;   // קבלה של העצם שנבחר מהרשימה
        }

        private void MenuItem_Upd(object sender, RoutedEventArgs e)
        {
            //usr = this.lstView.SelectedItem as User;   // LstView_SelectionChanged-מתבצע ב

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new StudentPage2(usr));  // נשלח את עצם שנבחר כפרמטר לבנאי
        }


        private void MenuItem_Del(object sender, RoutedEventArgs e)
        {
            //usr = this.lstView.SelectedItem as User;      // LstView_SelectionChanged-מתבצע ב

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
