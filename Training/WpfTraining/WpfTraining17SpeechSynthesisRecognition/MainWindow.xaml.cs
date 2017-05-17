using System;
using System.Globalization;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Media;

namespace WpfTraining17SpeechSynthesisRecognition
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine speechRecognizer = new SpeechRecognitionEngine();
        public MainWindow()
        {
            InitializeComponent();
            //SpeechRecognizer speechRecognizer = new SpeechRecognizer();
            speechRecognizer.SpeechRecognized += speechRecognizer_SpeechRecognized;

            GrammarBuilder grammarBuilder = new GrammarBuilder();
            Choices commandChoices = new Choices("weight", "color", "size");
            grammarBuilder.Append(commandChoices);

            Choices valueChoices = new Choices();
            valueChoices.Add("normal", "bold");
            valueChoices.Add("red", "green", "blue");
            valueChoices.Add("small", "medium", "large");
            grammarBuilder.Append(valueChoices);

            speechRecognizer.LoadGrammar(new Grammar(grammarBuilder));
            speechRecognizer.SetInputToDefaultAudioDevice();
        }
        #region SpeechSynthesizer
        private void btnSayHello_Click(object sender, RoutedEventArgs e)
        {
            PromptBuilder promptBuilder = new PromptBuilder(new System.Globalization.CultureInfo("en-UK"));
            promptBuilder.AppendText("Hello world");

            PromptStyle promptStyle = new PromptStyle();
            promptStyle.Volume = PromptVolume.ExtraSoft;
            promptStyle.Rate = PromptRate.Slow;
            promptBuilder.StartStyle(promptStyle);
            promptBuilder.AppendText("and hello to the universe too.");
            promptBuilder.EndStyle();

            promptStyle.Volume = PromptVolume.ExtraLoud;
            promptStyle.Rate = PromptRate.Fast;
            promptBuilder.StartStyle(promptStyle);
            promptBuilder.AppendText("On this day, ");
            promptBuilder.AppendTextWithHint(DateTime.Now.ToShortDateString(), SayAs.Date);
            promptBuilder.EndStyle();

            promptStyle.Volume = PromptVolume.Medium;
            promptStyle.Rate = PromptRate.ExtraSlow;
            promptBuilder.StartStyle(promptStyle);
            promptBuilder.AppendText(", we're gathered here to learn", PromptEmphasis.Strong);
            promptBuilder.AppendText("all");
            promptBuilder.AppendText("about");
            promptBuilder.AppendTextWithHint("WPF", SayAs.SpellOut);
            promptBuilder.EndStyle();

            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(promptBuilder);
        }
        #endregion

        #region SpeechRecognizer
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtSpeech.Text = "";
        }
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Command invoked: Open");
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Command invoked: Save");
        }
        private void btnToggleListening_Click(object sender, RoutedEventArgs e)
        {
            if (btnToggleListening.IsChecked == true)
                speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            else
                speechRecognizer.RecognizeAsyncStop();
        }
        private void speechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            lblDemo.Content = e.Result.Text;
            if (e.Result.Words.Count == 2)
            {
                string command = e.Result.Words[0].Text.ToLower();
                string value = e.Result.Words[1].Text.ToLower();
                switch (command)
                {
                    case "weight":
                        FontWeightConverter weightConverter = new FontWeightConverter();
                        lblDemo.FontWeight = (FontWeight)weightConverter.ConvertFromString(value);
                        break;
                    case "color":
                        lblDemo.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value));
                        break;
                    case "size":
                        switch (value)
                        {
                            case "small":
                                lblDemo.FontSize = 12;
                                break;
                            case "medium":
                                lblDemo.FontSize = 24;
                                break;
                            case "large":
                                lblDemo.FontSize = 48;
                                break;
                        }
                        break;
                }
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            speechRecognizer.Dispose();
        }
        #endregion
    }
}
