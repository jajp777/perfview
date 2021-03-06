﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinuxTracing.Tests
{
	public static class Constants
	{
		public static readonly string SourceFolder = @"Sources\";
		public static readonly string OutputFolder = @"Outputs\";

		public static string GetTestingFilePath(string filename)
		{
			return Path.Combine(Environment.CurrentDirectory, SourceFolder, filename);
		}

		public static string GetTestingPerfDumpPath(string filename)
		{
			return Path.Combine(Environment.CurrentDirectory, SourceFolder, string.Format("{0}.perf.data.dump", filename));
		}

		public static string GetOutputPath(string filename)
		{
			return Path.Combine(Environment.CurrentDirectory, OutputFolder, string.Format("{0}", filename));
		}

		public static void WaitUntilFileIsReady(string fileName)
		{
			while (!IsFileReady(fileName))
			{
				Thread.Sleep(50);
			}
		}

		public static bool IsFileReady(string fileName)
		{
			try
			{
				// Still doesn't resolve the problem - kind of weird
				return new FileInfo(fileName).Length > 0;
			}
			catch (IOException)
			{
				return false;
			}
		}
	}
}
