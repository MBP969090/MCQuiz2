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
    /// Interaction logic for StartForm.xaml
    /// </summary>
    public partial class StartForm : Page
    {
        private Controller controller;

        public StartForm()
        {
            InitializeComponent();
        }

        public StartForm(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        public Label GetNameLabel()
        {
            return this.lbl_quiz_name;
        }

        public ListView GetListViewHistory()
        {
            return this.liv_history;
        }

        public ListBox GetListBoxQuestionnaire()
        {
            return this.lbx_questionnaire;
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            controller.StartButtonClicked(this.lbx_questionnaire);
        }

        private void btn_config_Click(object sender, RoutedEventArgs e)
        {
            controller.ConfigButtonClicked();
        }
    }
}
