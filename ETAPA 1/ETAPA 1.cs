// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        int opcion;
        do
        {
            MostrarMenu();
            opcion = ObtenerOpcion();

            switch (opcion)
            {
                case 1:
                    RealizarRetiros();
                    break;
                case 2:
                    RetirarCantidad();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("Bienvenido a Banco CDIS");
        Console.WriteLine("1 - Ingresar cantidad de retiros");
        Console.WriteLine("2 - Retirar cantidad en billetes y monedas");
        Console.WriteLine("0 - Salir");
    }

    static int ObtenerOpcion()
    {
        int opcion;
        Console.Write("Selecciona una opción: ");
        while (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Entrada no válida. Introduce un número.");
            Console.Write("Selecciona una opción: ");
        }
        return opcion;
    }

    static void RealizarRetiros()
    {
        Console.Write("Ingrese la cantidad de retiros (máximo 10): ");
        int cantidadRetiros = ObtenerCantidad(1, 10);

        for (int i = 1; i <= cantidadRetiros; i++)
        {
            Console.Write($"Ingrese la cantidad de dinero para el retiro #{i} (máximo $50,000): ");
            int cantidadDinero = ObtenerCantidad(1, 50000);

            CalcularBilletesMonedas(cantidadDinero);
        }
    }

    static void RetirarCantidad()
    {
        Console.Write("Ingrese la cantidad de dinero a retirar: ");
        int cantidadDinero = ObtenerCantidad(1, 50000);

        CalcularBilletesMonedas(cantidadDinero);

        Console.WriteLine("Presiona 'enter' para continuar...");
        Console.ReadLine();
    }

    static int ObtenerCantidad(int min, int max)
    {
        int cantidad;
        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < min || cantidad > max)
        {
            Console.WriteLine($"Cantidad no válida. Introduce un número entre {min} y {max}.");
            Console.Write("Vuelve a ingresar la cantidad: ");
        }
        return cantidad;
    }

    static void CalcularBilletesMonedas(int cantidad)
    {
        int[] denominaciones = { 500, 200, 100, 50, 20, 10, 5, 1 };

        Console.WriteLine($"Para la cantidad de ${cantidad} pesos, necesitas:");

        foreach (int denominacion in denominaciones)
        {
            int cantidadDenominacion = cantidad / denominacion;
            if (cantidadDenominacion > 0)
            {
                Console.WriteLine($"{cantidadDenominacion} billete(s) o moneda(s) de ${denominacion} pesos");
                cantidad %= denominacion;
            }
        }
    }
}
