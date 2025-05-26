using System;
using System.Collections.Generic;
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


namespace TypingSimulator.Views
{
    public partial class MainView : UserControl
    {
        private readonly UserSession _userSession;
        private readonly TypingController _typingController;
        private TextPointer _pointer;
        public string[] LanguageTypes { get; } = { "Python", "Csharp", "Cpp", "Java" };
        private string[] sample = [];

        private int _lineIndex = 0;
        private int _correctWords = 0;
        private int _incorrectWords = 0;
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
            sample = new TextFetcher(LanguageTypes[LanguageComboBox.SelectedIndex]).GetRandomSample();
            TextField.Document.Blocks.Clear();
            foreach (var line in sample)
            {
                Paragraph para = new Paragraph();
                para.LineHeight = 19;
                para.LineStackingStrategy = LineStackingStrategy.BlockLineHeight;
                para.Inlines.Add(new Run(line));
                TextField.Document.Blocks.Add(para);
            }
            StartGame();
        }
        private void StartGame() 
        {
             _pointer = TextField.Document.ContentStart.GetNextInsertionPosition(LogicalDirection.Forward);
            _typingController.StartTyping();
        }

        private void TextField_TextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
            char typedChar = e.Text[0];
            string textRun = _pointer.GetTextInRun(LogicalDirection.Forward);
            char sampleChar = textRun.Length > 0 ? textRun[0] : '\0';
            TextPointer nextPointer = _pointer.GetPositionAtOffset(1, LogicalDirection.Forward);
            if (nextPointer == null)
                return;
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
            _lineIndex++;
        }

        private void TextField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Enter)
            {
                e.Handled = true;
                string textRun = _pointer.GetTextInRun(LogicalDirection.Forward);
                char sampleChar = textRun.Length > 0 ? textRun[0] : '\0';
                TextPointer nextPointer = _pointer.GetNextInsertionPosition(LogicalDirection.Forward);
                if (nextPointer == null)
                    return;
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

        private void InspectCharactersInRichTextBox(RichTextBox richTextBox)
        {
            TextPointer pointer = richTextBox.Document.ContentStart;

            while (pointer != null && pointer.CompareTo(richTextBox.Document.ContentEnd) < 0)
            {
                // Get next position in forward direction
                TextPointer nextPointer = pointer.GetNextInsertionPosition(LogicalDirection.Forward);

                if (nextPointer == null)
                    break;

                // Create a range from current to next character
                var range = new TextRange(pointer, nextPointer);

                // Only process if it's actual text (not formatting or empty)
                if (!string.IsNullOrWhiteSpace(range.Text))
                {
                    var background = range.GetPropertyValue(TextElement.BackgroundProperty);
                    if (background is SolidColorBrush brush)
                    {
                        if (brush.Color == Colors.Red)
                        {
                            Console.WriteLine($"Error: '{range.Text}' is highlighted in red.");
                        }
                        else
                        {
                            Console.WriteLine($"Character: '{range.Text}' - Background: {brush.Color}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Character: '{range.Text}' - No background brush");
                    }
                }

                pointer = nextPointer;
            }
        }

    }
}
