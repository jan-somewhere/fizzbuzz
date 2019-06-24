﻿using System;
using System.IO;
using Microsoft.Extensions.Logging;

public class CustomLogger : Exception {

    private static ILogger _logger = null;
    private static string path = null;

    public static void Init(ILogger logger) {
        _logger = logger;
        path = System.AppDomain.CurrentDomain.BaseDirectory + "log.txt";

        if (!File.Exists(path)) {
            var file = File.Create(path);
            file.Close();
        }
    }

    public static void LogInformation(string message) {
        _logger.LogInformation(message);
        WriteToLog("Info: " + message);
    }
    public static void LogWarning(string message) {
        _logger.LogWarning(message);
        WriteToLog("Warning: " + message);
    }

    public static void LogError(string message) {
        _logger.LogError(message);
        WriteToLog("Error: " + message);
    }
    public static void LogDebug(string message) {
        _logger.LogError(message);
        WriteToLog("Debug: " + message);
    }

    private static void WriteToLog(string message) {
        using (StreamWriter sw = File.AppendText(path)) {
            sw.WriteLine(DateTime.Now.ToString() + " " + message);
        }
    }

    public static string GetLogPath() {
        return path;
    }
}