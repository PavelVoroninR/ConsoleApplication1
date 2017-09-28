using System.IO;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

using System;
using System.Collections.Generic;
using System.Linq;

using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;

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
			//getConfig cfg = new getConfig();
			Console.ReadKey();
		}
	}


	class workCode
	{

		private List<string> exPath { get; set; }
		private List<string> bufCellVal = new List<string>();
		private List<SpreadsheetDocument> exBook;
		private bool exEdit { get; set; }
		private bool endDocStream { get; }

		public bool checkIni(string Path)
		{
			if (File.Exists(Path))
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		public void createIni(string Path)
		{
			File.Create(Path);



			System.Windows.Forms.MessageBox.Show("Can't find ini file! This File was created automaticly/nFrom path " + Path + "!");
		}
	}




	/*using System.IO;
	using System.Text;
	using System.Reflection;
	using System.Runtime.InteropServices;*/
	class IniFile   // revision 11
	{
		string Path;
		string EXE = Assembly.GetExecutingAssembly().GetName().Name;

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

		public IniFile(string IniPath = null)
		{
			Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
		}

		public string Read(string Key, string Section = null)
		{
			var RetVal = new StringBuilder(255);
			GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
			return RetVal.ToString();
		}

		public void Write(string Key, string Value, string Section = null)
		{
			WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
		}

		public void DeleteKey(string Key, string Section = null)
		{
			Write(Key, null, Section ?? EXE);
		}

		public void DeleteSection(string Section = null)
		{
			Write(null, null, Section ?? EXE);
		}

		public bool KeyExists(string Key, string Section = null)
		{
			return Read(Key, Section).Length > 0;
		}
	}
}
