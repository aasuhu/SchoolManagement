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
    /// Interaction logic for ViewSubjectRegistrations.xaml
    /// </summary>
    public partial class ViewSubjectRegistrations : UserControl
    {
        Subject sb;
        public ViewSubjectRegistrations(Subject sb)
        {
            InitializeComponent();
            this.sb = sb;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            (Parent as ContentControl).Content = new ViewSubjects();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(sb != null)
            {
                lblID.Content = sb.SubjectID.ToString();
                lblIName.Content = sb.SubjectName;
                lblIDesc.Content = sb.SubjectDescription;

                var q = (from r in Helper.dc.Registrations
                         where r.SubjectID == sb.SubjectID
                         select new
                         {
                             RegistrationID = r.RegistrationID,
                             StudentID = r.StudentID,
                             StudentName = r.Student.FirstName + " " + r.Student.LastName,
                             Grade = r.Grade,
                             Status = r.Status
                         }).ToList();

                DataGrid.ItemsSource = q;

                            
            }
        }
    }
}
