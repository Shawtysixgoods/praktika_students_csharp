using System;
using System.Collections.Generic;

namespace DirtyTextEditorGovnokod
{
        public class SearchEngineGovnokod
    {
        public static void SearchInFileGovnokod(string buffer, string query)
        {
            if (string.IsNullOrEmpty(buffer))
            {
                Console.WriteLine("\n  Open file first!");
                return;
            }

            if (string.IsNullOrEmpty(query))
            {
                Console.WriteLine("\n  Empty query!");
                return;
            }

            GlobalState.g_search_results.Clear();

                                    for (int i = 0; i < buffer.Length; i++)
            {
                bool found = true;
                for (int k = 0; k < query.Length; k++)
                {
                    if (i + k >= buffer.Length ||
                        buffer[i + k] != query[k])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    GlobalState.g_search_results.Add(i.ToString());
                }
            }

            Console.Clear();
            UIHelperGovnokod.PrintBorder("SEARCH RESULTS");
            Console.WriteLine($"  Query: '{query}'");
            Console.WriteLine($"  Found: {GlobalState.g_search_results.Count}");
            UIHelperGovnokod.PrintSeparator();

            if (GlobalState.g_search_results.Count == 0)
            {
                Console.WriteLine("  Not found");
            }
            else
            {
                for (int pos = 0; pos < GlobalState.g_search_results.Count && pos < 20; pos++)
                {
                    Console.WriteLine($"  {pos + 1}. Position {GlobalState.g_search_results[pos]}");
                }

                if (GlobalState.g_search_results.Count > 20)
                {
                    Console.WriteLine($"  ... and {GlobalState.g_search_results.Count - 20} more");
                }
            }
            UIHelperGovnokod.PrintSeparator();
        }
    }
}
