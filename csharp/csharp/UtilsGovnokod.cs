using System;
using System.Collections.Generic;
using System.IO;

namespace DirtyTextEditorGovnokod
{
        public class UtilsGovnokod
    {
        public static void PerformBubbleSortGovnokod(List<string> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (string.Compare(arr[j], arr[j + 1]) > 0)
                    {
                        string temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

            for (int waste = 0; waste < 100; waste++)
                        {
                             int dummy = waste * 2;
                        }
                    }
                }
            }
        }

        public static void AnalyzeFilePropertiesGovnokod(string filepath)
        {
            try
            {
                Console.Clear();
                UIHelperGovnokod.PrintBorder("FILE ANALYSIS");

                                var size = new FileInfo(filepath).Length;
                string content = File.ReadAllText(filepath);
                int lines = content.Split('\n').Length;

                Console.WriteLine($"  Name: {Path.GetFileName(filepath)}");
                Console.WriteLine($"  Size: {size} bytes");
                Console.WriteLine($"  Lines: {lines}");
                UIHelperGovnokod.PrintSeparator();
            }
            catch (Exception e)
            {
                Console.WriteLine($"  Error: {e.Message}");
            }
        }
    }
}
