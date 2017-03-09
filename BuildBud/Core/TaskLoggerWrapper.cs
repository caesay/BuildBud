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

        public void LogMessage(string message)
        {
            _log.LogMessage(message);
        }

        public void LogMessage(MessageSeverity importance, string message)
        {
            _log.LogMessage((MessageImportance)importance, message);
        }

        public void LogMessage(string subcategory, string code, string helpKeyword, string file, int lineNumber, int columnNumber,
            int endLineNumber, int endColumnNumber, MessageSeverity importance, string message)
        {
            _log.LogMessage(subcategory, code, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, importance, message);
        }

        public void LogCriticalMessage(string subcategory, string code, string helpKeyword, string file, int lineNumber,
            int columnNumber, int endLineNumber, int endColumnNumber, string message)
        {
            _log.LogCriticalMessage(subcategory, code, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, message);
        }

        public void LogMessageFromResources(string messageResourceName)
        {
            _log.LogMessageFromResources(messageResourceName);
        }

        public void LogMessageFromResources(MessageSeverity importance, string messageResourceName)
        {
            _log.LogMessageFromResources((MessageImportance)importance, messageResourceName);
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

        public void LogError(string message)
        {
            _log.LogError(message);
        }

        public void LogError(string subcategory, string errorCode, string helpKeyword, string file, int lineNumber, int columnNumber,
            int endLineNumber, int endColumnNumber, string message)
        {
            _log.LogError(subcategory, errorCode, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, message);
        }

        public void LogErrorFromResources(string messageResourceName)
        {
            _log.LogErrorFromResources(messageResourceName);
        }

        public void LogErrorFromResources(string subcategoryResourceName, string errorCode, string helpKeyword, string file,
            int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName)
        {
            _log.LogErrorFromResources(subcategoryResourceName, errorCode, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, messageResourceName);
        }

        public void LogErrorWithCodeFromResources(string messageResourceName)
        {
            _log.LogErrorWithCodeFromResources(messageResourceName);
        }

        public void LogErrorWithCodeFromResources(string subcategoryResourceName, string file, int lineNumber, int columnNumber,
            int endLineNumber, int endColumnNumber, string messageResourceName)
        {
            _log.LogErrorWithCodeFromResources(subcategoryResourceName, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, messageResourceName);
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

        public void LogWarning(string message)
        {
            _log.LogWarning(message);
        }

        public void LogWarning(string subcategory, string warningCode, string helpKeyword, string file, int lineNumber,
            int columnNumber, int endLineNumber, int endColumnNumber, string message)
        {
            _log.LogWarning(subcategory, warningCode, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, message);
        }

        public void LogWarningFromResources(string messageResourceName)
        {
            _log.LogWarningFromResources(messageResourceName);
        }

        public void LogWarningFromResources(string subcategoryResourceName, string warningCode, string helpKeyword, string file,
            int lineNumber, int columnNumber, int endLineNumber, int endColumnNumber, string messageResourceName)
        {
            _log.LogWarningFromResources(subcategoryResourceName, warningCode, helpKeyword, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, messageResourceName);
        }

        public void LogWarningWithCodeFromResources(string messageResourceName)
        {
            _log.LogWarningWithCodeFromResources(messageResourceName);
        }

        public void LogWarningWithCodeFromResources(string subcategoryResourceName, string file, int lineNumber, int columnNumber,
            int endLineNumber, int endColumnNumber, string messageResourceName)
        {
            _log.LogWarningWithCodeFromResources(subcategoryResourceName, file, lineNumber, columnNumber, endLineNumber, endColumnNumber, messageResourceName);
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
