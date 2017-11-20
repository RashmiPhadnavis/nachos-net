using System;
using System.Diagnostics;

namespace nachos
{
    public sealed class Machine
    {
        const string c_CopyRight = @"
Copyright 1992-2001 The Regents of the University of California.
All rights reserved.

Permission to use, copy, modify, and distribute this software and
its documentation for any purpose, without fee, and without
written agreement is hereby granted, provided that the above
copyright notice and the following two paragraphs appear in all
copies of this software.

IN NO EVENT SHALL THE UNIVERSITY OF CALIFORNIA BE LIABLE TO ANY
PARTY FOR DIRECT, INDIRECT, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL
DAMAGES ARISING OUT OF THE USE OF THIS SOFTWARE AND ITS
DOCUMENTATION, EVEN IF THE UNIVERSITY OF CALIFORNIA HAS BEEN
ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

THE UNIVERSITY OF CALIFORNIA SPECIFICALLY DISCLAIMS ANY
WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.  THE
SOFTWARE PROVIDED HEREUNDER IS ON AN \""AS IS\"" BASIS, AND THE
UNIVERSITY OF CALIFORNIA HAS NO OBLIGATION TO PROVIDE
MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR MODIFICATIONS.
";

        const string c_Help = @"

Options:

    -d <debug flags>
        Enable some debug flags, e.g. -d ti

    -h
        Print this help message.

    -m <pages>
        Specify how many physical pages of memory to simulate.

    -s <seed>
        Specify the seed for the random number generator (seed is a
        long).

    -x <program>
        Specify a program that UserKernel.run() should execute,
        instead of the value of the configuration variable
        Kernel.shellProgram

    -z
        print the copyright message

    -- <grader class>
        Specify an autograder class to use, instead of
        nachos.ag.AutoGrader

    -# <grader arguments>
        Specify the argument string to pass to the autograder.

    -[] <config file>
        Specifiy a config file to use, instead of nachos.conf
";

        private static string[] s_Args;
        private static int s_NumPhysPages = -1;
        private static int s_RandomSeed;
        private static string s_ShellProgramName;
        private static string s_ConfigFileName = "nachos.conf";
        private static string s_AutoGraderClassName = "nachos.ag.AutoGrader";

        private Machine ()
        {
        }

        private static void ProcessArgs()
        {
            for (int i = 0; i < s_Args.Length;)
            {
                string arg = s_Args[i++];
                if (arg.Length > 0 && arg[0] == '-')
                {
                    if (arg == "-d")
                    {
                        Trace.Assert(i < s_Args.Length, "switch without argument");
                        Lib.EnableDebugFlags(s_Args[i++]);
                    }
                    else if (arg == "-h")
                    {
                        Trace.WriteLine(c_Help);
                        Environment.Exit(1);
                    }
                    else if (arg == "-m")
                    {
                        Trace.Assert(i < s_Args.Length, "switch without argument");
                        int numPhysPages;
                        if (!int.TryParse(s_Args[i++], out numPhysPages))
                        {
                            Trace.Assert(false, "bad value for -m switch");
                        }
                        s_NumPhysPages = numPhysPages;
                    }
                    else if (arg == "-s")
                    {
                        Trace.Assert(i < s_Args.Length, "switch without argument");
                        int randomSeed;
                        if (!int.TryParse(s_Args[i++], out randomSeed))
                        {
                            Trace.Assert(false, "bad value for -s switch");
                        }
                        s_RandomSeed = randomSeed;
                    }
                    else if (arg == "-x")
                    {
                        Trace.Assert(i < s_Args.Length, "switch without argument");
                        s_ShellProgramName = s_Args[i++];
                    }
                    else if (arg == "-z")
                    {
                        Trace.WriteLine(c_CopyRight);
                        Environment.Exit(1);
                    }
                    else if (arg == "-[]")
                    {
                        Trace.Assert(i < s_Args.Length, "switch without argument");
                        s_ConfigFileName = s_Args[i++];
                    }
                    else if (arg == "--")
                    {
                        Trace.Assert(i < s_Args.Length, "switch without argument");
                        s_AutoGraderClassName = s_Args[i++];
                    }
                }
            }

            Lib.SeedRandom(s_RandomSeed);
        }

        public static void Main(string[] args)
        {
            Trace.WriteLine("nachos initializing");
            Trace.Assert(s_Args == null);
            s_Args = args;
            ProcessArgs();
        }
    }
}