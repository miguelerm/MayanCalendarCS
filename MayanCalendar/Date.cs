namespace Mayan.Calendar
{
    using Mayan.Calendar.Properties;
    using System;
    using KinName = Calendar.Kin;
    using UinalName = Calendar.Uinal;

    /// <summary>
    /// Fecha representada en Cuenta Larga Maya y que puede ser convertida a su equivalente en el
    /// calendario Gregoriano.
    /// </summary>
    public class Date
    {
        /// <summary>
        /// Constante de correlacion que se utilizará para la conversión de fechas.
        /// </summary>
        private readonly int Correlation;

        /// <summary>
        /// Obtiene el día de la fecha en el calendario Gregoriano.
        /// </summary>
        public int Day { get; private set; }

        /// <summary>
        /// Obtiene el mes de la fecha en el calendario Gregoriano.
        /// </summary>
        public int Month { get; private set; }

        /// <summary>
        /// Obtiene el año de la fecha en el calendario Gragoriano.
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// Obtiene la era de la fecha en el calendario Gregoriano (a.C. o d.C.).
        /// </summary>
        public Era Era { get; private set; }

        /// <summary>
        /// Obtiene la cantidad de baktunes de la fecha en el calendario Maya.
        /// </summary>
        public int Baktun { get; private set; }

        /// <summary>
        /// Obtiene la cantidad de katunes de la fecha en el calendario Maya.
        /// </summary>
        public int Katun { get; private set; }

        /// <summary>
        /// Obtiene la cantidad de tunes de la fecha en el calendario Maya.
        /// </summary>
        public int Tun { get; private set; }

        /// <summary>
        /// Obtiene la cantidad de uinales de la fecha en el calendario Maya.
        /// </summary>
        public int Uinal { get; private set; }

        /// <summary>
        /// Obtiene la cantidad de kines de la fecha en el calendario Maya.
        /// </summary>
        public int Kin { get; private set; }

        /// <summary>
        /// Obtiene el Tzolkin para la fecha en el calendario Maya.
        /// </summary>
        public Tzolkin Tzolkin { get; private set; }

        /// <summary>
        /// Obtiene el Haab para la fecha en el calendario Maya.
        /// </summary>
        public Haab Haab { get; private set; }

        /// <summary>
        /// Crea una instancia de una fecha Maya en el 0.0.0.0.0 4 Ajaw 8 Cumku
        /// </summary>
        public Date()
        {
            this.Correlation = 584283; // Constante de correlacion GMT (Goodman, Martinez, Thompson)
            this.Day = 13;
            this.Month = 8;
            this.Year = 3114;
            this.Era = Era.BeforeCrist;
            this.Baktun = 0;
            this.Katun = 0;
            this.Tun = 0;
            this.Uinal = 0;
            this.Kin = 0;
            this.Tzolkin = new Tzolkin();
            this.Haab = new Haab();
        }

        /// <summary>
        /// Crea una instancia de una fecha Maya en la cuenta larga indicada.
        /// </summary>
        /// <param name="baktun">Baktun en la fecha Maya.</param>
        /// <param name="katun">Katun en la fecha Maya.</param>
        /// <param name="tun">Tun en la fecha Maya.</param>
        /// <param name="uinal">Uinal en la fecha Maya.</param>
        /// <param name="kin">Kin en la fecha Maya.</param>
        public Date(int baktun, int katun, int tun, int uinal, int kin)
            : this()
        {
            if (baktun > 19 || baktun < 0)
            {
                throw new ArgumentOutOfRangeException("baktun", string.Format(Resources.ArgumentOutOfRangeException_Message, "baktun", 0, 19));
            }
            if (katun > 19 || katun < 0)
            {
                throw new ArgumentOutOfRangeException("katun", string.Format(Resources.ArgumentOutOfRangeException_Message, "katun", 0, 19));
            }
            if (tun > 19 || tun < 0)
            {
                throw new ArgumentOutOfRangeException("tun", string.Format(Resources.ArgumentOutOfRangeException_Message, "tun", 0, 19));
            }
            if (uinal > 19 || uinal < 0)
            {
                throw new ArgumentOutOfRangeException("uinal", string.Format(Resources.ArgumentOutOfRangeException_Message, "uinal", 0, 19));
            }
            if (kin > 19 || kin < 0)
            {
                throw new ArgumentOutOfRangeException("kin", string.Format(Resources.ArgumentOutOfRangeException_Message, "kin", 0, 19));
            }

            // Si se especifican todos los parametros a cero, se dejan
            // los valores asignados por el constructor por defecto.
            if (baktun + katun + tun + uinal + kin == 0)
            {
                return;
            }

            this.Baktun = baktun;
            this.Katun = katun;
            this.Tun = tun;
            this.Uinal = uinal;
            this.Kin = kin;

            this.Tzolkin = new Tzolkin(3, KinName.Kawak);
            this.Haab = new Haab(2, UinalName.Kankin);

            this.ComputeGregorianDate();
        }

        /// <summary>
        /// Crea una instancia de la una fecha Maya para la fecha Gregoriana indicada.
        /// </summary>
        /// <param name="year">Año en el calendario Gregoriano.</param>
        /// <param name="month">Mes en el calendario Gregoriano.</param>
        /// <param name="day">Día en el calendario Gregoriano.</param>
        /// <param name="era">Era en el calendario Gregoriano.</param>
        public Date(int year, int month, int day, Calendar.Era era)
            : this()
        {
            if (year < 1)
            {
                throw new ArgumentOutOfRangeException("year", string.Format(Resources.ArgumentOutOfRangeException_Message, "year", 1, int.MaxValue));
            }

            if (month > 12 || month < 1)
            {
                throw new ArgumentOutOfRangeException("month", string.Format(Resources.ArgumentOutOfRangeException_Message, "month", 1, 12));
            }

            if (day > 31 || day < 1)
            {
                throw new ArgumentOutOfRangeException("day", string.Format(Resources.ArgumentOutOfRangeException_Message, "day", 1, 31));
            }
        }

        /// <summary>
        /// Calcula la fecha del calendario Gregoriano a la qu es equivalente la fecha Maya instanciada.
        /// </summary>
        private void ComputeGregorianDate()
        {
            // Se calcula el total de dias Julianos que existen en la fecha Maya especificada.

            // Kin    =            =       1 día
            // Uinal  = 20 Kines   =      20 días
            // Tun    = 18 Uinales =     360 días
            // Katún  = 20 Tunes   =   7,200 días
            // Baktún = 20 katunes = 144,000 días

            int totalJulianDays = (this.Kin * 1) + (this.Uinal * 20) + (this.Tun * 360) + (this.Katun * 7200) + (this.Baktun * 144000);

            // Se suma la constante de correlación

            totalJulianDays += Correlation;

            // Se convierten los dias Julianos a una fecha Gregoriana

            // Se utiliza la formula publicada en wikipedia http://en.wikipedia.org/wiki/Julian_day
            // > La verdad no la he estudiado para ver que hace o para optimizarla
            // > pero por el momento confiemos en que funciona.

            var J = totalJulianDays + 0.5;
            var j = J + 32044;
            var g = IntPart(j / 146097);
            var dg = j % 146097;
            var c = IntPart(dg / 36524 + 1) * 3 / 4;
            var dc = dg - c * 36524;
            var b = IntPart(dc / 1461);
            var db = dc % 1461;
            var a = IntPart((IntPart(db / 365) + 1) * 3 / 4);
            var da = db - a * 365;
            var y = g * 400 + c * 100 + b * 4 + a;
            var m = IntPart((da * 5 + 308) / 153) - 2;
            var d = da - IntPart((m + 4) * 153 / 5) + 122;
            var Y = y - 4800 + IntPart((m + 2) / 12);
            var M = (m + 2) % 12 + 1;
            var D = d + 1;

            // TODO: La formula tendría que encapsularse en alguna otra clase.

            this.Era = Y < 0 ? Era.BeforeCrist : Calendar.Era.AfterCrist;
            this.Year = (int)Math.Abs(Y);
            this.Month = (int)M;
            this.Day = (int)D;
        }

        /// <summary>
        /// Obtiene el valor entero de un número (recortando los decimales).
        /// </summary>
        /// <param name="number">Número del que se desea obtener el valor entero.</param>
        /// <returns>Retorna la representancion entera (sin aproximación) del numero indicado.</returns>
        private int IntPart(double number)
        {
            return (int)Math.Floor(number);
        }
    }
}