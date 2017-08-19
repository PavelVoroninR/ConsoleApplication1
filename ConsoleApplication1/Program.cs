using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Xml;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			string curDir = Environment.CurrentDirectory;
			string exPath;
			try
			{
				if (args != null)
				{
					exPath = args[0];
					if (Directory.Exists(exPath))
					{
						Console.WriteLine("Used Path {0}", exPath);
					}
					else {
						Console.WriteLine("Used current directory Path {0}", curDir);
						exPath = curDir;
					}
				}
				else
				{
					exPath = curDir;				
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Error {0}", e);
				exPath = curDir;
				Console.WriteLine("Used Path {0}", curDir);
			}
			getConfig cfg = new getConfig();
			Console.ReadKey();
		}
	}
	class workCode
	{
		private List<string> exPath { get; set; }
		private List<string> bufCellVal = new List<string>();
		private List<SpreadsheetDocument> exBook;
		private bool exEdit { get; set; }
		private bool endDocStream {get; }

		public workCode()
		{
			string defPath = Environment.CurrentDirectory;
			var tmpVar = Directory.GetFiles(defPath, @"*.xlsx");
			foreach (var tmpFname in tmpVar)
			{
				exPath.Add(tmpVar.ToString());
			}
			exEdit = false;

		}

		public void getExBookCells()
		{
			foreach (string exExl in exPath)
			{
				exBook.Add(SpreadsheetDocument.Open(exExl, false/*exEdit*/));
			}		
		}

	}
	class getConfig
	{
		private List<string> exFilename { get; }
		private List<bool> exFull { get; }
		private bool exAllFileInDir { get; }
		private List<string> exFirstLetter { get; }
		private List<string> exLastLetter { get; }
		private List<int> exFirstCell { get; }
		private List<int> exLastCell { get; }

		private bool indivCsvSettings { get; }
		private bool indivXlsxSettings { get; }

		private List<char> csvDelimetr { get; }
		private List<char> csvDecDelimetr { get; }

		public getConfig()
		{
			string defPath = (Environment.CurrentDirectory+@"\setings.cfg");
			try
			{   // Open the text file using a stream reader.
				using (StreamReader sr = new StreamReader(defPath))
				{
					// Read the stream to a string, and write the string to the console.
					String line = sr.ReadToEnd();
					Console.WriteLine(line);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(e.Message);
			}
		}
	}
}
