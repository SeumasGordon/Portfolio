using CopierExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopierTest
{
    public class RYOSource : ISource
    {
        string sourceString;
        int counter = 0;

        public string SourceString { get => sourceString; set => sourceString = value; }

        public char GetChar()
        {
            return sourceString[counter++];
        }
    }
}
