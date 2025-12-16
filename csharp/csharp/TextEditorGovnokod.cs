using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DirtyTextEditorGovnokod
{
        public class TextEditorGovnokod
    {
        public static void ReadFileGovnokod(string filename)
        {
            try
            {
                                                string content = File.ReadAllText(filename);

                GlobalState.g_currentEditFile = filename;
                GlobalState.g_editor_buffer = content;
                GlobalState.g_unsaved_changes = false;
                GlobalState.g_total_file_reads++;

                Console.Clear();
                UIHelperGovnokod.PrintBorder("FILE CONTENT");
                Console.WriteLine($"  File: {filename}");
                Console.WriteLine($"  Size: {content.Length} bytes");
                UIHelperGovnokod.PrintSeparator();

                Console.WriteLine(content);

                UIHelperGovnokod.PrintSeparator();
                Console.WriteLine("\n  File loaded successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n  Error: {e.Message}\n");
            }
        }

        public static void EditFileGovnokod()
        {
            if (string.IsNullOrEmpty(GlobalState.g_currentEditFile))
            {
                Console.WriteLine("\n  Open file first!");
                return;
            }

            Console.Clear();
            UIHelperGovnokod.PrintBorder("EDIT FILE");
            Console.WriteLine($"  File: {GlobalState.g_currentEditFile}");
            Console.WriteLine($"  Size: {GlobalState.g_editor_buffer.Length} bytes");
            UIHelperGovnokod.PrintSeparator();
            Console.WriteLine("\n  Enter new content (EOF on new line to finish):");
            UIHelperGovnokod.PrintSeparator();

            string new_content = "";
            string line;

            while ((line = Console.ReadLine()) != "EOF")
            {
                                                new_content += line + "\n";
            }

            GlobalState.g_editor_buffer = new_content;
            GlobalState.g_unsaved_changes = true;

            Console.WriteLine("\n  Content modified (not saved)!");
        }

        public static void SaveFileGovnokod()
        {
            if (string.IsNullOrEmpty(GlobalState.g_currentEditFile))
            {
                Console.WriteLine("\n  No open file!");
                return;
            }

            Console.Clear();
            UIHelperGovnokod.PrintBorder("SAVE FILE");
            Console.WriteLine($"  File: {GlobalState.g_currentEditFile}");
            Console.WriteLine($"  Size: {GlobalState.g_editor_buffer.Length} bytes");
            UIHelperGovnokod.PrintSeparator();

            try
            {
                File.WriteAllText(GlobalState.g_currentEditFile, GlobalState.g_editor_buffer);

                GlobalState.g_total_file_writes++;
                GlobalState.g_unsaved_changes = false;

                Console.WriteLine("  File saved successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"  Error: {e.Message}");
            }
        }

        public static void CreateBackupGovnokod()
        {
            if (string.IsNullOrEmpty(GlobalState.g_currentEditFile))
            {
                Console.WriteLine("\n  No open file!");
                return;
            }

            Console.Clear();
            UIHelperGovnokod.PrintBorder("CREATE BACKUP");
            Console.WriteLine($"  File: {GlobalState.g_currentEditFile}");
            UIHelperGovnokod.PrintSeparator();

            try
            {
                                                string backup_name = GlobalState.g_currentEditFile + ".backup";
                File.WriteAllText(backup_name, GlobalState.g_editor_buffer);

                Console.WriteLine($"  Backup created: {backup_name}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"  Error: {e.Message}");
            }
        }
    }
}
