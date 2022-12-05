using System;
using System.Collections.Generic;
using System.Text;

namespace RushCodingAssignment
{
	public interface IFileLogger
	{
		void EnableLogging();
		void DisableLogging();
		void ClearLog();
		void LogInfo(string message);
		void LogDebug(string message);
		void LogError(string message);
		void LogException(string message, Exception exception);
	}
}
