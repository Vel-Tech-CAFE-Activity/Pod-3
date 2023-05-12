# SerilogWpfDemo and LoggingLibrary

This repository contains two projects:

1. **SerilogWpfDemo**: A WPF application that demonstrates how to use Serilog for logging in a WPF application.
2. **LoggingLibrary**: A .NET class library that provides a reusable logging manager built on top of Serilog.

## SerilogWpfDemo

This WPF application demonstrates how to use Serilog for logging events and exceptions. It includes a simple user interface with a button to perform an operation, which logs messages and exceptions based on the operation's outcome.

### Getting Started

To build and run the SerilogWpfDemo application:

1. Clone this repository.
2. Open the solution file in Visual Studio.
3. Set the `SerilogWpfDemo` project as the startup project.
4. Press F5 or click the "Start" button in Visual Studio.

### Usage

Click the "Perform Operation" button to simulate an operation. The application will log messages and exceptions depending on the operation's outcome.

## LoggingLibrary

LoggingLibrary is a .NET class library that provides a reusable logging manager built on top of Serilog. It can be used in other applications to simplify logging configuration and usage.

### Getting Started

To use the LoggingLibrary in your project:

1. Clone this repository.
2. Add a reference to the `LoggingLibrary` project in your solution.
3. Update your application code to use the `LoggerManager` class for logging.

### Usage

Create an instance of the `LoggerManager` class and use its methods to log messages with different log levels:

- `LogInformation(string messageTemplate, params object[] propertyValues)`
- `LogDebug(string messageTemplate, params object[] propertyValues)`
- `LogError(Exception exception, string messageTemplate, params object[] propertyValues)`

Call the `CloseAndFlush()` method to flush any remaining log entries and close the logger when your application exits.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
