using NUnit.Framework;

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
    }
}