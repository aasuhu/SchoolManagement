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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stack<UserControl> _backHistory = new Stack<UserControl>();
        Stack<UserControl> _forwardHistory = new Stack<UserControl>();
        UserControl _current ;


        public void NavigateTo(UserControl content)
        {
            _forwardHistory.Clear();
            _backHistory.Push(_current);
            _current = content;
            Refresh();

        }

        public void Back()
        {
            btnBack.IsEnabled = _backHistory.Count > 0;

            if (_backHistory.Count > 0)
            {
                _forwardHistory.Push(_current);
                _current = _backHistory.Pop();
                Refresh();
            }
           
        }

        public void Forward()
        {
            _backHistory.Push(_current);
            _current = _forwardHistory.Pop();
            Refresh();
        }

        public void Refresh()
        {
            this.MainContentControl.Content = _current;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void m_Exit_Click(object sender, RoutedEventArgs e)
        {
            //  Application.Current.Shutdown();

            Window2 w2 = new Window2();
            w2.Show();
        }

        private void m_addStudent_Click(object sender, RoutedEventArgs e)
        {
            
           NavigateTo( new AddStudent());
        }

        private void m_EditStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void m_DeleteStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void m_ViewStudents_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new ViewStudents());
        }

        private void m_ViewSubjects_Click(object sender, RoutedEventArgs e)
        {
            NavigateTo(new ViewSubjects());
        }

        private void m_addSubject_Click(object sender, RoutedEventArgs e)
        {
           NavigateTo( new AddSubject());
            
        }

        private void m_EditSubject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void m_DeleteSubject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DateTime ls = Properties.Settings.Default.LicenceStart;
            //if (ls == null || String.IsNullOrEmpty(ls.ToString()))
            //{
            //    Properties.Settings.Default.LicenceStart = DateTime.Today.AddMonths(-6);
            //}
            //else if(DateTime.Today > ls.AddMonths(1))
            //{
            //    MessageBox.Show("Please purchase the full version");
            //    Application.Current.Shutdown();
            //}
          NavigateTo( new MainContent());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Helper.SaveXML();
        }

        private void m_SaveXML_Click(object sender, RoutedEventArgs e)
        {
            Helper.SaveXML();
        }

        private void m_LoadXml_Click(object sender, RoutedEventArgs e)
        {
            new StudentsXML().Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }
    }
}
