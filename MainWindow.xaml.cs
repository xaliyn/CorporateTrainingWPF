using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Corporate_Training_Management
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }
        private void OpenInstructors(object sender, RoutedEventArgs e)
        {
            var win = new InstructorWindow();
            win.Show();
            this.Close();
        }

        private void OpenParticipants(object sender, RoutedEventArgs e)
        {
            var win = new ParticipantWindow();
            win.Show();
            this.Close();
        }

        private void OpenTrainings(object sender, RoutedEventArgs e)
        {
            var win = new TrainingWindow();
            win.Show();
            this.Close();
        }
    }
}
