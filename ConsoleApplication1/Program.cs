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
                //Console.WriteLine("Error {0}", e);
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
		// отдельный файл
		private List<string> exFilename { get; }
		// Читать файл целиком
		private List<bool> exFull { get; }
		// Читать все файлы в каталоге
		private bool exAllFileInDir { get; }
		// перевый символ в сетке excel
		private List<string> exFirstLetter { get; }
		// последний символ в сетке excel
		private List<string> exLastLetter { get; }
		// первая цифира в сетке excel
		private List<int> exFirstCell { get; }
		// последняя цифира в сетке excel
		private List<int> exLastCell { get; }

		//индивидуальные настройки для каждого файла CSV
		private bool indivCsvSettings { get; }
		//индивидуальные настройки для файлов excel
		private bool indivXlsxSettings { get; }

		//разделитель записей в CSV файле
		private List<char> csvDelimetr { get; }
		//десятичный разделитель в CSV файле
		private List<char> csvDecDelimetr { get; }

		public getConfig()
		{
			string defPath = (Environment.CurrentDirectory+@"\setings.cfg");
			try
			{   // Open the text file using a stream reader.
				if (!File.Exists(defPath)) {
					File.Create(defPath);
					using (StreamWriter sw = new StreamWriter(defPath)) {
						string cfgString = "#This file generated automaticly. Use \"true\" and \n"+
							"\"false\" for set boolean and letters and number for other. Use 0 for mark infinity" + 
							"indivXlsxSettings = false\n" +
							"indivCsvSettings = false\n" +
							"#Global parametrs:\n" +
							"exFull = false\n" + 
							"exFirstLetter = A\n" +
							"exLastLetter = I\n" +
							"exFirstCell = 1\n" +
							"exLastCell = 0\n" +
							"csvDelimetr = |" +
							"csvDecDelimetr = ." +
							"#Indial settings:" +
							"exFilename = " +
							"exFull = true" +
							"exFirstLetter = A\n" +
							"exLastLetter = I\n" +
							"exFirstCell = 1\n" +
							"exLastCell = 0\n" +
							"#Indial settings:" +


























					}
				}
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
