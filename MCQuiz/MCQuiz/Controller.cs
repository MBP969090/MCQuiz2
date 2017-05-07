using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;

namespace MCQuiz
{
    /// <summary>
    /// This class is the main controller for Questionnaire
    /// </summary>
    public class Controller
    {
        private MainWindow mainwindow;
        private Questionnaire questionnaire;
        private ConfigurationForm config_form;
        private QuestionForm ques_form;
        private EvaluationForm eval_form;
        private StartForm start_form;
        private Configuration configuration;

        //private string sqlString = "server=Erde2008;database=Krebs_DB015;User id=Krebs015;Password=pKrebs015";
        private string sqlString = "Data Source=BENTHEPC;Initial Catalog=master;Integrated Security=true;";

        /// <summary>
        /// Constructor for Controller object
        /// Initialises GUI
        /// </summary>
        public Controller()
        {
            this.CreateHistoryTable();
            this.mainwindow = new MainWindow(this);

            this.configuration = new Configuration();
            this.start_form = new StartForm(this);
            this.config_form = new ConfigurationForm(this);
            this.ques_form = new QuestionForm(this);
            this.eval_form = new EvaluationForm(this);

            this.start_form.GetNameLabel().Content = this.configuration.NameOfProgram;
            string[] myList = GetDictionaryIds().ToArray();
            myList.ToList().ForEach(item => this.start_form.GetListBoxQuestionnaire().Items.Add(item));
            SetHistoryListView();
            this.mainwindow.Content = this.start_form;
            this.mainwindow.ShowDialog();
        }

