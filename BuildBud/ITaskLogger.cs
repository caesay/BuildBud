using System;
using System.IO;
using System.Resources;
using System.Runtime.Remoting;
using Microsoft.Build.Framework;

namespace BuildBud
{
    public enum MessageSeverity
    {
        High,
        Normal,
        Low,
    }

    public interface ITaskLogger
    {
        bool HasLoggedErrors { get; }
        string ExtractMessageCode(string message, out string messageWithoutCodePrefix);
        string FormatResourceString(string resourceName, params object[] args);
        string FormatString(string unformatted, params object[] args);
        string GetResourceMessage(string resourceName);
        void LogMessage(string message);
        void LogMessage(MessageSeverity importance, string message);
        void LogMessage(string subcategory, string code, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, MessageSeverity importance, string message);
        void LogCriticalMessage(string subcategory, string code, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string message);
        void LogMessageFromResources(string messageResourceName);
        void LogMessageFromResources(MessageSeverity importance, string messageResourceName);
        void LogExternalProjectStarted(string message, string helpKeyword, string projectFile, string targetNames);
        void LogExternalProjectFinished(string message, string helpKeyword, string projectFile, bool succeeded);
        void LogCommandLine(string commandLine);
        void LogCommandLine(MessageSeverity importance, string commandLine);
        void LogError(string message);
        void LogError(string subcategory, string errorCode, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string message);
        void LogErrorFromResources(string messageResourceName);
        void LogErrorFromResources(string subcategoryResourceName, string errorCode, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName);
        void LogErrorWithCodeFromResources(string messageResourceName);
        void LogErrorWithCodeFromResources(string subcategoryResourceName, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName);
        void LogErrorFromException(Exception exception);
        void LogErrorFromException(Exception exception, bool showStackTrace);
        void LogErrorFromException(Exception exception, bool showStackTrace, bool showDetail, string file);
        void LogWarning(string message);
        void LogWarning(string subcategory, string warningCode, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string message);
        void LogWarningFromResources(string messageResourceName);
        void LogWarningFromResources(string subcategoryResourceName, string warningCode, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName);
        void LogWarningWithCodeFromResources(string messageResourceName);
        void LogWarningWithCodeFromResources(string subcategoryResourceName, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName);
        void LogWarningFromException(Exception exception);
        void LogWarningFromException(Exception exception, bool showStackTrace);
        bool LogMessagesFromFile(string fileName);
        bool LogMessagesFromFile(string fileName, MessageSeverity messageImportance);
        bool LogMessagesFromStream(TextReader stream, MessageSeverity messageImportance);
        bool LogMessageFromText(string lineOfText, MessageSeverity messageImportance);
    }
}