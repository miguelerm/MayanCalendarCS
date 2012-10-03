using NUnit.Framework;

namespace Mayan.Calendar.UnitTests.DateTests
{
    [TestFixture]
    public class ComputingTests
    {
        [TestCase(9, 8, 9, 13, 0, 603, 3, 24)]   /* 9.8.9.13.0   = 24 de mar del año  603 (Nacimiento de K'inich Janaab' Pakal I)*/
        [TestCase(9, 12, 11, 5, 18, 683, 8, 29)] /* 9.12.11.5.18 = 09 de ago del año  683 (Mierte de K'inich Janaab' Pakal I)*/
        [TestCase(13, 0, 0, 0, 0, 2012, 12, 21)] /* 13.0.0.0.0   = 21 de dic del año 2012 (el famoso 13 Baktun)*/
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