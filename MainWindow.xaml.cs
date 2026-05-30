
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;


namespace ST10483814_POE_PART_2
{

    /*The MainWindow class is code-behind for MainWindow.xaml 
      which handles the GUI interaction logic
     */
    public partial class MainWindow : Window
    {
        private ChatBotResponses bot;

        // Checks if the user has provided their name yet
        private bool isNameEntered = false;

        // A constructor for the MainWindow class
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            DisplayWelcome(); 
            txtUserInput.Focus();
        }


        // Plays the WAV voice greeting
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            AudioPlayer player = new AudioPlayer();
            player.PlayWav();
           
        }


        // A method that displays a welcome message and prompts for the user's name 
        private void DisplayWelcome()
        {
            // Adds a coloured message to the chat history display
            AppendMessage("Bot",
                "Hello there! Welcome to the Cybersecurity Awareness Bot!",
                Brushes.Cyan);


            AppendMessage("Bot",
                "I am your personal assistant to helping you stay safe online.",
                Brushes.Cyan);

            AppendMessage("Bot",
                "Please enter your name to get started",
                Brushes.Cyan);

            AppendDivider(); // Adds a grey line between sections to the chat for better readability
        }


        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            ProcessInput();
        }


        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // Checks if the Enter key was pressed by user
            {
                ProcessInput();
                e.Handled = true;
            }
        }

        private void txtUserInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPlaceholder.Visibility =
                string.IsNullOrWhiteSpace(txtUserInput.Text)
                ? Visibility.Visible
                : Visibility.Hidden;
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Clear all blocks from the
             * RichTextBox document
             */
            chatHistorySection.Document.Blocks.Clear();

            /*
             * Show fresh welcome message
             * after clearing the chat
             */
            AppendMessage("Bot",
                "Chat cleared! How can I help you?",
                Brushes.Cyan);

            AppendDivider();
            txtUserInput.Focus();
        }



        // A method that is used to process user input and handle relevant chatbot responses
        private void ProcessInput()
        {
            string userInput = txtUserInput.Text.Trim();

            if (string.IsNullOrEmpty(userInput))
            {
                AppendMessage("Bot",
                    "Hmmm I didn't quite catch that! Please type something so I can help you...",
                    Brushes.Yellow);
                return;
            }

            AppendMessage("You", userInput, Brushes.Magenta);

            // Clear the current input box and focus it for the next message
            txtUserInput.Clear();
            txtUserInput.Focus();


            if (!isNameEntered)
            {
                ProcessName(userInput);
                return;
            }
            ProcessChat(userInput);
        }


        /* A method that captures and processes the user's name at the start
          of the conversation and provides a personalized welcome message
        */
        private void ProcessName(string name)
        {
            // An instance of the ChatBotResponsesclass and passes the user's name to it
            bot = new ChatBotResponses(name);

            isNameEntered = true;


            AppendMessage("Bot",
                $"Good day {name}! It is such a pleasure to meet you!",
                Brushes.Cyan);

            AppendMessage("Bot",
                $"Awareness is your greatest weapon against cybercrime {name}.",
                Brushes.Cyan);

            AppendMessage("Bot",
                "I am here to make sure you are always informed and always protected online.",
                Brushes.Cyan);

            AppendMessage("Bot",
                "Type 'help' to see everything I can assist you with.",
                Brushes.Yellow);

            AppendMessage("Bot",
                "Type 'exit' or 'bye' to end our conversation.",
                Brushes.Yellow);

            AppendDivider();
        }


        private void ProcessChat(string userInput)
        {
            // Convert input to lowercase and remove extra spaces for accurate keyword matching
            string lowerInput = userInput.ToLower().Trim();

            if (lowerInput == "exit" ||
                lowerInput == "bye")
            {

                AppendMessage("Bot",
                    $"Goodbye! It was great chatting with you {bot.GetUserName}!",
                    Brushes.Cyan);

                AppendMessage("Bot",
                    "Rememeber to stay vigilant and cyber safe always.",
                    Brushes.Cyan);


                txtUserInput.IsEnabled = false;
                btnSend.IsEnabled = false;

                AppendDivider();
                return;
            }

            string response = bot.GetResponse(lowerInput);
            ShowTypingThenRespond(response);

            AppendDivider();

        }

        private async void ShowTypingThenRespond(string response)
        {
            //Display typing indicator in dark grey to show bot is busy
            AppendMessage("Bot", "typing...",
                new SolidColorBrush(Color.FromRgb(80, 80, 100)));


            // Wait 1 second to simulate the bot thinking and typing
            await Task.Delay(1000);

            var doc = chatHistorySection.Document;
            if (doc.Blocks.LastBlock != null)
            {
                doc.Blocks.Remove(doc.Blocks.LastBlock);
                doc.Blocks.Remove(doc.Blocks.LastBlock);
            }

            
            AppendMessage("Bot", response, Brushes.White);
            AppendDivider();
        }


        private void AppendMessage(string sender, string message, Brush colour)
        {
            FlowDocument doc = chatHistorySection.Document; // A document that is used to display the chat history in a rich text format
            Paragraph paragraph = new Paragraph();

            Run senderRun = new Run($"{sender}: ")
            {
                FontWeight = FontWeights.Bold,
                Foreground = colour
            };

            paragraph.Inlines.Add(senderRun); // This includes the sender's name in the paragraph content


            Run messageRun = new Run(message)
            {
                Foreground = Brushes.White
            };

            paragraph.Inlines.Add(messageRun);
            paragraph.Margin = new Thickness(0, 2, 0, 2); // Adds spacing between messages
            doc.Blocks.Add(paragraph); // Adds the paragraph to the document to be displayed in the chat history

            // Scrolls down to the bottom to ensure that most recent messages are visible to the user
            scrollViewer.ScrollToBottom();
        }


        private void AppendDivider()
        {
            FlowDocument doc = chatHistorySection.Document;
            Paragraph divider = new Paragraph(
                new Run(
                      " ───────────────────────────────────────────────────────────────────────────────────── ")
                {
                    Foreground = new SolidColorBrush(
                        Color.FromRgb(50, 50, 80))
                });

            divider.Margin = new Thickness(0, 2, 0, 2);
            doc.Blocks.Add(divider);

            scrollViewer.ScrollToBottom();

        }
    }
}




            
