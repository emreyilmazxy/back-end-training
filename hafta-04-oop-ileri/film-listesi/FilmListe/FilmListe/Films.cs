
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb
{
    public class Movie
    {
        public string Name { get; set; }
        public double Imdb { get; set; }

        public Movie(string name, double imdb)
        {
            Name = name;
            Imdb = imdb;
        }
    }

}
