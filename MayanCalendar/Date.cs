namespace Mayan.Calendar
{
    using KinName = Calendar.Kin;

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
        {
            this.Baktun = baktun;
            this.Katun = katun;
            this.Tun = tun;
            this.Uinal = uinal;
            this.Kin = kin;

            this.Tzolkin = new Tzolkin(3, KinName.Kawak);

            this.Day = 13;
            this.Month = 12;
            this.Year = 2012;
            this.Era = Era.AfterCrist;

        }
    }
}