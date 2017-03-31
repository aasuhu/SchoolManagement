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
    /// Interaction logic for ViewSubjects.xaml
    /// </summary>
    public partial class ViewSubjects : UserControl
    {
        public ViewSubjects()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<Subject> AllSubjects = Helper.dc.Subjects.ToList();
            dataGrid.ItemsSource = AllSubjects;
        }

        private void cm_Edit_Click(object sender, RoutedEventArgs e)
        {
            Subject s =(Subject) dataGrid.SelectedItem;
            (Parent as ContentControl).Content = new UpdateSubject(s);
        }

        private void cm_Delete_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure to delete this Subject ?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Subject s = (Subject)dataGrid.SelectedItem;
                if (Helper.dc.Registrations.Where(r => r.SubjectID == s.SubjectID).FirstOrDefault() != null)
                    Helper.DeleteSubject(s);
                else
                    MessageBox.Show("Can not delete a subject that has students");
            }
        }

     

        private void cm_ViewRegSts_Click(object sender, RoutedEventArgs e)
        {
            (Parent as ContentControl).Content = new ViewSubjectRegistrations((Subject)dataGrid.SelectedItem);
        }
    }
}
