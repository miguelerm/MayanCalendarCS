﻿using NUnit.Framework;

namespace Mayan.Calendar.UnitTests.DateTests
{
    [TestFixture]
    public class ComputingTests
    {
        [TestCase(9, 8, 9, 13, 0, 603, 3, 24)]   /* 09.08.09.13.00 = 24 de mar del año  603 dC (Nacimiento de K'inich Janaab' Pakal I)*/
        [TestCase(9, 12, 11, 5, 18, 683, 8, 29)] /* 09.12.11.05.18 = 09 de ago del año  683 dC (Mierte de K'inich Janaab' Pakal I)*/
        [TestCase(13, 0, 0, 0, 0, 2012, 12, 21)] /* 13.00.00.00.00 = 21 de dic del año 2012 dC (el famoso 13 Baktun)*/
        [TestCase(10, 9, 0, 0, 0, 1007, 8, 13)]  /* 10.09.00.00.00 = 13 de ago del año 1007 dC (día que Ah Suytok Tutul Xiu fundó la aldea de Uxmal) */
        [TestCase(12, 4, 0, 0, 0, 1697, 7, 25)]  /* 12.04.00.00.00 = 25 de jul del año 1697 dC (Martín de Ursúa destruye Tayasal) */
        [TestCase(11, 17, 0, 0, 0, 1559, 7, 30)] /* 11.17.00.00.00 = 30 de jul del año 1559 dC (Francisco de Montejo ha conquistado la península de Yucatán) */
        [TestCase(10, 10, 0, 0, 0, 1027, 4, 30)] /* 10.10.00.00.00 = 30 de abr del año 1027 dC (Comienza la Liga de Mayapán) */
        public void Compute_ConFechaMayaValida_GeneraLaFechaGregorianaEsperada(int baktun, int katun, int tun, int uinal, int kin, int expectedYear, int expectedMonth, int expectedDay)
        {
            Date date = new Date(baktun, katun, tun, uinal, kin);

            Assert.That(date.Year, Is.EqualTo(expectedYear));
            Assert.That(date.Month, Is.EqualTo(expectedMonth));
            Assert.That(date.Day, Is.EqualTo(expectedDay));
            Assert.That(date.Era, Is.EqualTo(Era.AfterCrist));
        }

        [TestCase(9, 8, 9, 13, 0, 13, Uinal.Pop)]
        [TestCase(9, 12, 11, 5, 18, 11, Uinal.Yax)]
        [TestCase(13, 0, 0, 0, 0, 3, Uinal.Kankin)]
        [TestCase(10, 9, 0, 0, 0, 13, Uinal.Mac)]
        [TestCase(12, 4, 0, 0, 0, 18, Uinal.Uo)]
        [TestCase(11, 17, 0, 0, 0, 8, Uinal.Pop)]
        [TestCase(10, 10, 0, 0, 0, 13, Uinal.Mol)]
        public void Compute_ConFechaMayaValida_GeneraElHaabEsperado(int baktun, int katun, int tun, int uinal, int kin, int expectedHaabCount, int expectedHaabUinal)
        {
            Date date = new Date(baktun, katun, tun, uinal, kin);

            Assert.That(date.Haab.Count, Is.EqualTo(expectedHaabCount));
            Assert.That(date.Haab.Uinal, Is.EqualTo((Uinal)expectedHaabUinal));
        }

        [TestCase(9, 8, 9, 13, 0, 8, Kin.Ajaw)]
        [TestCase(9, 12, 11, 5, 18, 6, Kin.Etznab)]
        [TestCase(13, 0, 0, 0, 0, 4, Kin.Ajaw)]
        [TestCase(10, 9, 0, 0, 0, 2, Kin.Ajaw)]
        [TestCase(12, 4, 0, 0, 0, 10, Kin.Ajaw)]
        [TestCase(11, 17, 0, 0, 0, 11, Kin.Ajaw)]
        [TestCase(10, 10, 0, 0, 0, 13, Kin.Ajaw)]
        public void Compute_ConFechaMayaValida_GeneraElTzolkinEsperado(int baktun, int katun, int tun, int uinal, int kin, int expectedTzolkinCount, int expectedTzolkinKin)
        {
            Date date = new Date(baktun, katun, tun, uinal, kin);

            Assert.That(date.Tzolkin.Count, Is.EqualTo(expectedTzolkinCount));
            Assert.That(date.Tzolkin.Kin, Is.EqualTo(expectedTzolkinKin));
        }
    }
}