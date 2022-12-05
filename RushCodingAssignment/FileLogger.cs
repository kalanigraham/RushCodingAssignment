using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace RushCodingAssignment
{
	public class FileLogger : IFileLogger
	{
		private const string fileName = "Log.txt";
		private bool loggingEnabled;
		private StreamWriter sw;

		public FileLogger() 
		{
			loggingEnabled= true;
			sw = new StreamWriter(fileName,true);
			sw.AutoFlush=true;
			sw.WriteLine("******************************************************************************************************");
		}

		public void ClearLog()
		{
			sw.Close();
			sw =new StreamWriter(fileName,false);
			sw.WriteLine("******************************************************************************************************");
			sw.AutoFlush = true;
		}

		public void DisableLogging()
		{
			LogInfo("Logging Disabled");
			loggingEnabled = false;
		}

		public void EnableLogging()
		{
			loggingEnabled=true;
			LogInfo("Logging Enabled");
		}

		public void LogDebug(string message)
		{
			DateTime date = DateTime.Now;
			var str = $"[{date}] DEBUG - {message}";
			sw.WriteLine(str);
		}

		public void LogError(string message)
		{
			DateTime date = DateTime.Now;
			var str = $"[{date}] ERROR - {message}";
			sw.WriteLine(str);
		}

		public void LogException(string message, Exception exception)
		{
			DateTime date = DateTime.Now;
			var str = $"[{date}] EXCEPTION - {message} Exception Message: {exception.Message} Stack Trace: {exception.StackTrace}";
			sw.WriteLine(str);
		}

		public void LogInfo(string message)
		{
			DateTime date = DateTime.Now;
			var str = $"[{date}] INFO - {message}";
			sw.WriteLine(str);
		}
	}
}
