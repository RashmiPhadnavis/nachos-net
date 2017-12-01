using System;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace nachos.machine
{
    public class ArrayFile : OpenFileWithPosition
    {
        private sbyte[] array;


        public ArrayFile (sbyte[] array)
        {
            this.array = array;
        }

        public override int length()
        {
            return array.Length;
        }

        public override void close()
        {
            array = null;
        }

        public override int read(int position, sbyte[] buf, int offset, int length)
        {
            Trace.Assert (offset >= 0 && length >= 0 && offset + length <= buf.Length);

			if (position < 0 || position >= array.Length)
				return 0;

			length = Math.Min(length, array.Length-position);
			Array.Copy(array, position, buf, offset, length);

			return length;
		}

		public int write(int position, byte[] buf, int offset, int length) 
		{
			return 0;
		}
	}
}


