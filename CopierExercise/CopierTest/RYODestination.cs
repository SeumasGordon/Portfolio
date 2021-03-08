using CopierExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopierTest
{
    public class RYODestination : IDestination
    {
        string destinationString = "";

        public string DestinationString { get => destinationString; set => destinationString = value; }

        public void SetChar(char c)
        {
            destinationString += c;
        }
    }
}
