Calendario Maya CS
==================

Es una librería escrita en C# para conversión de fechas representadas en notación Maya a su equivalente en notación Gregoriana.


Ejemplos de uso
---------------

El siguiente ejemplo muestra como convertir la fecha Gregoriana del *21 de diciembre de 2012 después de Cristo* a su equivalente fecha Maya:

    Date date = new Date(2012, 12, 21, Era.AfterCrist);

    // Se imprime el resultado "La fecha en notación Maya es: 13.0.0.0.0 3 Kankin 4 Ajaw"
    Console.WriteLine("La fecha en notación Maya es: {0}", date);


El siguiente ejemplo muestra como convertir la fecha Maya *9.8.9.13.0 13 Pop 8 Ajaw* a su equivalente fecha Gregoriana:

    Date date = new Date(9, 8, 9, 13, 0, 13);

    // Se imprime el resultado "La fecha en notación Gregoriana es: 24/3/603 d.C."
    Console.WriteLine("La fecha en notación Gregoriana es: {0}/{1}/{2} {3}", date.Day, date.Month, date.Year, date.Era == Era.AfterCrist ? "d.C." : "a.C.");

Notas Adicionales
-----------------

- Para que funcione el ejemplo agregar la referencia al assembly **Mayan.Calendar.dll**.
- Verificar que este incluido el `using Mayan.Calendar;`

