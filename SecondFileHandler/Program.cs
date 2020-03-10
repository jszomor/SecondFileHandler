using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondFileHandler
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Kérem a file nevét.");
			string inputFile = Console.ReadLine();

			FileStream fileStream = new FileStream(inputFile, FileMode.Open, FileAccess.ReadWrite);
			byte[] fileBuffer = new byte[1024];
			int fileData;
			long p = 0;
			while((fileData = fileStream.Read(fileBuffer, 0, 1024))>0)
			{
				for (int i = 0; i < fileBuffer.Length; i++)
				{
					if (fileBuffer[i] == 32)
						fileBuffer[i] = 95;
				}
				fileStream.Position = p;
				fileStream.Write(fileBuffer, 0, fileData);
				p = fileStream.Position;
			}
			fileStream.Close();
		}
	}
}
