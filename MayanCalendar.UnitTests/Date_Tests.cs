using NUnit.Framework;

namespace Mayan.Calendar.UnitTests
{
    [TestFixture]
    public class Date_Tests
    {
        [Test]
        public void Constructor_SinParametros_CreaUnaFechaDelPrimerDiaDelPrimerBaktun()
        {
            Mayan.Calendar.Date date = new Mayan.Calendar.Date();

            Assert.AreEqual(0, date.Baktun);
            Assert.AreEqual(0, date.Katun);
            Assert.AreEqual(0, date.Tun);
            Assert.AreEqual(0, date.Uinal);
            Assert.AreEqual(0, date.Kin);
            Assert.AreEqual(4, date.Tzolkin.Count);
            Assert.AreEqual(Kin.Ajaw, date.Tzolkin.Kin);
            Assert.AreEqual(8, date.Haab.Count);
            Assert.AreEqual(Uinal.Cumku, date.Haab.Uinal);
        }

        [Test]
        public void Constructor_SinParametros_CreaUnaFechaDel3114AntesDeCristo()
        {
            Mayan.Calendar.Date date = new Mayan.Calendar.Date();

            Assert.That(date.Day, Is.EqualTo(13));
            Assert.That(date.Month, Is.EqualTo(8));
            Assert.That(date.Year, Is.EqualTo(3114));
            Assert.That(date.Era, Is.EqualTo(Era.BeforeCrist));
        }
    }
}