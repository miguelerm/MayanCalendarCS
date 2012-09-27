namespace Mayan.Calendar
{
    public class Haab
    {
        public int Count { get; private set; }

        public Uinal Uinal { get; private set; }

        public Haab()
        {
            this.Count = 8;
            this.Uinal = Uinal.Cumku;
        }

        public Haab(int count, Uinal uinal)
        {
            this.Count = count;
            this.Uinal = uinal;
        }
    }
}