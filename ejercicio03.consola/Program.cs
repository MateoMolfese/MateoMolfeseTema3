namespace ejercicio03.consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prisma prisma= new Prisma();

            double longitud, ancho, altura;

            while (true)
            {
                try
                {
                    Console.Write("ingrese la longitud del prisma");
                    longitud=Convert.ToDouble(Console.ReadLine());
                    Console.Write("ingrese la ancho del prisma");
                    ancho = Convert.ToDouble(Console.ReadLine());
                    Console.Write("ingrese la altura del prisma");
                    altura = Convert.ToDouble(Console.ReadLine());

                    prisma.AsignarDimensiones(longitud, ancho, altura);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("entrada no valida. Por favor ingrese un numero valido");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("resultados del prisma rectangular:");
            Console.WriteLine($"Longitud: {prisma.ObtenerLongitud()}");
            Console.WriteLine($"Ancho: {prisma.ObtenerAncho()}");
            Console.WriteLine($"Altura: {prisma.ObtenerAltura()}");
            Console.WriteLine($"Volumen del prisma: {prisma.CalcularVolumen():F2}");
            Console.WriteLine($"Área superficial del prisma: {prisma.CalcularArea():F2}");
            Console.WriteLine($"Diagonal del prisma: {prisma.CalcularDiagonal():F2}");
        }
    }
}
