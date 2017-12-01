using System;
using Microsoft.VisualBasic;

namespace nachos.machine
{
    public abstract class OpenFileWithPosition : OpenFile
    {
        protected int position = 0;

        public OpenFileWithPosition (FileSystem fileSystem, String name):base(fileSystem, name)
        {
            
        }

        public OpenFileWithPosition():base()
        {
            
        }

        public override void seek(int position)
        {
            this.position = position;
        }

        public override int tell() 
        {
            return position;
        }

        public override int read(sbyte[] buf, int offset, int length) 
        {
            int amount = read(position, buf, offset, length);
            if (amount == -1)
                return -1;

            position += amount;
            return amount;
        }

        public override int write(sbyte[] buf, int offset, int length) 
        {
            int amount = write(position, buf, offset, length);
            if (amount == -1)
                return -1;

            position += amount;
            return amount;
        }

    
    }
}

