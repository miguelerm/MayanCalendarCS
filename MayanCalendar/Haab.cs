namespace Mayan.Calendar
{
    /// <summary>
    /// Fecha representada en el calendario civil Maya (el Haab).
    /// </summary>
    public class Haab
    {
        /// <summary>
        /// Obtiene el día del Haab.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Obtiene el nombre del uinal (el equivalente al mes) del Haab.
        /// </summary>
        public Uinal Uinal { get; private set; }

        /// <summary>
        /// Crea una instancia del Haab en la fecha del 8 Cumku.
        /// </summary>
        public Haab()
        {
            this.Count = 8;
            this.Uinal = Uinal.Cumku;
        }

        /// <summary>
        /// Crea una instancia del Haab en la fecha indicada.
        /// </summary>
        /// <param name="count">Día del Haab.</param>
        /// <param name="uinal">Nombre del Uninal.</param>
        public Haab(int count, Uinal uinal)
        {
            this.Count = count;
            this.Uinal = uinal;
        }
    }
}