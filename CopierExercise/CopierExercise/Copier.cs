using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CopierExercise
{
    public class Copier
    {
        IDestination destination;
        ISource source;

        public ISource Source { get => source; }// set => source = value; }
        public IDestination Destination { get => destination; }// set => destination = value; }

        public Copier(IDestination d, ISource s)
        {
            if (s == null || d == null)
            {
                throw new NullReferenceException();
            }
            destination = d;
            source = s;
        }

        public void Copy()
        {
            char c;
            while ((c = source.GetChar()) != '\n')
            {

                if (char.IsWhiteSpace(c))
                {
                    throw new IndexOutOfRangeException();
                }
                destination.SetChar(c);
            }
        }
    }
}
