using System;
using Microsoft.VisualBasic;

namespace nachos.machine
{
    public class OpenFile
    {
        private FileSystem fileSystem;
        private string name;

        public OpenFile (FileSystem fileSystem, String name)
        {
            this.fileSystem = fileSystem;
            this.name = name;
        }

		public OpenFile():this(null, "unnamed")
        {
            
        }

        public FileSystem getFileSysytem()
        {
            return fileSystem;
        }

        public string getName()
        {
            return name;
        }

        public virtual int read(int pos, sbyte[] buf, int offset, int length)
        {
            return -1;
        }

        public virtual int write(int pos, sbyte[] buf, int offset, int length)
        {
            return -1;
        }

        public virtual int length()
        {
            return -1;
        }

        public virtual void close()
        {
        }

        public virtual void seek(int pos)
        {
        }

        public virtual int tell()
        {
            return -1;
        }

        public virtual int read(sbyte[] buf, int offset, int length)
        {
			return -1;
        }

        public virtual int write(sbyte[] buf, int offset, int length)
        {
			return -1;
        }
	}
}
        
