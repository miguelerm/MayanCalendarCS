namespace Mayan.Calendar
{
    public struct Tzolkin
    {
        private bool hasValue;
        private int count;
        private Kin kin;

        public int Count
        {
            get
            {
                return hasValue ? count : 4;
            }
        }

        public Kin Kin
        {
            get
            {
                return kin;
            }
        }
    }
}