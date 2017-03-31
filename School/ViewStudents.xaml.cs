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

namespace School
{
    /// <summary>
    /// Interaction logic for ViewStudents.xaml
    /// </summary>
    public partial class ViewStudents : UserControl
    {
        public ViewStudents()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<Student> AllStudents = (from s in Helper.dc.Students select s).ToList() ;
            //List<Student> AllStudents = Helper.dc.Students.ToList();

            dataGrid.ItemsSource = AllStudents;

        }

        private void cm_EditStudent_Click(object sender, RoutedEventArgs e)
        {
            Student s = (Student)dataGrid.SelectedItem;
            (Parent as ContentControl).Content = new UpdateStudent(s);

        }

        private void cm_DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this student ?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Helper.DeleteStudent((Student)dataGrid.SelectedItem);
                this.UserControl_Loaded(sender, e);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cm_Register_Click(object sender, RoutedEventArgs e)
        {

            (Parent as ContentControl).Content = new RegisterStudentInSubject((Student)dataGrid.SelectedItem);
        }

        private void cm_ViewStRegs_Click(object sender, RoutedEventArgs e)
        {
            (Parent as ContentControl).Content = new ViewStudentRegistrations((Student)dataGrid.SelectedItem);
        }
    }
}
