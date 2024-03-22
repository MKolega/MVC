using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vjezba.Model
{
    public enum Zvanje
    {
        Asistent,
        Predavac,
        VisiPredavac,
        ProfVisokeSkole
    }
    public class Profesor : Osoba
    {
        private string odjel;
        private DateTime datumIzbora;
        private Zvanje zvanje;

        public string Odjel { get => odjel; set => odjel = value; }


        public DateTime DatumIzbora { get => datumIzbora; set => datumIzbora = value; }

        public Zvanje Zvanje { get => zvanje; set => zvanje = value; }



        public List<Predmet> Predmeti { get; set; } = new List<Predmet>();

        public int KolikoDoReizbora()
        {
            DateTime trenutniDatum = DateTime.Now;
            int daniDoReizbora = 0;

            if (Zvanje == Zvanje.Asistent)
            {
                daniDoReizbora = (4 * 365) - (int)((trenutniDatum - DatumIzbora).TotalDays) % (4 * 365);
            }
            else
            {
                daniDoReizbora = (5 * 365) - (int)((trenutniDatum - DatumIzbora).TotalDays) % (5 * 365);
            }

            return daniDoReizbora / 365;
        }
    }
}
