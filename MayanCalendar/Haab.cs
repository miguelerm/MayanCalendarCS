namespace Mayan.Calendar
{
    public struct Haab
    {
        private int count;
        private Uinal uinal;
        private bool hasValue;

        public int Count
        {
            get
            {
                return hasValue ? count : 8;
            }
        }

        public Uinal Uinal
        {
            get
            {
                return hasValue ? uinal : Uinal.Cumku;
            }
        }
    }
}