namespace Uniza.CSharp.Lab.Delegates
{
    public static class EnumerableLoop
    {
        /// <summary>
        /// Príklad na vlastnú rozširujúcu metódu - vlastný ForEach, podobne ako je naprogramovaný v <seealso cref="List{T}.ForEach"/>.
        /// Vďaka tejto metóde môžete prejsť prvky v ľubovoľnej kolekcii implementujúcej rozhranie IEnumerable&lt;T&gt;.
        /// </summary>
        /// <typeparam name="T">Prvky kolekcie, ktoré sa enumerujú.</typeparam>
        /// <param name="enumerable">Enumerovateľná kolekcia.</param>
        /// <param name="action">Akcia, ktorá sa vykoná nad každým prvkom. Prvý parameter je prvok kolekcie, druhý index.</param>
        /// <returns>Počet prvkov enumerovateľnej kolekcie.</returns>
        public static int ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            var a = action;
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            int index = 0;
            foreach (var item in enumerable)
                a(item, index++);

            return index;
        }

        /// <summary>
        /// Ďalší príklad na vlastnú rozširujúcu metódu - vlastný ForEach, podobne ako je naprogramovaný v <seealso cref="List{T}.ForEach"/>.
        /// Vďaka tejto metóde môžete prejsť prvky v ľubovoľnej kolekcii implementujúcej rozhranie IEnumerable&lt;T&gt;.
        /// </summary>
        /// <typeparam name="T">Prvky kolekcie, ktoré sa enumerujú.</typeparam>
        /// <param name="enumerable">Enumerovateľná kolekcia.</param>
        /// <param name="action">Akcia, ktorá sa vykoná nad každým prvkom. Parametrom je prvok kolekcie.</param>
        /// <returns>Počet prvkov enumerovateľnej kolekcie.</returns>
        public static int ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            // TODO: Úloha 1.14 - implementujte telo metódy
            throw new NotImplementedException();
        }
    }

}
