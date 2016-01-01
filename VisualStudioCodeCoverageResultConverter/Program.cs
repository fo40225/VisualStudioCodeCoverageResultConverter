using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Coverage.Analysis;

namespace VisualStudioCodeCoverageResultConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0 || args.SelectMany(x => x).Contains('?'))
            {
                string help = @"usage: VisualStudioCodeCoverageResultConverter.exe /input:data.coverage /output:Result.coveragexml";
                Console.WriteLine(help);
            }
            else
            {
                string input = args.Where(x => x.StartsWith("/input:", StringComparison.OrdinalIgnoreCase))
                    .Select(x => Regex.Replace(x, "/input:", string.Empty, RegexOptions.IgnoreCase)).First();
                string output = args.Where(x => x.StartsWith("/output:", StringComparison.OrdinalIgnoreCase))
                    .Select(x => Regex.Replace(x, "/output:", string.Empty, RegexOptions.IgnoreCase)).First();
                using (CoverageInfo info = CoverageInfo.CreateFromFile(input))
                {
                    info.BuildDataSet().ExportXml(output);
                }
            }
        }
    }
}