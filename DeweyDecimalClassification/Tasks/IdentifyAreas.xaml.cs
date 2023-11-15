using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Xml.Linq;


/*
* CODE ATTRIBUTION - PROGRESS BAR / ANIMATION
* https://wpf-tutorial.com/misc-controls/the-progressbar-control/
*/

/*
* CODE ATTRIBUTION - DICTIONARIES
* https://www.tutorialsteacher.com/csharp/csharp-dictionary
*/

/*
* CODE ATTRIBUTION - DURATION METHOD
* https://learn.microsoft.com/en-us/dotnet/api/system.timespan.duration?view=net-7.0
*/

namespace DeweyDecimalClassification.Tasks
{
    public partial class IdentifyAreas : Window
    {
        private Dictionary<string, string> questionDictionary = new Dictionary<string, string>();
        private List<string> questionKeys = new List<string>();
        private int currentQuestionIndex = 0;
        private int correctAnswers = 0;
        private bool matchDescriptionToCallNumber = true;
        private Duration duration = new Duration(TimeSpan.FromSeconds(1));
        private double percentage;

        public IdentifyAreas()
        {
            InitializeComponent();
            percentage = 0;
            InitializeQuestions();
            ShuffleQuestions();
            LoadQuestion();
            UpdateProgressBar();
        }

        private void InitializeQuestions()
        {
            // Create a dictionary to store possible answers for each question
            questionDictionary.Add("000 ", "Generalities - Computer science, information & general works");
            questionDictionary.Add("100 ", "Philosophy & Psychology - Philosophy, parapsychology & occultism");
            questionDictionary.Add("200 ", "Religion - Religion");
            questionDictionary.Add("300 ", "Social Sciences - Social sciences");
            questionDictionary.Add("400 ", "Language - Language");
            questionDictionary.Add("500 ", "Natural Sciences & Mathematics - Science");
            questionDictionary.Add("600 ", "Technology (Applied Sciences) - Technology, engineering & applied operations");
            questionDictionary.Add("700 ", "Arts & Recreation - Arts, recreation & performing arts");
            questionDictionary.Add("800 ", "Literature - Literature & rhetoric");
            questionDictionary.Add("900 ", "History & Geography - History & geography");

            questionKeys = questionDictionary.Keys.ToList();
        }

        private void ShuffleQuestions()
        {
            var random = new Random();
            questionKeys = questionKeys.OrderBy(x => random.Next()).ToList();
        }

        private void LoadQuestion()
        {
            var random = new Random();

            if (currentQuestionIndex < questionKeys.Count)
            {
                var questionKey = questionKeys[currentQuestionIndex];
                var description = questionDictionary[questionKey];

                Column1.Items.Clear();
                Column2.Items.Clear();

                if (matchDescriptionToCallNumber)
                {
                    // Matching descriptions to call numbers
                    Column1.Items.Add(new ListBoxItem { Content = description });
                }
                else
                {
                    // Matching call numbers to descriptions
                    Column1.Items.Add(new ListBoxItem { Content = questionKey });
                }

                // Generate four possible answers for the second column
                var possibleAnswers = new List<string>();

                // Generate one correct answer
                possibleAnswers.Add(matchDescriptionToCallNumber ? questionKey : description);

                // Generate three incorrect answers
                while (possibleAnswers.Count < 4)
                {
                    var randomQuestionKey = questionKeys[random.Next(questionKeys.Count)];
                    var randomDescription = questionDictionary[randomQuestionKey];

                    if (matchDescriptionToCallNumber)
                    {
                        if (randomQuestionKey != questionKey && !possibleAnswers.Contains(randomQuestionKey))
                        {
                            possibleAnswers.Add(randomQuestionKey);
                        }
                    }
                    else
                    {
                        if (randomDescription != description && !possibleAnswers.Contains(randomDescription))
                        {
                            possibleAnswers.Add(randomDescription);
                        }
                    }
                }

                // Shuffle the possible answers
                possibleAnswers = possibleAnswers.OrderBy(x => random.Next()).ToList();

                foreach (var answer in possibleAnswers)
                {
                    Column2.Items.Add(new ListBoxItem { Content = answer });
                }
            }
            else
            {
                MessageBox.Show("Congratulations, you have completed all the questions.", "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                currentQuestionIndex = 0; // Reset questions after answering 10
                correctAnswers = 0; // Reset the score after answering 10 questions
                percentage = 0; // Reset the percentage after answering 10 questions
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestionIndex < questionKeys.Count)
            {
                var selectedItem = (ListBoxItem)Column2.SelectedItem;
                if (selectedItem != null)
                {
                    if (matchDescriptionToCallNumber)
                    {
                        // Matching descriptions to call numbers
                        var selectedAnswer = selectedItem.Content.ToString();
                        var callNumber = questionKeys[currentQuestionIndex];
                        if (selectedAnswer == callNumber)
                        {
                            // User's answer is correct
                            MessageBox.Show("Correct!", "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                            correctAnswers++;
                            currentQuestionIndex++;
                        }
                        else
                        {
                            MessageBox.Show("Incorrect. The correct answer is " + callNumber, "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        // Matching call numbers to descriptions
                        var selectedAnswer = selectedItem.Content.ToString();
                        var description = questionDictionary[questionKeys[currentQuestionIndex]];
                        if (selectedAnswer == description)
                        {
                            // User's answer is correct
                            MessageBox.Show("Correct!", "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                            correctAnswers++;
                            currentQuestionIndex++;
                        }
                        else
                        {
                            MessageBox.Show("Incorrect. The correct answer is " + description, "Feedback", MessageBoxButton.OK, MessageBoxImage.Information);
                        }                        
                    }
                    
                    matchDescriptionToCallNumber = !matchDescriptionToCallNumber; // Toggle between true and false
                    LoadQuestion();
                }
                else
                {
                    MessageBox.Show("Please select an answer.", "Feedback", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            // Update the progress bar based on the number of correct answers
            UpdateProgressBar();
        }

        private void UpdateProgressBar()
        {
            double newPercentage = (correctAnswers / 10.0) * 100;

            DoubleAnimation da = new DoubleAnimation(percentage, newPercentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, da);

            percentage = newPercentage;
            
            // Update the level and score
            txtComment.Text = $"Score: {correctAnswers}";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            SignIn signin = new SignIn();

            if (string.IsNullOrEmpty(signin.txtStudentNumber.Text))
            {
                main.lblStudentNumber.Visibility = Visibility.Hidden;
            }

            if (string.IsNullOrEmpty(signin.txtNames.Text))
            {
                main.lblName.Visibility = Visibility.Hidden;
            }

            Visibility = Visibility.Collapsed;
            main.Show();
        }        
    }
}


