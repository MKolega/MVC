﻿﻿using System;
using Xunit;
using Vjezba.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Vjezba.Test
{
    
    public class Zadatak_07
    {
        [Fact]
        public void TestProsjek91Ordered()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Profesor() { JMBG = "0111991330000", OIB = "11163222039", DatumIzbora = new DateTime(2011, 6, 1) });
            listOsoba.Add(new Profesor() { JMBG = "0202990330000", OIB = "22163222039", DatumIzbora = new DateTime(2012, 12, 30) });
            listOsoba.Add(new Profesor() { JMBG = "0303991330000", OIB = "33163222039", DatumIzbora = new DateTime(2011, 7, 19) });

            listOsoba.Add(new Student() { JMBAG = "0246378992", Prezime = "Ticaric", JMBG = "0101991330060", Prosjek = 4.4M });
            listOsoba.Add(new Student() { JMBAG = "0024638992", Prezime = "Tokic", JMBG = "0101992330040", Prosjek = 4.22M });
            listOsoba.Add(new Student() { JMBAG = "0036378992", Prezime = "Iskra", JMBG = "3112991330220", Prosjek = 4.3M });
            listOsoba.Add(new Student() { JMBAG = "0246111112", Prezime = "Medo", JMBG = "3112991330010", Prosjek = 4.5M });
            listOsoba.Add(new Student() { JMBAG = "0246112232", Prezime = "Trtic", JMBG = "0506991330032", Prosjek = 4.41M });
            listOsoba.Add(new Student() { JMBAG = "0246038992", Prezime = "Antonic", JMBG = "1111992330099", Prosjek = 4.21M });

            var rez = f.StudentiGodinaOrdered(1991);
            Assert.True(rez is IEnumerable<Student>, "Povratni tip je trebao biti IEnumerable<Student>");
            Assert.Equal(4, rez.Count());
            Assert.Equal("3112991330010", rez.ElementAt(0).JMBG);
            Assert.Equal("3112991330220", rez.ElementAt(3).JMBG);
        }

        [Fact]
        public void TestProsjek91OrderedNoResults()
        {
            Fakultet f = new Fakultet();

            var listProp = typeof(Fakultet).GetProperties()
                .Where(p => p.PropertyType == typeof(List<Osoba>))
                .FirstOrDefault();

            var listOsoba = listProp.GetValue(f) as List<Osoba>;

            listOsoba.Add(new Profesor() { JMBG = "0111991330000", OIB = "11163222039", DatumIzbora = new DateTime(2011, 6, 1) });
            listOsoba.Add(new Profesor() { JMBG = "0202990330000", OIB = "22163222039", DatumIzbora = new DateTime(2012, 12, 30) });
            listOsoba.Add(new Profesor() { JMBG = "0303991330000", OIB = "33163222039", DatumIzbora = new DateTime(2011, 7, 19) });

            listOsoba.Add(new Student() { JMBAG = "0246378992", Prezime = "Ticaric", JMBG = "0101994330060", Prosjek = 4.4M });
            listOsoba.Add(new Student() { JMBAG = "0024638992", Prezime = "Tokic", JMBG = "0101992330040", Prosjek = 4.22M });
            listOsoba.Add(new Student() { JMBAG = "0036378992", Prezime = "Iskra", JMBG = "3112994330220", Prosjek = 4.3M });
            listOsoba.Add(new Student() { JMBAG = "0246111112", Prezime = "Medo", JMBG = "3112994330010", Prosjek = 4.5M });
            listOsoba.Add(new Student() { JMBAG = "0246112232", Prezime = "Trtic", JMBG = "0506994330032", Prosjek = 4.41M });
            listOsoba.Add(new Student() { JMBAG = "0246038992", Prezime = "Antonic", JMBG = "1111992330099", Prosjek = 4.21M });

            var rez = f.StudentiGodinaOrdered(1991);
            Assert.True(rez is IEnumerable<Student>, "Povratni tip je trebao biti IEnumerable<Student>");
            Assert.Empty(rez);
        }
    }
}
