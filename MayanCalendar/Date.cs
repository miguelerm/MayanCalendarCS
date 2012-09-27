namespace Mayan.Calendar
{
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
            Day = 13;
            Month = 8;
            Year = 3114;
            Era = Era.BeforeCrist;
            Baktun = 0;
            Katun = 0;
            Tun = 0;
            Uinal = 0;
            Kin = 0;
            Tzolkin = new Tzolkin();
            Haab = new Haab();
        }

        public Date(int baktun, int katun, int tun, int uinal, int kin)
        {
            Baktun = baktun;
            Katun = katun;
            Tun = tun;
            Uinal = uinal;
            Kin = kin;

            Day = 13;
            Month = 12;
            Year = 2012;
            Era = Era.AfterCrist;
        }
    }
}