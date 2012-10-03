using NUnit.Framework;
using System;

namespace Mayan.Calendar.UnitTests.DateTests
{
    [TestFixture]
    public class ConstructorTests
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
        public void Constructor_UltimoDiaDel12Baktun_GeneraFecha13DeDiciembreDe2012()
        {
            Date date = new Date(12, 19, 19, 17, 19);

            Assert.That(date.Day, Is.EqualTo(20));
            Assert.That(date.Month, Is.EqualTo(12));
            Assert.That(date.Year, Is.EqualTo(2012));
            Assert.That(date.Era, Is.EqualTo(Era.AfterCrist));
        }

        [Test]
        public void Constructor_UltimoDiaDel12Baktun_GeneraTzolkinCorrecto()
        {
            Date date = new Date(12, 19, 19, 17, 19);

            Assert.That(date.Tzolkin, Is.Not.Null);
            Assert.That(date.Tzolkin.Count, Is.EqualTo(3));
            Assert.That(date.Tzolkin.Kin, Is.EqualTo(Kin.Kawak));
        }

        [Test]
        public void Constructor_UltimoDiaDel12Baktun_GeneraHaabCorrecto()
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

        [Test]
        public void Constructor_ConFechaGregorianaDel31140813AC_GeneraFechaDelPrimerBaktun()
        {
            Date date = new Date(3114, 8, 13, Era.BeforeCrist);

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
        public void Constructor_ConUnAnyoFueraDeRango_GeneraUnArgumentOutOfRangeException()
        {
            TestDelegate anyoDebajoDelRango = () => new Date(0, 8, 13, Era.BeforeCrist);

            Assert.That(anyoDebajoDelRango, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("year"));
        }

        [Test]
        public void Constructor_ConUnMesFueraDeRango_GeneraUnArgumentOutOfRangeException()
        {
            TestDelegate mesArribaElRango = () => new Date(3114, 14, 13, Era.BeforeCrist);
            TestDelegate mesDebajoDelRango = () => new Date(3114, 0, 13, Era.BeforeCrist);

            Assert.That(mesArribaElRango, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("month"));
            Assert.That(mesDebajoDelRango, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("month"));
        }

        [Test]
        public void Constructor_ConUnDiaFueraDeRango_GeneraUnArgumentOutOfRangeException()
        {
            TestDelegate diaArribaDelRango = () => new Date(3114, 8, 32, Era.BeforeCrist);
            TestDelegate diaDebajoDelRango = () => new Date(3114, 8, 0, Era.BeforeCrist);

            Assert.That(diaArribaDelRango, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("day"));
            Assert.That(diaDebajoDelRango, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("day"));
        }

        [Test]
        public void Constructor_ConValoresDeCuentaLargaFueraDelRango_GeneraUnArgumentOutOfRangeException()
        {
            TestDelegate baktunMax = () => new Date(20, 0, 0, 0, 0);
            TestDelegate baktunMin = () => new Date(-1, 0, 0, 0, 0);

            TestDelegate katunMax = () => new Date(0, 20, 0, 0, 0);
            TestDelegate katunMin = () => new Date(0, -1, 0, 0, 0);

            TestDelegate tunMax = () => new Date(0, 0, 20, 0, 0);
            TestDelegate tunMin = () => new Date(0, 0, -1, 0, 0);

            TestDelegate uinalMax = () => new Date(0, 0, 0, 20, 0);
            TestDelegate uinalMin = () => new Date(0, 0, 0, -1, 0);

            TestDelegate kinMax = () => new Date(0, 0, 0, 0, 20);
            TestDelegate kinMin = () => new Date(0, 0, 0, 0, -1);

            Assert.That(baktunMax, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("baktun"));
            Assert.That(baktunMin, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("baktun"));

            Assert.That(katunMax, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("katun"));
            Assert.That(katunMin, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("katun"));

            Assert.That(tunMax, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("tun"));
            Assert.That(tunMin, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("tun"));

            Assert.That(uinalMax, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("uinal"));
            Assert.That(uinalMin, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("uinal"));

            Assert.That(kinMax, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("kin"));
            Assert.That(kinMin, Throws.TypeOf<ArgumentOutOfRangeException>().And.Property("ParamName").EqualTo("kin"));
        }
    }
}