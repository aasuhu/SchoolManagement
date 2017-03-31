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
    /// Interaction logic for RegisterStudentInSubject.xaml
    /// </summary>
    public partial class RegisterStudentInSubject : UserControl
    {
        private Student s;

        public RegisterStudentInSubject(Student s)
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
            lblStudent.Content = String.Format("{0} : {1} {2} ", s.StudentID, s.FirstName, s.LastName);
            comboBox.ItemsSource = Helper.dc.Subjects.ToList();
            comboBox.DisplayMemberPath = "SubjectName";
                }

        private void btnSaveRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.StudentID = s.StudentID;
            reg.SubjectID = ((Subject)comboBox.SelectedItem).SubjectID;
            reg.Status = "P";
            reg.Grade = 16;

            Helper.addRegistration(reg);
            
            (Parent as ContentControl).Content = new ViewStudents();
        }
    }
}
