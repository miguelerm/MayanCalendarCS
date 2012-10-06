namespace Mayan.Calendar
{
    /// <summary>
    /// Fecha representada en el calendario sagrado Maya.
    /// </summary>
    public class Tzolkin
    {
        /// <summary>
        /// Obtiene el día del Tzolkin.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Obtiene el nombre del día del Tzolkin.
        /// </summary>
        public Kin Kin { get; private set; }

        /// <summary>
        /// Crea una instancia del Tzolkin para la fecha 4 Ajaw.
        /// </summary>
        public Tzolkin()
        {
            Count = 4;
            Kin = Kin.Ajaw;
        }

        /// <summary>
        /// Crea una instancia del Tzolkin para la fecha indicada.
        /// </summary>
        /// <param name="count">Día del Tzolkin.</param>
        /// <param name="kin">Nombre del día del Tzolkin.</param>
        public Tzolkin(int count, Kin kin)
        {
            Count = count;
            Kin = kin;
        }
    }
}