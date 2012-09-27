namespace Mayan.Calendar
{
    public class Haab
    {
        public int Count { get; private set; }

        public Uinal Uinal { get; private set; }

        public Haab()
        {
            Count = 8;
            Uinal = Uinal.Cumku;
        }
    }
}