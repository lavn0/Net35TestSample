using System.Xml.XPath;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using TestMethodBase = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Net35TestSample
{
	public class TestMethodAttribute : TestMethodBase
	{
		public override TestResult[] Execute(ITestMethod testMethod)
		{
			const string mstestPath = @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\mstest.exe";
			string fullName = testMethod.MethodInfo.DeclaringType.FullName + "." + testMethod.TestMethodName;
			string resultsFile = Path.GetFullPath(fullName + ".trx");
			string assemblyFile = Path.GetFullPath("UnitTestLibrary.dll");
			string assemblyDir = Path.GetDirectoryName(assemblyFile);

			if (File.Exists(resultsFile))
			{
				File.Delete(resultsFile);
			}

			var processInfo = new ProcessStartInfo()
			{
				FileName = mstestPath,
				WorkingDirectory = assemblyDir,
				Arguments = string.Join(
					" ",
					$@"/testcontainer:""{assemblyFile}""",
					$@"/test:""{fullName}""",
					$@"/resultsfile:""{resultsFile}"""),
			};

			var process = Process.Start(processInfo);
			process.WaitForExit();
			if (process.ExitCode != 0)
			{
				return new[] { new TestResult { Outcome = UnitTestOutcome.Error } };
			}

			string reportxml = File.ReadAllText(resultsFile); // mstestのレポート出力ファイルから読みだす
			var xdoc = XDocument.Parse(reportxml);
			string outcome = ((IEnumerable<object>)xdoc.XPathEvaluate($"//*[local-name()='UnitTestResult'][@testName='{testMethod.TestMethodName}']/@outcome")).OfType<XAttribute>().Select(a => (string)a).First();
			string duration = ((IEnumerable<object>)xdoc.XPathEvaluate($"//*[local-name()='UnitTestResult'][@testName='{testMethod.TestMethodName}']/@duration")).OfType<XAttribute>().Select(a => (string)a).First();

			var testResult = new TestResult()
			{
				Outcome = (UnitTestOutcome)System.Enum.Parse(typeof(UnitTestOutcome), outcome, false),
				Duration = System.TimeSpan.Parse(duration),
			};
			// TODO: xdocからtestReusltのパラメータに詰める
			return new[] { testResult };
		}
	}
}
