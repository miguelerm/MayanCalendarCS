namespace Mayan.Calendar
{
    public class Tzolkin
    {
        public int Count { get; private set; }

        public Kin Kin { get; private set; }

        public Tzolkin()
        {
            Count = 4;
            Kin = Kin.Ajaw;
        }
    }
}