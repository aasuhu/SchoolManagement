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
    /// Interaction logic for UpdateSubject.xaml
    /// </summary>
    public partial class UpdateSubject : UserControl
    {
        private Subject sb;
        public UpdateSubject(Subject s)
        {
            InitializeComponent();
            sb = s;
        }
        private bool AreAllInfosInserted()
        {
            if (string.IsNullOrEmpty(txtSubjectName.Text.Trim()) || string.IsNullOrEmpty(txtDescription.Text.Trim()) || string.IsNullOrEmpty(txtCredits.Text.Trim()))
                return false;
            return true;
        }
        private void btnSavaSubject_Click(object sender, RoutedEventArgs e)
        {
            if (AreAllInfosInserted())
            {
                
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

                Helper.UpdateSubject(sb);

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(sb != null)
            {
                lblID.Content = sb.SubjectID.ToString();
                txtSubjectName.Text = sb.SubjectName;
                txtDescription.Text = sb.SubjectDescription;
                txtCredits.Text = sb.SubjectCredits.ToString();
            }

        }
    }
}
