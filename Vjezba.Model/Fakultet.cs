using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba.Model
{
    public class Fakultet
    {

        private List<Osoba> osobe;

        public Fakultet()
        {
            OsobaList = new List<Osoba>();
        }

        

        public List<Osoba> OsobaList { get { return osobe; } set { osobe = value; }}
        public int KolikoProfesora()
        {
            int brojac = 0;
            foreach (Osoba osoba in osobe)
            {
                if (osoba is Profesor)
                {
                    brojac++;
                }
            }
          return brojac;
        }
        public int KolikoStudenata()
        {
            int brojac = 0;
            foreach (Osoba osoba in osobe)
            {
                if (osoba is Student)
                {
                    brojac++;
                }
            }
            return brojac;
        }
        public Osoba DohvatiStudenta(string JMBAG)
        {
           foreach (Osoba osoba in osobe)
            {
                if (osoba is Student)
                {
                    Student student = (Student)osoba;
                    if (student.JMBAG == JMBAG)
                    {
                        return student;
                    }
                }
            }
            return null;
            
        }
        public IEnumerable<Profesor> DohvatiProfesore()
        {
            IEnumerable<Profesor> profesori = osobe.OfType<Profesor>();
            IEnumerable<Profesor> sortedProfesori = profesori.OrderBy(profesor => profesor.DatumIzbora);
            return sortedProfesori;
        }
        public IEnumerable<Student> DohvatiStudente91()
        {
            IEnumerable<Student> studenti = osobe.OfType<Student>();
            IEnumerable<Student> studenti91 = studenti.Where(student => student.DatumRodjenja.Year > 1991);
            return studenti91;
        }

        public IEnumerable<Student> DohvatiStudente91NoLinq()
        {
            List<Student> studenti91 = new List<Student>();
            foreach (Osoba osoba in OsobaList)
            {
                if (osoba is Student && osoba.DatumRodjenja.Year > 1991)
                {
                    Student student = (Student)osoba;
                    studenti91.Add(student);
                }
            }
            return studenti91;
        }

        public List<Student> StudentiNeTvzD()
        {
            List<Student> studenti = new List<Student>();

            foreach (Osoba osoba in OsobaList)
            {
                if (osoba is Student && osoba.Prezime.StartsWith("D") && !((Student)osoba).JMBAG.StartsWith("0246"))
                {
                    studenti.Add((Student)osoba);
                }
            }

            return studenti;
        }
        public List<Student> DohvatiStudente91List()
        {
            List<Student> studenti91List = new List<Student>();
            foreach (Osoba osoba in OsobaList)
            {
                if (osoba is Student && osoba.DatumRodjenja.Year > 1991)
                {
                    studenti91List.Add((Student)osoba);
                }
            }
            return studenti91List;
        }
        public Student NajboljiProsjek(int god)
        {
            IEnumerable<Student> studenti = osobe.OfType<Student>().Where(student => student.DatumRodjenja.Year == god);
            Student NajboljiStudent = null;
            decimal maxProsjek = 0;

            foreach (Student student in studenti)
            {
                decimal prosjek = student.Prosjek;
                if (prosjek > maxProsjek)
                {
                    maxProsjek = prosjek;
                    NajboljiStudent = student;
                }
            }

            return NajboljiStudent;
        }

        public IEnumerable<Student> StudentiGodinaOrdered(int god)
        {
            IEnumerable<Student> studenti = osobe.OfType<Student>()
                .Where(student => student.DatumRodjenja.Year == god)
                .OrderByDescending(student => student.Prosjek);
            
            return studenti;
        }

        public IEnumerable<Profesor> SviProfesori(bool asc)
        {
            IEnumerable<Profesor> profesori = osobe.OfType<Profesor>();
            IEnumerable<Profesor> profesoriOrdered = asc ? profesori.OrderBy(profesor => profesor.Prezime).ThenBy(profesor => profesor.Ime) : profesori.OrderByDescending(profesor => profesor.Prezime).ThenBy(profesor => profesor.Ime);
            return profesoriOrdered;
        }
        public int KolikoProfesoraUZvanju(Zvanje zvanje)
        {
            IEnumerable<Profesor> profesori = osobe.OfType<Profesor>();
            int ZbrojProfesora = 0;
            foreach (Profesor profesor in profesori)
            {
                if (profesor.Zvanje == zvanje )
                {
                   ZbrojProfesora = profesori.Count();
                }
            }
            return ZbrojProfesora;
        }
        public IEnumerable<Profesor> NeaktivniProfesori(int x)
        {
            IEnumerable<Profesor> profesori = osobe.OfType<Profesor>()
                .Where(profesor => profesor.Zvanje == Zvanje.Predavac || profesor.Zvanje == Zvanje.VisiPredavac)
                .Where(profesor => profesor.Predmeti.Count() < x);

            return profesori;
        }
        public IEnumerable<Profesor> AktivniAsistenti(int x, int minEcts)
        {
            IEnumerable<Profesor> profesori = osobe.OfType<Profesor>()
                .Where(profesor => profesor.Zvanje == Zvanje.Asistent)
                .Where(profesor => profesor.Predmeti.Count(predmet => predmet.ECTS >= minEcts) > x);
                

            return profesori;
        }

        public void IzmjeniProfesore(Action<Profesor> action)
        {
            IEnumerable<Profesor> profesori = osobe.OfType<Profesor>();
            foreach (Profesor profesor in profesori)
            {
                action(profesor);
            }
        }
    }
}
