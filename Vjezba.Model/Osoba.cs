using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Osoba
    {
        private DateTime datumRodjenja1;
        private string oib;
        private string jmbg;
        private string prezime;
        private string ime;

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string OIB
        {
            get { return oib; }
            set
            {
                if (value.Length != 11 || !IsAllDigits(value))
                {
                    throw new InvalidOperationException("OIB mora imati 11 znamenki i sve moraju biti znamenke.");
                }
                oib = value;
            }
        }
        public string JMBG
        {
            get { return jmbg; }
            set
            {
                if (value.Length != 13 || !IsAllDigits(value))
                    throw new InvalidOperationException("JMBG mora imati 13 znamenki i sve moraju biti znamenke.");
                jmbg = value;
            }
        }

        public DateTime DatumRodjenja
        {
            get
            {
                string jmbgSubstring = JMBG.Substring(0, 7);
                DateTime.TryParseExact(jmbgSubstring, "ddMMyyy", null, System.Globalization.DateTimeStyles.None, out datumRodjenja1);
                datumRodjenja1 = datumRodjenja1.AddYears(1000);
                return datumRodjenja1;
            }
        }

        private bool IsAllDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
