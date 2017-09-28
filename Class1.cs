using System;

/*public workCode()
{
	string defPath = Environment.CurrentDirectory;
	var tmpVar = Directory.GetFiles(defPath, @"*.xlsx");
	foreach (var tmpFname in tmpVar)
	{
		exPath.Add(tmpVar.ToString());
	}
	exEdit = false;

}*/

public void getExBookCells()
{
	foreach (string exExl in exPath)
	{
		exBook.Add(SpreadsheetDocument.Open(exExl, false/*exEdit*/));
	}
}


	/*class getConfig
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
	}*/
}