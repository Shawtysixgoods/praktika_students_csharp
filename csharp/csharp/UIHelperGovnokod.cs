using System;
using System.Collections.Generic;

namespace DirtyTextEditorGovnokod
{
        public static class UIHelperGovnokod
    {
        public static void PrintBorder(string title = "")
        {
            Console.Write("  ");
            for (int i = 0; i < 76; i++) Console.Write("=");
            Console.WriteLine();

            if (!string.IsNullOrEmpty(title))
            {
                int padding = (76 - title.Length) / 2;
                Console.Write("  |");
                for (int i = 0; i < padding; i++) Console.Write(" ");
                Console.Write(title);
                for (int i = padding + title.Length; i < 76; i++) Console.Write(" ");
                Console.WriteLine("|");
                Console.Write("  ");
                for (int i = 0; i < 76; i++) Console.Write("=");
                Console.WriteLine();
            }
        }

        public static void PrintSeparator()
        {
            Console.Write("  ");
            for (int i = 0; i < 76; i++) Console.Write("-");
            Console.WriteLine();
        }

        public static void PrintFileTableHeader()
        {
            Console.Write("  " + "N".PadRight(4));
            Console.Write("Name".PadRight(40));
            Console.Write("Size".PadRight(15));
            Console.WriteLine("Type");
            PrintSeparator();
        }

        public static void PrintFileRow(int index, string name, bool isDir, long size)
        {
            Console.Write("  " + index.ToString().PadRight(4));

            string display_name = name;
            if (name.Length > 36)
            {
                display_name = name.Substring(0, 33) + "...";
            }

            Console.Write(display_name.PadRight(40));

            if (isDir)
            {
                Console.Write("-".PadRight(15));
                Console.WriteLine("Folder");
            }
            else
            {
                string size_str = "";
                                                if (size < 1024)
                {
                    size_str = size.ToString() + " B";
                }
                else if (size < 1024 * 1024)
                {
                    size_str = (size / 1024).ToString() + " KB";
                }
                else
                {
                    size_str = (size / (1024 * 1024)).ToString() + " MB";
                }

                Console.Write(size_str.PadRight(15));
                Console.WriteLine("File");
            }
        }

        public static void DisplayMainMenu()
        {
            PrintBorder("MAIN MENU");

            Console.WriteLine("  1.  Read file");
            Console.WriteLine("  2.  Edit file");
            Console.WriteLine("  3.  Save file");
            Console.WriteLine("  4.  Search in file");
            Console.WriteLine("  5.  Delete file");
            Console.WriteLine("  6.  Create new file");
            Console.WriteLine("  7.  Go to folder");
            Console.WriteLine("  8.  Copy file");
            Console.WriteLine("  9.  Rename file");
            Console.WriteLine("  10. File analysis");
            Console.WriteLine("  11. Backup");
            PrintSeparator();
            Console.WriteLine("  99. Exit");
            PrintBorder();
        }

        public static void DisplayFileList()
        {
            PrintBorder("SODERZHIMOE KATALOGA");
            Console.WriteLine($"  Path: {GlobalState.g_currentDirectory}");
            Console.WriteLine($"  Elements: {GlobalState.g_currentFiles.Count}");
            PrintSeparator();

            if (GlobalState.g_currentFiles.Count == 0)
            {
                Console.WriteLine("  Folder is empty");
                PrintSeparator();
                return;
            }

            PrintFileTableHeader();

            for (int i = 0; i < GlobalState.g_currentFiles.Count; i++)
            {
                string full_path = System.IO.Path.Combine(GlobalState.g_currentDirectory, GlobalState.g_currentFiles[i]);
                bool isDir = false;
                long size = 0;

                if (System.IO.Directory.Exists(full_path))
                {
                    isDir = true;
                }
                else if (System.IO.File.Exists(full_path))
                {
                    try
                    {
                        size = new System.IO.FileInfo(full_path).Length;
                    }
                    catch
                    {
                                                                        size = 0;
                    }
                }

                PrintFileRow(i + 1, GlobalState.g_currentFiles[i], isDir, size);
            }

            PrintSeparator();
        }
    }
}
