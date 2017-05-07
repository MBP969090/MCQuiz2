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
    /// Interaction logic for EvaluationForm.xaml
    /// </summary>
    public partial class EvaluationForm : Page
    {
        private Controller controller;
        public EvaluationForm(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void btn_start_form_Click(object sender, RoutedEventArgs e)
        {
            controller.BackToMainMenuButtonClicked();
        }

        public void SetSuccessLabel(bool success)
        {
            if (success)
            {
                this.lbl_success.Background = Brushes.Green;
                this.lbl_success.Content = "GZ du pisser hast bestanden!!!.";
            }
            else
            {
                this.lbl_success.Background = Brushes.Red;
                this.lbl_success.Content = "Leider nicht bestanden du LOOOOOSEEERRRR!!! BOON!!!";
            }
        }

        public void SetResultLabel(string result)
        {
            this.lbl_result.Content = result;
        }

        public void SetWrongAnswerTextbox(string s)
        {
            this.txt_answers.Text = s;
        }
    }
}
