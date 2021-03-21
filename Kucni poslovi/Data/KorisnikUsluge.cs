using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kucni_poslovi.Data
{
    
    public class KorisnikUsluge : RegistrovaniKorisnik
    {
        public List<Oglas> MojiOglasi { get; set; }

        public override void OceniOglas(int ocena)
        {
            int count = 0;
            foreach (var oglas in MojiOglasi)
            {
                if (oglas.Stanje == Stanje.Izvršen || oglas.Stanje == Stanje.Neaktivan)
                {
                    if (oglas.OcenjenKorisnik != null)
                        count++;
                }
            }
            ProsecnaOcena = ((count-1) * ProsecnaOcena + ocena) / count;
        }


        public KorisnikUsluge()
        {
            MojiOglasi = new List<Oglas>();
        }
    }
}
