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
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : UserControl
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private bool AreAllInformationsInserted()
        {
            if(string.IsNullOrEmpty(txtFirstName.Text.Trim())|| string.IsNullOrEmpty(txtLastName.Text.Trim()) 
                || (rdbFemale.IsChecked == false && rdbMale.IsChecked==false))

                return false;
            return true;
        }

        private void btnSavaStudent_Click(object sender, RoutedEventArgs e)
        {

            if (AreAllInformationsInserted())
            {
                Student s = new Student();
                s.FirstName = txtFirstName.Text;
                s.LastName = txtLastName.Text;
                if (rdbMale.IsChecked == true)
                    s.Gender = "M";
                else
                    s.Gender = "F";

                Helper.AddStudent(s);
                (Parent as ContentControl).Content = new ViewStudents();
            }
            else
            {
                MessageBox.Show("Please provide all informations","Incomplete informations", MessageBoxButton.OK, MessageBoxImage.Error);
            }


           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            (Parent as ContentControl).Content = new ViewStudents();
        }
    }
}
