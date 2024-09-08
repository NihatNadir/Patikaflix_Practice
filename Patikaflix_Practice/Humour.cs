using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patikaflix_Practice
{
    internal class Humour
    {

        public string SeriesName { get; set; }
        public List<string> Genre { get; set; }
        public string Director { get; set; }

        public Humour(string name , List <string> tur , string yonetmen) 
        {
            SeriesName = name;
            Genre = tur;
            Director = yonetmen;
        }

    }
}
