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

namespace MCQuiz
{
    /// <summary>
    /// Interaction logic for ConfigurationForm.xaml
    /// </summary>
    public partial class ConfigurationForm : Page
    {
        private Controller controller;
        public ConfigurationForm(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void btn_save_back_Click(object sender, RoutedEventArgs e)
        {
            controller.SaveButtonClicked();
        }

        public TextBox GetSuccessHurdleTextbox()
        {
            return this.tbx_success_hurdle;
        }

        public TextBox GetNameOfProgramTextbox()
        {
            return this.tbx_program_name;
        }

        private void btn_reset_history_Click(object sender, RoutedEventArgs e)
        {
            controller.ResetHistoryButtonClicked();
        }
    }
}