        /// <summary>
        /// Initialise questionnaire with id out of database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>success</returns>
        public bool InitQuestionnaire(int id, string type)
        {
            bool success = false;
            this.questionnaire = new Questionnaire(id, type);
            using (SqlConnection connection = new SqlConnection(sqlString))
            {
                string query = "";
                if (type == "Binnen")
                {
                    query = "SELECT DISTINCT FragebogenNr, P_Id, Frage, Antwort1, Antwort2, Antwort3, Antwort4, RichtigeAntwort FROM T_Fragebogen_unter_Maschine LEFT JOIN T_SBF_Binnen ON (F_Id_SBF_Binnen=P_id) WHERE FragebogenNr=" + id;
                }
                else if (type == "Funk")
                {
                    query = "SELECT DISTINCT FragebogenNr, Id, Frage, AntwortA, AntwortB, AntwortC, AntwortD, RichtigeAntwort FROM T_Funk_UBI LEFT JOIN T_Fragebogen_Funk_UBI ON (F_id_Funk_UBI=Id) WHERE FragebogenNr=" + id;
                }
                else
                {
                    return false;
                }
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2) && !reader.IsDBNull(3) && !reader.IsDBNull(4) && !reader.IsDBNull(5) && !reader.IsDBNull(6) && !reader.IsDBNull(7))
                        {
                            success = true;
                            List<Dictionary<string, bool>> answers = new List<Dictionary<string, bool>>();
                            int rightAnswer = 0;
                            for (int i = 3; i <= 6; i++)
                            {
                                if (type == "Binnen")
                                {
                                    rightAnswer = reader.GetByte(7);
                                }
                                else
                                {
                                    string rightAnswerString = reader.GetString(7);
                                    rightAnswer = (int)rightAnswerString.First() - 64;
                                }
                                if (rightAnswer == i - 2)
                                {
                                    answers.Add(new Dictionary<string, bool> { { reader.GetString(i), true } });
                                }
                                else
                                {
                                    answers.Add(new Dictionary<string, bool> { { reader.GetString(i), false } });
                                }
                            }

                            this.questionnaire.AddQuestion(reader.GetInt32(1), reader.GetString(2), answers);
                        }
                    }
                }
                connection.Close();
            }
            return success;
        }

        /// <summary>
        /// Execute GetNextQuestion from questionnaire
        /// </summary>
        /// <returns>question</returns>
        public Question GetNextQuestion()
        {
            return this.questionnaire.GetNextQuestion();
        }

        /// <summary>
        /// Execute GetPreviousQuestion from questionnaire
        /// </summary>
        /// <returns>question</returns>
        public Question GetPreviousQuestion()
        {
            return this.questionnaire.GetPreviousQuestion();
        }

        /// <summary>
        /// Execute GetFirstQuestion from questionnaire
        /// </summary>
        /// <returns>question</returns>
        public Question GetFirstQuestion()
        {
            return this.questionnaire.GetFirstQuestion();
        }

        /// <summary>
        /// Execute GetCurrentQuestion from questionnaire
        /// </summary>
        /// <returns>question</returns>
        public Question GetCurrentQuestion()
        {
            return this.questionnaire.GetCurrentQuestion();
        }

        /// <summary>
        /// Execute Evaluate funktion form questionnaire
        /// </summary>
        /// <returns>double</returns>
        public double Evaluate()
        {
            return this.questionnaire.Evaluate();
        }

        //Startform functions

        /// <summary>
        /// Action if StartButton in startform is clicked
        /// hide start_form
        /// init questionform
        /// </summary>
        public void StartButtonClicked(ListBox listbox)
        {
            string select = Convert.ToString(listbox.SelectedItem);
            Match selected = Regex.Match(select, "(\\d+)\\s(\\w+)");
            int selectedId = Convert.ToInt32(selected.Groups[1].Value);
            string selectedQuestionnaire = selected.Groups[2].Value;
            this.InitQuestionnaire(selectedId, selectedQuestionnaire);
            this.ques_form.InititializeQuestionForm();
            this.mainwindow.Content = this.ques_form;
        }

        
        /// <summary>
        /// Action if ConfigButton in startform is clicked
        /// hide start_form
        /// set labels in configurationform
        /// init configurationform
        /// </summary>
        public void ConfigButtonClicked()
        {
            
            this.mainwindow.Content = this.config_form;
            config_form.GetSuccessHurdleTextbox().Text = "" + this.configuration.SuccessHurdle;
            config_form.GetNameOfProgramTextbox().Text = this.configuration.NameOfProgram;
        }

        private void SetHistoryListView()
        {
            List<string> history = GetHistoryString();
            this.start_form.GetListViewHistory().Items.Clear();
            history.ToList().ForEach(item => this.start_form.GetListViewHistory().Items.Add(item));
        }
        
        //Configurationform functions

        /// <summary>
        /// Action if SaveButton in configurationform is clicked
        /// hide config_form
        /// sets configuration object to entered data
        /// sets label in start_form
        /// </summary>
        public void SaveButtonClicked()
        {
            this.mainwindow.Content = this.start_form;
            string name = config_form.GetNameOfProgramTextbox().Text;
            int successHurdle = Convert.ToInt32(config_form.GetSuccessHurdleTextbox().Text);

            this.configuration.NameOfProgram = name;
            this.configuration.SuccessHurdle = successHurdle;

            this.start_form.GetNameLabel().Content = name;
            SetHistoryListView();
        }

        public void ResetHistoryButtonClicked()
        {
            this.DeleteHistory();
        }

        //Evaluationform functions

        /// <summary>
        /// Action if BackToMenuButton in evaluationform is clicked
        /// hide evaluationform
        /// show start_form
        /// </summary>
        public void BackToMainMenuButtonClicked()
        {
            SetHistoryListView();
            this.mainwindow.Content = this.start_form;
        }
        //Questionform functions

        /// <summary>
        /// initialise textboxes and radiobuttons for first question
        /// </summary>
        public void InitializeQuestionForm(TextBox textbox, RadioButton[] radios, Image gif)
        {
            this.UpdateQuestionPage(GetFirstQuestion(), textbox, radios, gif);
        }

        /// <summary>
        /// initialise textboxes and radiobuttons for next question
        /// set choice for current question
        /// </summary>
        public void ForwardButtonClicked(TextBox textbox, RadioButton[] radios, Image gif)
        {
            SetSelectedAnswer(radios);
            CreateNextPageQuestionForm(textbox, radios, gif);
        }

        /// <summary>
        /// initialise textboxes and radiobuttons for next question
        /// set choice for current question
        /// </summary>
        public void BackButtonClicked(TextBox textbox, RadioButton[] radios, Image gif)
        {
            SetSelectedAnswer(radios);
            CreatePreviousPageQuestionForm(textbox, radios, gif);
        }

        /// <summary>
        /// set choosen answer of current question
        /// </summary>
        /// <param name="radios"></param>
        private void SetSelectedAnswer(RadioButton[] radios)
        {
            for (int i = 0; i < radios.Length; i++)
            {
                bool? checked_radio = radios[i].IsChecked;
                if (!checked_radio.HasValue)
                {
                    checked_radio = false;
                }
                if ((bool)checked_radio)
                {
                    this.GetCurrentQuestion().AnswerQuestion(i);
                }
            }
        }

        /// <summary>
        /// initialise questionform for next question if exists
        /// else initialise evaluationform
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="radios"></param>
        private void CreateNextPageQuestionForm(TextBox textbox, RadioButton[] radios, Image gif)
        {
            Question q;
            if ((q = GetNextQuestion()) == null)
            {
                this.SaveResultInHistory();
                this.eval_form.SetSuccessLabel(configuration.SuccessHurdle <= this.Evaluate());
                this.eval_form.SetResultLabel(this.questionnaire.GetEvaluateString());
                this.eval_form.SetWrongAnswerTextbox(this.questionnaire.GetWrongAnswerString());
                this.mainwindow.Content = this.eval_form;
            }
            else
            {
                this.UpdateQuestionPage(q, textbox, radios, gif);
            }
        }

        /// <summary>
        /// Update text and picture of questionpage
        /// </summary>
        /// <param name="q"></param>
        /// <param name="textbox"></param>
        /// <param name="radios"></param>
        /// <param name="gif"></param>
        private void UpdateQuestionPage(Question q, TextBox textbox, RadioButton[] radios, Image gif)
        {
            SetRadios(radios, q);
            for (int i = 0; i < radios.Length; i++)
            {
                radios[i].Content = q.GetAnswer(i).GetText();
            }
            textbox.Text = q.GetText();
            gif.Source = null;
            if (q.GetPictureLocation() != "" && q.GetPictureLocation() != null)
            {
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(Path.Combine(Environment.CurrentDirectory, q.GetPictureLocation()));
                logo.EndInit();
                gif.Source = logo;
            }
        }

        /// <summary>
        /// initialise questionform for previous question if exists
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="radios"></param>
        private void CreatePreviousPageQuestionForm(TextBox textbox, RadioButton[] radios, Image gif)
        {
            Question q;
            if ((q = GetPreviousQuestion()) != null)
            {
                this.UpdateQuestionPage(q, textbox, radios, gif);
            }
        }

        /// <summary>
        /// set radiobuttons like the answers of given question
        /// </summary>
        /// <param name="radios"></param>
        /// <param name="q"></param>
        private void SetRadios(RadioButton[] radios, Question q)
        {
            for (int i = 0; i < radios.Length; i++)
            {
                if (q.GetAnswer(i).IsChoosen())
                {
                    radios[i].IsChecked = true;
                }
                else
                {
                    radios[i].IsChecked = false;
                }
            }
        }

        /// <summary>
        /// Creates new History Table if not exists
        /// </summary>
        private void CreateHistoryTable()
        {
            using (SqlConnection connection = new SqlConnection(sqlString))
            {
                connection.Open();
                string query = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='History' AND xtype='U') CREATE TABLE History (id Integer IDENTITY(1,1) PRIMARY KEY, questionnaire_id VARCHAR(20), questionnaire_name VARCHAR(30), success BIT)";
                SqlCommand command;
                using (command = new SqlCommand(query, connection));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Builds previous results from database
        /// </summary>
        /// <returns></returns>
        private List<string> GetHistoryString()
        {
            CreateHistoryTable();
            List<string> output = new List<string>();
            using (SqlConnection connection = new SqlConnection(sqlString))
            {
                string query = "SELECT questionnaire_id, questionnaire_name, success FROM History";
                SqlCommand command;
                using (command = new SqlCommand(query, connection));
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string name = reader.GetString(1);
                        string success = reader.GetBoolean(2) == true ? "Bestanden" : "Nicht bestanden";
                        output.Add(name + " (Fragebogen " + id + ")" + " - " + success);
                    }
                }
                connection.Close();
            }
            return output;
        }
        /// <summary>
        /// Saves result of completed questionnaire in database
        /// </summary>
        private void SaveResultInHistory()
        {
            int success = Evaluate() > this.configuration.SuccessHurdle ? 1 : 0;
            using (SqlConnection connection = new SqlConnection(sqlString))
            {
                connection.Open();
                string query = "INSERT INTO HISTORY (questionnaire_id, questionnaire_name, success) VALUES ('" + this.questionnaire.GetID() + " " + this.questionnaire.GetQuestionnaireType() + "','" + this.configuration.NameOfProgram + "','" + success + "')";
                SqlCommand command;
                using (command = new SqlCommand(query, connection));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Truncate history table
        /// </summary>
        private void DeleteHistory()
        {
            using (SqlConnection connection = new SqlConnection(sqlString))
            {
                connection.Open();
                string query = "TRUNCATE TABLE History";
                SqlCommand command;
                using (command = new SqlCommand(query, connection));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Returns all ids from questionnaires
        /// </summary>
        /// <returns></returns>
        private List<string> GetDictionaryIds()
        {
            List<string> dictionaryIds = new List<string>();
            using (SqlConnection connection = new SqlConnection(sqlString))
            {
                string query = "(SELECT CONCAT(FragebogenNr, ' ','Binnen'), FragebogenNr FROM T_Fragebogen_unter_Maschine) UNION (SELECT CONCAT(FragebogenNr, ' ', 'Funk'), FragebogenNr FROM  T_Fragebogen_Funk_UBI) ORDER BY FragebogenNr";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dictionaryIds.Add("" + reader.GetString(0));
                    }
                }
                connection.Close();
            }
            return dictionaryIds;
        }
    }
}
