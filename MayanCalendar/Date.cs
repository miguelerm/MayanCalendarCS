namespace Mayan.Calendar
{
    public struct Date
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
    }
}