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
    /// Interaction logic for UpdateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : UserControl
    {
        private Student s;
        public UpdateStudent(Student s)
        {
            InitializeComponent();
            this.s = s;
        }
        private bool AreAllInformationsInserted()
        {
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()) || string.IsNullOrEmpty(txtLastName.Text.Trim())
                || (rdbFemale.IsChecked == false && rdbMale.IsChecked == false))

                return false;
            return true;
        }

        private void btnSavaStudent_Click(object sender, RoutedEventArgs e)
        {

            if (AreAllInformationsInserted())
            {
                s.FirstName = txtFirstName.Text;
                s.LastName = txtLastName.Text;
                if (rdbMale.IsChecked == true)
                    s.Gender = "M";
                else
                    s.Gender = "F";

                Helper.UpdateStudent(s);
                (Parent as ContentControl).Content = new ViewStudents();
            }
            else
            {
                MessageBox.Show("Please provide all informations", "Incomplete informations", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            (Parent as ContentControl).Content = new ViewStudents();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(s != null)
            {
                lblID.Content = s.StudentID.ToString();
                txtFirstName.Text = s.FirstName;
                txtLastName.Text = s.LastName;
                if (s.Gender == "M")
                    rdbMale.IsChecked = true;
                else
                    rdbFemale.IsChecked = true;

            }

        }
    }
}
