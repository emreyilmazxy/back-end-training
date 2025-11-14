using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patikaflix
{
    internal class TVSeries
    {

        public string Title { get; set; }                  // Dizinin Adı
        public int ProductionYear { get; set; }            // Yapım Yılı
        public string Genre { get; set; }                  // Türü
        public int ReleaseYear { get; set; }               // Yayınlanmaya Başlama Yılı
        public string Director { get; set; }               // Yönetmen
        public string FirstBroadcastPlatform { get; set; }
    }
}
