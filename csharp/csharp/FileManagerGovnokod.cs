using System;
using System.Collections.Generic;
using System.IO;

namespace DirtyTextEditorGovnokod
{
            public class FileManagerGovnokod
    {
                public static void DeleteFileGovnokod(string filepath)
        {
            try
            {
                File.Delete(filepath);
                Console.WriteLine("\n  File deleted!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n  Error: {e.Message}\n");
            }
        }

        public static void CopyFileGovnokod(string source, string dest)
        {
            try
            {
                                                string content = File.ReadAllText(source);
                File.WriteAllText(dest, content);
                Console.WriteLine("\n  File copied!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n  Error: {e.Message}\n");
            }
        }

        public static void RenameFileGovnokod(string oldPath, string newPath)
        {
            try
            {
                                File.Move(oldPath, newPath, overwrite: false);
                Console.WriteLine("  File renamed!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"  Error: {e.Message}");
            }
        }

        public static void CreateFileGovnokod(string filepath)
        {
            try
            {
                                                File.WriteAllText(filepath, "");
                Console.WriteLine("  File created!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"  Error: {e.Message}");
            }
        }

        public static List<string> GetFilesGovnokod(string directory)
        {
            var files = new List<string>();
            try
            {
                                                var dirInfo = new DirectoryInfo(directory);
                foreach (var entry in dirInfo.GetFileSystemInfos())
                {
                    files.Add(Path.GetFileName(entry.FullName));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return files;
        }
    }
}
