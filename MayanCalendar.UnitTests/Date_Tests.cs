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

            Assert.That(date.Baktun, Is.EqualTo(0));
            Assert.That(date.Katun, Is.EqualTo(0));
            Assert.That(date.Tun, Is.EqualTo(0));
            Assert.That(date.Uinal, Is.EqualTo(0));
            Assert.That(date.Kin, Is.EqualTo(0));
            Assert.That(date.Tzolkin.Count, Is.EqualTo(4));
            Assert.That(date.Tzolkin.Kin, Is.EqualTo(Kin.Ajaw));
            Assert.That(date.Haab.Count, Is.EqualTo(8));
            Assert.That(date.Haab.Uinal, Is.EqualTo(Uinal.Cumku));
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

        [Test]
        public void Constructor_AlFinalDel13Baktun_GeneraFechaDel13DeDiciembre2012()
        {
            Date date = new Date(12, 19, 19, 17, 19);

            Assert.That(date.Day, Is.EqualTo(13));
            Assert.That(date.Month, Is.EqualTo(12));
            Assert.That(date.Year, Is.EqualTo(2012));
            Assert.That(date.Era, Is.EqualTo(Era.AfterCrist));
        }

        [Test]
        public void Constructor_AlFinalDel13Baktun_GeneraTzolkinCorrecto()
        {
            Date date = new Date(12, 19, 19, 17, 19);

            Assert.That(date.Tzolkin, Is.Not.Null);
            Assert.That(date.Tzolkin.Count, Is.EqualTo(3));
            Assert.That(date.Tzolkin.Kin, Is.EqualTo(Kin.Kawak));
        }

        [Test]
        public void Constructor_AlFinalDel13Baktun_GeneraHaabCorrecto()
        {
            Date date = new Date(12, 19, 19, 17, 19);

            Assert.That(date.Haab, Is.Not.Null);
            Assert.That(date.Haab.Count, Is.EqualTo(2));
            Assert.That(date.Haab.Uinal, Is.EqualTo(Uinal.Kankin));
        }

        [Test]
        public void Constructor_AlInicioDelPrimerBaktun_GeneraFechaDel13DeAgostoDe3114AC()
        {
            Date date = new Date(0, 0, 0, 0, 0);

            Assert.That(date.Day, Is.EqualTo(13));
            Assert.That(date.Month, Is.EqualTo(8));
            Assert.That(date.Year, Is.EqualTo(3114));
            Assert.That(date.Era, Is.EqualTo(Era.BeforeCrist));
        }
    }
}