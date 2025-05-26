using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
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
using TypingSimulator.MainViewScripts;
using TypingSimulator.SqlScripts;


namespace TypingSimulator.Views
{
    public partial class MainView : UserControl
    {
        private readonly UserSession _userSession;
        private readonly TypingController _typingController;
        private TextPointer _pointer;
        public string[] LanguageTypes { get; } = { "Python", "Csharp", "Cpp", "Java" };
        private string[] _generatedSample = [];

        private int _lineIndex = 0;
        private int _correctWords = 0;
        private int _incorrectWords = 0;

        private bool _gameLoaded = false;
        public MainView(UserSession userSession)
        {
            _userSession = userSession;
            _typingController = new TypingController();
            InitializeComponent();
            DataContext = this;

            UpdateGUITimers();
            UserNameLabel.Content = "Welcome, " + _userSession.UserName + "!";

            TextField.Document.Blocks.Clear();
            TextField.Document.Blocks.Add(new Paragraph(new Run("Choose the language to start")));
            _pointer = TextField.Document.ContentStart;
        }

        private async void UpdateGUITimers()
        {
            while (true)
            {
                TotalPlayTime.Content = _userSession.GetTotalTimeSpan();
                TodayPlayTime.Content = _userSession.GetSessionTimeSpan();
                await Task.Delay(1000);
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeSample();
        }

        private void ChangeSample()
        {
            EnableTextField();
            if (LanguageComboBox.SelectedIndex < 0 || LanguageComboBox.SelectedIndex >= LanguageTypes.Length)
            {
                MessageBox.Show("Please select a valid language.");
                return;
            }
            _generatedSample = new TextFetcher(LanguageTypes[LanguageComboBox.SelectedIndex]).GetRandomSample();
            RestartTyping(_generatedSample);
        }
        private void StartGame()
        {
            _pointer = TextField.Document.ContentStart.GetNextInsertionPosition(LogicalDirection.Forward);
        }

        private void TextField_TextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
            if (_gameLoaded) _typingController.StartTyping();
            _gameLoaded = false;
            DisablePressKeyLabel();
            char typedChar = e.Text[0];
            string textRun = _pointer.GetTextInRun(LogicalDirection.Forward);
            char sampleChar = textRun.Length > 0 ? textRun[0] : '\0';
            TextPointer nextPointer = _pointer.GetPositionAtOffset(1, LogicalDirection.Forward);
            if (nextPointer == null)
            {
                CountCorrectIncorrectWords();
                return;
            }
            var range = new TextRange(_pointer, nextPointer);
            if (typedChar == sampleChar)
            {
                range.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Green);
            }
            else
            {
                range.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Red);
            }
            _pointer = nextPointer;
            ((RichTextBox)sender).CaretPosition = _pointer;
        }

        private void TextField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Enter)
            {
                if (_gameLoaded) _typingController.StartTyping();
                _gameLoaded = false;
                e.Handled = true;
                string textRun = _pointer.GetTextInRun(LogicalDirection.Forward);
                char sampleChar = textRun.Length > 0 ? textRun[0] : '\0';
                TextPointer nextPointer = _pointer.GetNextInsertionPosition(LogicalDirection.Forward);
                if (nextPointer == null)
                {
                    CountCorrectIncorrectWords();
                    return;
                }
                var range = new TextRange(_pointer, nextPointer);
                if (' ' == sampleChar)
                {
                    range.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Green);
                }
                else
                {
                    range.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Red);
                }
                _pointer = nextPointer;
                ((RichTextBox)sender).CaretPosition = _pointer;
                _lineIndex++;
            }
            else if (e.Key == Key.Back)
            {
                if (_gameLoaded) _typingController.StartTyping();
                _gameLoaded = false;
                e.Handled = true;
                TextPointer nextPointer = _pointer.GetNextInsertionPosition(LogicalDirection.Backward);
                if (_pointer != TextField.Document.ContentStart && _lineIndex > 0)
                {
                    var range = new TextRange(nextPointer, _pointer);
                    range.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Transparent);
                    _pointer = nextPointer;
                    ((RichTextBox)sender).CaretPosition = nextPointer;
                    _lineIndex--;
                }
            }
        }
        private void CountCorrectIncorrectWords()
        {
            _correctWords = 0;
            _incorrectWords = 0;
            TextPointer pointer = TextField.Document.ContentStart;
            TextPointer end = TextField.Document.ContentEnd;
            bool isWord = false;
            bool isWordCorrect = true;
            while (pointer != null && pointer.CompareTo(end) < 0)
            {
                string text = pointer.GetTextInRun(LogicalDirection.Forward);
                if (string.IsNullOrEmpty(text))
                {
                    pointer = pointer.GetNextContextPosition(LogicalDirection.Forward);
                    continue;
                }
                foreach (char c in text)
                {
                    TextPointer nextPointer = pointer.GetPositionAtOffset(1, LogicalDirection.Forward);
                    if (nextPointer == null) break;
                    var range = new TextRange(pointer, nextPointer);
                    if (char.IsWhiteSpace(c))
                    {
                        if (isWord)
                        {
                            if (isWordCorrect)
                                _correctWords++;
                            else
                                _incorrectWords++;

                            isWord = false;
                            isWordCorrect = true;
                        }
                    }
                    else
                    {
                        isWord = true;
                        if (range.GetPropertyValue(TextElement.BackgroundProperty) is SolidColorBrush brush)
                        {
                            if (brush.Color == Colors.Red) isWordCorrect = false;
                        }
                    }
                    pointer = nextPointer;
                }
            }
            if (isWord)
            {
                if (isWordCorrect) _correctWords++;
                else _incorrectWords++;
            }
            double accuracy = Math.Round((double)_correctWords / (_correctWords + _incorrectWords) * 100, 2);
            double wpm = Math.Round((double)_correctWords / ((DateTime.Now - _typingController.StartOfTyping).TotalMinutes), 2);
            int score = (int)(wpm * 10000 / 100 * accuracy);
            AccuracyLabel.Content = $"{accuracy}%";
            WPMLabel.Content = $"{wpm}";
            Score.Content = $"{score}";
            UsersDAO.UpdateUserBestEffort(_userSession.UserId, LanguageTypes[LanguageComboBox.SelectedIndex], score);
            ChangeSample();
            EnablePressKeyLabel();
        }
        private void EnableTextField()
        {
            TextField.IsReadOnly = false;
            TextField.Focusable = true;
        }
        private void DisableTextField()
        {
            TextField.IsReadOnly = true;
            TextField.Focusable = false;
        }
        private void TextField_Loaded(object sender, RoutedEventArgs e)
        {
            if (_gameLoaded) FocusTextField();
            else 
            {
                DisableTextField();
            }
        }
        private void FocusTextField()
        {
            TextField.Focus();
            Keyboard.Focus(TextField);
            TextField.CaretPosition = _pointer;
        }
        private void RestartTyping()
        {
            EnablePressKeyLabel();
            _lineIndex = 0;
            _correctWords = 0;
            _incorrectWords = 0;
            FocusTextField();
            TextField.Document.Blocks.Clear();
            _gameLoaded = true;
        }
        private void DisablePressKeyLabel()
        {
            PressKeyLabel.Visibility = Visibility.Collapsed;
            PressKeyLabel.Opacity = 0;
        }
        private void EnablePressKeyLabel() {
            PressKeyLabel.Visibility = Visibility.Visible;
            PressKeyLabel.Opacity = 1;
        }
        private void RestartTyping(string[] pSample) 
        {
            TextField.Document.Blocks.Clear();
            foreach (var line in pSample)
            {
                Paragraph para = new Paragraph();
                para.LineHeight = 19;
                para.LineStackingStrategy = LineStackingStrategy.BlockLineHeight;
                para.Inlines.Add(new Run(line));
                TextField.Document.Blocks.Add(para);
            }
            _gameLoaded = true;
            FocusTextField();
            StartGame();
        }
        private void ChangeSampleButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeSample();
        }

        private void RestartTypingButton_Click(object sender, RoutedEventArgs e)
        {
            RestartTyping(_generatedSample);
        }
        private void LeaderboardsButton_Click(object sender, RoutedEventArgs e)
        {
            new Windows.LeaderboardsWindow().Show();
        }
    }
}
