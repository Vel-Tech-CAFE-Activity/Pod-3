using System;
using System.Threading.Tasks;
using System.Windows;
using LoggingLibrary;

namespace SerilogWpfDemo
{
    public partial class MainWindow : Window
    {
        private int _operationCounter = 0;
        private LoggerManager _loggerManager;

        public MainWindow()
        {
            InitializeComponent();
            _loggerManager = ((App)Application.Current).LoggerManager;
        }

        private async void LogButton_Click(object sender, RoutedEventArgs e)
        {
            _operationCounter++;
            var operationName = $"Operation {_operationCounter}";
            _loggerManager.LogDebug("Starting operation: {OperationName}", operationName);

            try
            {
                // Show the progress bar and perform the operation
                OperationProgress.Visibility = Visibility.Visible;
                await PerformOperationAsync();

                _loggerManager.LogDebug("Finished operation: {OperationName}", operationName);
                OperationList.Items.Add($"{operationName}: Success");
            }
            catch (Exception ex)
            {
                _loggerManager.LogError(ex, "Error during operation: {OperationName}", operationName);
                OperationList.Items.Add($"{operationName}: Error");
            }
            finally
            {
                // Hide the progress bar
                OperationProgress.Visibility = Visibility.Collapsed;
            }
        }

        private async Task PerformOperationAsync()
        {
            // Simulate a time-consuming operation
            await Task.Delay(2000);

            // Throw different exceptions based on the operation counter
            if (_operationCounter % 3 == 0)
            {
                throw new InvalidOperationException("Error during operation (InvalidOperationException).");
            }
            else if (_operationCounter % 4 == 0)
            {
                throw new ArgumentException("Error during operation (ArgumentException).");
            }
        }
    }
}
