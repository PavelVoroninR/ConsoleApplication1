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
	class xmlConfig
	{
		private List<string> exFilename { get; }
		private List<bool> exFull { get; }
		private bool exAllFileInDir { get; }
		private List<string> exFirstLetter { get; }
		private List<string> exLastLetter { get; }
		private List<int> exFirstCell { get; }
		private List<int> exLastCell { get; }

		private bool indivSettings { get; } 

		private List<char> csvDelimetr { get; }
		private List<char> csvDecDelimetr { get; }

		public xmlConfig()
		{
			string defPath = Environment.CurrentDirectory;
			if (File.Exists((defPath+ @"\setings.xml")))
			{
				XmlDocument XMLConfig = new XmlDocument();
				XMLConfig.
			} else
			{

			}
		}
	}
}
