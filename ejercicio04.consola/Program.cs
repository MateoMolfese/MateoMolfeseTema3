using ConsoleTables;
using ejercicio04.entidades;

namespace ejercicio04.consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int tamañoMaximo = 5;
            Prisma[] prismas = new Prisma[tamañoMaximo];
            int conteoPrismas = 0;

            while (true)
            {
                Console.WriteLine("menu");
                Console.WriteLine("1 - ingresar prismas");
                Console.WriteLine("2. Mostrar todos los prismas");
                Console.WriteLine("3. Modificar un prisma");
                Console.WriteLine("4. Mostrar estadísticas");
                Console.WriteLine("5. Mostrar prismas con volumen inferior al promedio");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                string opción = Console.ReadLine();

                switch (opción)
                {
                    case "1":
                        IngresarPrismas(prismas, ref conteoPrismas, tamañoMaximo);
                        break;
                    case "2":
                        MostrarPrismas(prismas, conteoPrismas);
                        break;
                    case "3":
                        ModificarPrisma(prismas, conteoPrismas);
                        break;
                    case "4":
                        MostrarEstadísticas(prismas, conteoPrismas);
                        break;
                    case "5":
                        MostrarPrismasInferioresAlPromedio(prismas, conteoPrismas);
                        break;
                    case "6":
                        return; 
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
        static void IngresarPrismas(Prisma[] prismas, ref int conteoPrismas, int tamañoMaximo)
        {
            if (conteoPrismas >= tamañoMaximo)
            {
                Console.WriteLine("El array de prismas está lleno.");
                return;
            }

            while (conteoPrismas < tamañoMaximo)
            {
                try
                {
                    Console.WriteLine($"\nIngreso de datos para el prisma #{conteoPrismas + 1}:");
                    Console.Write("Ingrese la longitud: ");
                    double longitud = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Ingrese el ancho: ");
                    double ancho = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Ingrese la altura: ");
                    double altura = Convert.ToDouble(Console.ReadLine());

                    Prisma prisma = new Prisma();
                    prisma.AsignarDimensiones(longitud, ancho, altura);
                    prismas[conteoPrismas] = prisma;
                    conteoPrismas++;

                    Console.WriteLine("Prisma ingresado exitosamente.");
                    break; // Salir del bucle al ingresar correctamente el prisma
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada no válida. Por favor ingrese un número válido.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void MostrarPrismas(Prisma[] prismas, int conteoPrismas)
        {
            if (conteoPrismas == 0)
            {
                Console.WriteLine("No hay prismas para mostrar.");
                return;
            }

            var table = new ConsoleTable("Número", "Longitud", "Ancho", "Altura", "Volumen", "Área", "Diagonal");

            for (int i = 0; i < conteoPrismas; i++)
            {
                Prisma p = prismas[i];
                table.AddRow(
                    i + 1,
                    p.ObtenerLongitud(),
                    p.ObtenerAncho(),
                    p.ObtenerAltura(),
                    p.CalcularVolumen(),
                    p.CalcularArea(),
                    p.CalcularDiagonal()
                );
            }

            table.Write();
        }

        static void ModificarPrisma(Prisma[] prismas, int conteoPrismas)
        {
            if (conteoPrismas == 0)
            {
                Console.WriteLine("No hay prismas para modificar.");
                return;
            }

            Console.Write("Ingrese el número del prisma a modificar (1 a {0}): ", conteoPrismas);
            int númeroPrisma = Convert.ToInt32(Console.ReadLine()) - 1;

            if (númeroPrisma < 0 || númeroPrisma >= conteoPrismas)
            {
                Console.WriteLine("Número de prisma no válido.");
                return;
            }

            try
            {
                Console.WriteLine($"\nModificación del prisma #{númeroPrisma + 1}:");
                Console.Write("Ingrese la nueva longitud: ");
                double longitud = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ingrese el nuevo ancho: ");
                double ancho = Convert.ToDouble(Console.ReadLine());
                Console.Write("Ingrese la nueva altura: ");
                double altura = Convert.ToDouble(Console.ReadLine());

                prismas[númeroPrisma].AsignarDimensiones(longitud, ancho, altura);
                Console.WriteLine("Prisma modificado exitosamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada no válida. Por favor ingrese un número válido.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void MostrarEstadísticas(Prisma[] prismas, int conteoPrismas)
        {
            if (conteoPrismas == 0)
            {
                Console.WriteLine("No hay prismas para mostrar estadísticas.");
                return;
            }

            double volumenTotal = 0;
            double mayorVolumen = 0;
            double menorVolumen = double.MaxValue;

            for (int i = 0; i < conteoPrismas; i++)
            {
                double volumen = prismas[i].CalcularVolumen();
                volumenTotal += volumen;

                if (volumen > mayorVolumen)
                {
                    mayorVolumen = volumen;
                }

                if (volumen < menorVolumen)
                {
                    menorVolumen = volumen;
                }
            }

            double promedioVolúmenes = volumenTotal / conteoPrismas;

            Console.WriteLine("\nEstadísticas de los prismas:");
            Console.WriteLine($"Prisma con mayor volumen: {mayorVolumen:F2}");
            Console.WriteLine($"Prisma con menor volumen: {menorVolumen:F2}");
            Console.WriteLine($"Promedio de volúmenes: {promedioVolúmenes:F2}");
        }

        static void MostrarPrismasInferioresAlPromedio(Prisma[] prismas, int conteoPrismas)
        {
            if (conteoPrismas == 0)
            {
                Console.WriteLine("No hay prismas para mostrar.");
                return;
            }

            double volumenTotal = 0;

            for (int i = 0; i < conteoPrismas; i++)
            {
                volumenTotal += prismas[i].CalcularVolumen();
            }

            double promedioVolúmenes = volumenTotal / conteoPrismas;

            Console.WriteLine($"\nPrismas con volumen inferior al promedio ({promedioVolúmenes:F2}):");

            for (int i = 0; i < conteoPrismas; i++)
            {
                double volumen = prismas[i].CalcularVolumen();
                if (volumen < promedioVolúmenes)
                {
                    Console.WriteLine($"Prisma #{i + 1}: Volumen {volumen:F2}");
                }
            }
        }   
    }
}
