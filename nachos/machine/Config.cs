using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace nachos.machine
{
    public sealed class Config
    {
        private static bool s_Loaded;
        private static string s_ConfigFile;
        private static Dictionary<string, string> s_Config;

        private Config ()
        {
        }

        public static void Load(string filename)
        {
            Trace.WriteLine(" config");
            Trace.Assert(!s_Loaded);
            s_Loaded = true;

            s_ConfigFile = filename;

            try
            {
                s_Config = new Dictionary<string, string>();
                using (StreamReader configFileReader = File.OpenText(s_ConfigFile))
                {
                    while (!configFileReader.EndOfStream)
                    {
                        string line = configFileReader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            string[] tokens = line.Split('=');
                            if (tokens.Length == 2)
                            {
                                string key = tokens[0].Trim();
                                string value = tokens[1].Trim();
                                if (!string.IsNullOrEmpty(key) &&
                                    !string.IsNullOrEmpty(value))
                                {
                                    s_Config.Add(tokens[0], tokens[1]);
                                }
                                else
                                {
                                    LoadError(line);
                                }
                            }
                            else
                            {
                                LoadError(line);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Trace.TraceError("Error loading " + s_ConfigFile);
                Environment.Exit(1);
            }
        }

        private static void LoadError(string line)
        {
            Trace.TraceError("Error in {0}, line {1}",
                s_ConfigFile, line);
            Environment.Exit(1);
        }
    }
}

