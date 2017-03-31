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
    /// Interaction logic for ViewStudentRegistrations.xaml
    /// </summary>
    public partial class ViewStudentRegistrations : UserControl
    {
        Student s;
        public ViewStudentRegistrations(Student s)
        {
            InitializeComponent();
            this.s = s;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            (Parent as ContentControl).Content = new ViewStudents();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            lblID.Content = s.StudentID.ToString();
            lblIFullName.Content = s.FirstName + " " + s.LastName;
            var q = (from r in Helper.dc.Registrations
                     where r.StudentID == s.StudentID
                     select new
                     {
                         RegistrationID = r.RegistrationID,
                         SubjectID = r.SubjectID,
                         SubjectName = r.Subject.SubjectName,
                         Grade = r.Grade,
                         Status = r.Status
                     }).ToList();

            DataGrid.ItemsSource = q;
        }
    }
}
