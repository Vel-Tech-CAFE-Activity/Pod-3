# LogPlugin Application


## Overview

LogPlugin is a dynamic, robust logging application. Developed using .NET 6.0 and the Serilog library, LogPlugin is designed to handle complex logging scenarios and deliver detailed insights into your application's performance and behavior.

## Features

- Utilizes Serilog for extensive and feature-rich logging data
- Captures and records detailed logs concerning user, system, and process information
- Supports seven different levels of log events, giving a fine-grained control over log management
- Concurrently saves logs in separate files and a Microsoft SQL Server database for easy access and redundancy
- Provides a user-friendly UI for in-depth log analysis and filtering
- Incorporates security features, including API key middleware to ensure secure log data access

## Info

There two applications in the repository.
1. LogGenerator : For testing the main logging application
2. LogPlugin-main : The main logging application


## Installation

To install and run the application:

1. Download and install Microsoft SQL Server
2. Clone the repository and navigate to `LogPlugin-main`
3. Change the DB connection string in the appsettings.json file.
4. Run `dotnet build` to build the application
5. Run `dotnet run` to start the application
6. The application will be hosted at `https://localhost:5001` or `http://localhost:5000`

## Usage

After starting the application, you can navigate to `https://localhost:5001` (or `http://localhost:5000`) in your web browser. The UI will show the logs recorded by the application. You can filter the logs by various parameters such as time, level, and source.

Logs are saved into the Microsoft SQL Server database and also in daily log files under the `/Logs` directory in the application root. Old logs are automatically purged to save storage.

## Tests

LogPlugin uses Xunit for unit testing. To execute the tests, navigate to the project root directory in your terminal and run `dotnet test`.

## Database Maintenance

The application includes a built-in scheduler that periodically deletes old data from the Microsoft SQL Server database and old log files. This ensures the application storage remains optimized.

## License

This project is licensed under the MIT License.

## Contact

If you have any questions, feedback, or issues, please feel free to reach us at `aniket.kr1030@gmail.com`.
