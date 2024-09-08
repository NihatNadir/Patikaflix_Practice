using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patikaflix_Practice
{
    internal class Diziler 
    {
        public string SeriesName { get; set; }
        public int ProductionYear { get; set; }
        public List <string> Genre { get; set; }
        public int ReleaseYear { get; set; }

        public string Director { get; set; }
        public string Platform { get; set; }

        public Diziler(string diziAdi, int yapimYili, List<string> turu, int yayinaBaslamaYili, string yonetmen, string ilkPlatform) 
        { 
            SeriesName = diziAdi;
            ProductionYear = yapimYili;
            Genre = turu;
            ReleaseYear = yayinaBaslamaYili;
            Director = yonetmen;
            Platform = ilkPlatform;

        }

        

       
    }
}
