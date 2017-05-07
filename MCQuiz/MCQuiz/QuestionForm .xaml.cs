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
    /// Interaction logic for QuestionForm.xaml
    /// </summary>
    public partial class QuestionForm : Page
    {
        private RadioButton[] radios;
        private Controller controller;

        public QuestionForm(Controller controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        public void InititializeQuestionForm()
        {
            this.radios = new RadioButton[4];
            this.radios[0] = this.rbo_answer_1;
            this.radios[1] = this.rbo_answer_2;
            this.radios[2] = this.rbo_answer_3;
            this.radios[3] = this.rbo_answer_4;
            controller.InitializeQuestionForm(this.tbx_question, this.radios, this.img_gif);
        }

        private void btn_forward_Click(object sender, RoutedEventArgs e)
        {
            controller.ForwardButtonClicked(this.tbx_question, this.radios, this.img_gif);
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            controller.BackButtonClicked(this.tbx_question, this.radios, this.img_gif);
        }
    }
}
