namespace Mayan.Calendar
{
    using Mayan.Calendar.Properties;
    using System;
    using KinName = Calendar.Kin;
    using UinalName = Calendar.Uinal;

    public class Date
    {
        public int Day { get; private set; }

        public int Month { get; private set; }

        public int Year { get; private set; }

        public Era Era { get; private set; }

        public int Baktun { get; private set; }

        public int Katun { get; private set; }

        public int Tun { get; private set; }

        public int Uinal { get; private set; }

        public int Kin { get; private set; }

        public Tzolkin Tzolkin { get; private set; }

        public Haab Haab { get; private set; }

        public Date()
        {
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

            this.Day = 13;
            this.Month = 12;
            this.Year = 2012;
            this.Era = Era.AfterCrist;
        }

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
    }
}