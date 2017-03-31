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
    /// Interaction logic for AddSubject.xaml
    /// </summary>
    public partial class AddSubject : UserControl
    {
        public AddSubject()
        {
            InitializeComponent(); ;
        }

        private bool AreAllInfosInserted()
        {
            if(string.IsNullOrEmpty(txtSubjectName.Text.Trim())|| string.IsNullOrEmpty(txtDescription.Text.Trim()) || string.IsNullOrEmpty(txtCredits.Text.Trim()))
                return false;
            return true;
        }
        private void btnSavaSubject_Click(object sender, RoutedEventArgs e)
        {
            if (AreAllInfosInserted())
            {
                Subject sb = new Subject();
                sb.SubjectName = txtSubjectName.Text;
                sb.SubjectDescription = txtDescription.Text;
                try
                {
                    sb.SubjectCredits = int.Parse(txtCredits.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter a valid number for credits");
                }

                Helper.AddSubject(sb);
                (Parent as ContentControl).Content = new ViewSubjects();
            }
        }
    }
}
