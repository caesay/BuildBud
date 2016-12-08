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
        void LogMessage(string message, params object[] messageArgs);
        void LogMessage(MessageSeverity importance, string message, params object[] messageArgs);
        void LogMessage(string subcategory, string code, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, MessageSeverity importance, string message, params object[] messageArgs);
        void LogCriticalMessage(string subcategory, string code, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string message, params object[] messageArgs);
        void LogMessageFromResources(string messageResourceName, params object[] messageArgs);
        void LogMessageFromResources(MessageSeverity importance, string messageResourceName, params object[] messageArgs);
        void LogExternalProjectStarted(string message, string helpKeyword, string projectFile, string targetNames);
        void LogExternalProjectFinished(string message, string helpKeyword, string projectFile, bool succeeded);
        void LogCommandLine(string commandLine);
        void LogCommandLine(MessageSeverity importance, string commandLine);
        void LogError(string message, params object[] messageArgs);
        void LogError(string subcategory, string errorCode, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string message, params object[] messageArgs);
        void LogErrorFromResources(string messageResourceName, params object[] messageArgs);
        void LogErrorFromResources(string subcategoryResourceName, string errorCode, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName, params object[] messageArgs);
        void LogErrorWithCodeFromResources(string messageResourceName, params object[] messageArgs);
        void LogErrorWithCodeFromResources(string subcategoryResourceName, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName, params object[] messageArgs);
        void LogErrorFromException(Exception exception);
        void LogErrorFromException(Exception exception, bool showStackTrace);
        void LogErrorFromException(Exception exception, bool showStackTrace, bool showDetail, string file);
        void LogWarning(string message, params object[] messageArgs);
        void LogWarning(string subcategory, string warningCode, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string message, params object[] messageArgs);
        void LogWarningFromResources(string messageResourceName, params object[] messageArgs);
        void LogWarningFromResources(string subcategoryResourceName, string warningCode, string helpKeyword, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName, params object[] messageArgs);
        void LogWarningWithCodeFromResources(string messageResourceName, params object[] messageArgs);
        void LogWarningWithCodeFromResources(string subcategoryResourceName, string file, int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName, params object[] messageArgs);
        void LogWarningFromException(Exception exception);
        void LogWarningFromException(Exception exception, bool showStackTrace);
        bool LogMessagesFromFile(string fileName);
        bool LogMessagesFromFile(string fileName, MessageSeverity messageImportance);
        bool LogMessagesFromStream(TextReader stream, MessageSeverity messageImportance);
        bool LogMessageFromText(string lineOfText, MessageSeverity messageImportance);
    }
}