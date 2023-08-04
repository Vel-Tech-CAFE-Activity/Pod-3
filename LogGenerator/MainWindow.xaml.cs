using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace LogViewerApp
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string apiUrl = "http://localhost:5000/logging";
        private List<string> logLevels = new List<string>() { "Trace", "Debug", "Information", "Warning", "Error", "Critical", "None" };
        private string selectedLogLevel = "Information";
        private string selectedUser = "User 1";
        private List<string> users = new List<string>() { "User 1", "User 2", "User 3" };
        private Dictionary<string, string> messages;

        public MainWindow()
        {
            InitializeComponent();
            client.DefaultRequestHeaders.Add("X-API-KEY", "123456789");

            UserComboBox.ItemsSource = users;
            LogLevelComboBox.ItemsSource = logLevels;
            // Load messages from JSON file
            var jsonData = File.ReadAllText("logMessages.json");
            var logMessages = JsonConvert.DeserializeObject<LogMessage[]>(jsonData);
            messages = logMessages.ToDictionary(m => m.Message, m => m.Severity);
        }

        private void LogLevelComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            if (comboBox != null && comboBox.SelectedIndex != -1)
            {
                var newLogLevel = comboBox.SelectedItem.ToString();
                selectedLogLevel = newLogLevel;
            }
        }

        private void UserComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            if (comboBox != null && comboBox.SelectedIndex != -1)
            {
                var newUsername = comboBox.SelectedItem.ToString();
                selectedUser = newUsername;
            }
        }

        private async void APICallButton_Click(object sender, RoutedEventArgs e)
        {
            ResponseTextBlock.Text = "Processing request...";
            await Task.Delay(500);

            DateTime utcDateTime = DateTime.UtcNow;
            DateTime convertedDateTime = utcDateTime.AddHours(5).AddMinutes(30);

            // Get a random message and its severity level
            Random random = new Random();
            int index = random.Next(messages.Count);
            string selectedMessage = new List<string>(messages.Keys)[index];
            

            var logEvent = new
            {
                Message = selectedMessage,
                Level =  selectedLogLevel,
                Timestamp = convertedDateTime,
                UserInformation = selectedUser.ToString(),
                SystemInformation = "Test System",
                ProcessInformation = "Test Process"
            };

            var json = System.Text.Json.JsonSerializer.Serialize(logEvent);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(apiUrl, data);

            string result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                ResponseTextBlock.Text = "Logging Successful";
            }
            else
            {
                ResponseTextBlock.Text = "API call failed with status code: " + result;
            }
        }

        private class LogMessage
        {
            public string Message { get; set; }
            public string Severity { get; set; }
        }
    }
}
