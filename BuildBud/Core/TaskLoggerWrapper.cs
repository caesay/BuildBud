using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace BuildBud.Core
{
    internal class TaskLoggerWrapper : MarshalByRefObject, ITaskLogger
    {
        private readonly TaskLoggingHelper _log;
        public TaskLoggerWrapper(TaskLoggingHelper log)
        {
            _log = log;
        }

        public bool HasLoggedErrors
        {
            get { return _log.HasLoggedErrors; }
        }

        public string ExtractMessageCode(string message, out string messageWithoutCodePrefix)
        {
            return _log.ExtractMessageCode(message, out messageWithoutCodePrefix);
        }

        public string FormatResourceString(string resourceName, params object[] args)
        {
            return _log.FormatResourceString(resourceName, args);
        }

        public string FormatString(string unformatted, params object[] args)
        {
            return _log.FormatString(unformatted, args);
        }

        public string GetResourceMessage(string resourceName)
        {
            return _log.GetResourceMessage(resourceName);
        }

        public void LogMessage(string message, params object[] messageArgs)
        {
            _log.LogMessage(message, messageArgs);
        }

        public void LogMessage(MessageSeverity importance, string message, params object[] messageArgs)
        {
            _log.LogMessage((MessageImportance)importance, message, messageArgs);
        }

        public void LogMessage(string subcategory, string code, string helpKeyword, string file, int lineNumber, int columnNumber,
            int endLineNumber, int endColumnNumber, MessageSeverity importance, string message, params object[] messageArgs)
        {
            _log.LogMessage(subcategory, code, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, importance, message, messageArgs);
        }

        public void LogCriticalMessage(string subcategory, string code, string helpKeyword, string file, int lineNumber,
            int columnNumber, int endLineNumber, int endColumnNumber, string message, params object[] messageArgs)
        {
            _log.LogCriticalMessage(subcategory, code, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, message, messageArgs);
        }

        public void LogMessageFromResources(string messageResourceName, params object[] messageArgs)
        {
            _log.LogMessageFromResources(messageResourceName, messageArgs);
        }

        public void LogMessageFromResources(MessageSeverity importance, string messageResourceName, params object[] messageArgs)
        {
            _log.LogMessageFromResources((MessageImportance)importance, messageResourceName, messageArgs);
        }

        public void LogExternalProjectStarted(string message, string helpKeyword, string projectFile, string targetNames)
        {
            _log.LogExternalProjectStarted(message, helpKeyword, projectFile, targetNames);
        }

        public void LogExternalProjectFinished(string message, string helpKeyword, string projectFile, bool succeeded)
        {
            _log.LogExternalProjectFinished(message, helpKeyword, projectFile, succeeded);
        }

        public void LogCommandLine(string commandLine)
        {
            _log.LogCommandLine(commandLine);
        }

        public void LogCommandLine(MessageSeverity importance, string commandLine)
        {
            _log.LogCommandLine((MessageImportance)importance, commandLine);
        }

        public void LogError(string message, params object[] messageArgs)
        {
            _log.LogError(message, messageArgs);
        }

        public void LogError(string subcategory, string errorCode, string helpKeyword, string file, int lineNumber, int columnNumber,
            int endLineNumber, int endColumnNumber, string message, params object[] messageArgs)
        {
            _log.LogError(subcategory, errorCode, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, message, messageArgs);
        }

        public void LogErrorFromResources(string messageResourceName, params object[] messageArgs)
        {
            _log.LogErrorFromResources(messageResourceName, messageArgs);
        }

        public void LogErrorFromResources(string subcategoryResourceName, string errorCode, string helpKeyword, string file,
            int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName,
            params object[] messageArgs)
        {
            _log.LogErrorFromResources(subcategoryResourceName, errorCode, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, messageResourceName, messageArgs);
        }

        public void LogErrorWithCodeFromResources(string messageResourceName, params object[] messageArgs)
        {
            _log.LogErrorWithCodeFromResources(messageResourceName, messageArgs);
        }

        public void LogErrorWithCodeFromResources(string subcategoryResourceName, string file, int lineNumber, int columnNumber,
            int endLineNumber, int endColumnNumber, string messageResourceName, params object[] messageArgs)
        {
            _log.LogErrorWithCodeFromResources(subcategoryResourceName, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, messageResourceName, messageArgs);
        }

        public void LogErrorFromException(Exception exception)
        {
            _log.LogErrorFromException(exception);
        }

        public void LogErrorFromException(Exception exception, bool showStackTrace)
        {
            _log.LogErrorFromException(exception, showStackTrace);
        }

        public void LogErrorFromException(Exception exception, bool showStackTrace, bool showDetail, string file)
        {
            _log.LogErrorFromException(exception, showStackTrace, showDetail, file);
        }

        public void LogWarning(string message, params object[] messageArgs)
        {
            _log.LogWarning(message, messageArgs);
        }

        public void LogWarning(string subcategory, string warningCode, string helpKeyword, string file, int lineNumber,
            int columnNumber, int endLineNumber, int endColumnNumber, string message, params object[] messageArgs)
        {
            _log.LogWarning(subcategory, warningCode, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, message, messageArgs);
        }

        public void LogWarningFromResources(string messageResourceName, params object[] messageArgs)
        {
            _log.LogWarningFromResources(messageResourceName, messageArgs);
        }

        public void LogWarningFromResources(string subcategoryResourceName, string warningCode, string helpKeyword, string file,
            int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName,
            params object[] messageArgs)
        {
            _log.LogWarningFromResources(subcategoryResourceName, warningCode, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, messageResourceName, messageArgs);
        }

        public void LogWarningWithCodeFromResources(string messageResourceName, params object[] messageArgs)
        {
            _log.LogWarningWithCodeFromResources(messageResourceName, messageArgs);
        }

        public void LogWarningWithCodeFromResources(string subcategoryResourceName, string file, int lineNumber, int columnNumber,
            int endLineNumber, int endColumnNumber, string messageResourceName, params object[] messageArgs)
        {
            _log.LogWarningWithCodeFromResources(subcategoryResourceName, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, messageResourceName, messageArgs);
        }

        public void LogWarningFromException(Exception exception)
        {
            _log.LogWarningFromException(exception);
        }

        public void LogWarningFromException(Exception exception, bool showStackTrace)
        {
            _log.LogWarningFromException(exception, showStackTrace);
        }

        public bool LogMessagesFromFile(string fileName)
        {
            return _log.LogMessagesFromFile(fileName);
        }

        public bool LogMessagesFromFile(string fileName, MessageSeverity messageImportance)
        {
            return _log.LogMessagesFromFile(fileName, (MessageImportance)messageImportance);
        }

        public bool LogMessagesFromStream(TextReader stream, MessageSeverity messageImportance)
        {
            return _log.LogMessagesFromStream(stream, (MessageImportance)messageImportance);
        }

        public bool LogMessageFromText(string lineOfText, MessageSeverity messageImportance)
        {
            return _log.LogMessageFromText(lineOfText, (MessageImportance)messageImportance);
        }
    }
}
