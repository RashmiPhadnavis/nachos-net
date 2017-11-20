using System;
using System.Diagnostics;

namespace nachos
{
    public static class Lib
    {
        private static bool[] s_DebugFlags;
        private static Random s_Random;

        public static void EnableDebugFlags(string flagsString)
        {
            if (s_DebugFlags == null)
            {
                s_DebugFlags = new bool[0x80];
            }

            char[] newFlags = flagsString.ToCharArray();
            for (int i = 0; i < newFlags.Length; i++)
            {
                char c = newFlags[i];
                if (c >= 0 && c < 0x80)
                {
                    s_DebugFlags[(int)c] = true;
                }
            }
        }

        public static void SeedRandom(int randomSeed)
        {
            Trace.Assert(s_Random == null);
            s_Random = new Random(randomSeed);
        }
    }
}

