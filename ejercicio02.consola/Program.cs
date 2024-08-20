namespace ejercicio02.consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int numPrismas = 5;
            double[] volumenes = new double[numPrismas];
            double mayorVolumen = 0;
            double iteracionMayorVolumen = 0;
            double sumaVolumenes = 0;
            for (int i = 0; i < numPrismas; i++)
            {
                Console.WriteLine($"ingreso de datos para el prisma {i+1}: ");
                double longitud = 0, ancho = 0, altura = 0;
                while (true)
                {
                    try
                    {
                        Console.Write("ingrese la longitud del prisma: ");
                        longitud = Convert.ToDouble(Console.ReadLine());
                        Console.Write("ingrese el ancho del prisma: ");
                        ancho = Convert.ToDouble(Console.ReadLine());
                        Console.Write("ingrese la altura del prisma: ");
                        altura = Convert.ToDouble(Console.ReadLine());
                        if (longitud <= 0 || ancho <= 0 || altura <= 0)
                        {
                            Console.WriteLine("las dimenciones deben ser valores positivos. Por favor intente de nuevo");
                            continue;
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("entrada no valida. Por favor intente de nuevo");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"ocurrio un error inesperado: {ex.Message}");
                    }
                }
                double volumen = longitud * altura * altura;
                volumenes[i] = volumen;
                sumaVolumenes += volumen;

                if (volumen>mayorVolumen)
                {
                    mayorVolumen = volumen;
                    iteracionMayorVolumen = i + 1;
                }
            }
            double promedioVolumenes = sumaVolumenes / numPrismas;

            Console.WriteLine("numeros finales:");
            Console.WriteLine($"el prisma con mayor volumen es {iteracionMayorVolumen} con un volumen de {mayorVolumen:F2}");
            Console.WriteLine($"el promedio de los volumenes de los prismas es {promedioVolumenes:F2}");
        }
    }
}
