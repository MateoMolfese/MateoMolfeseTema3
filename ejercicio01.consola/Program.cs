namespace ejercicio01.consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {          
            Console.Write("ingrese la longitud del prisma: ");
            double longitud=Convert.ToDouble(Console.ReadLine());
            Console.Write("ingrese el ancho del prisma: ");
            double ancho = Convert.ToDouble(Console.ReadLine());
            Console.Write("ingrese la altura del prisma: ");
            double altura = Convert.ToDouble(Console.ReadLine());

            double volumen=longitud*ancho*altura;
            double area=2*(longitud*ancho+longitud*altura+altura*ancho);
            double diagonal = Math.Sqrt(Math.Pow(longitud, 2) + Math.Pow(ancho, 2) + Math.Pow(altura, 2));

            Console.WriteLine("resultados del prisma rectangular");
            Console.WriteLine($"el volumen del prisma es: {volumen:F2}");
            Console.WriteLine($"el area del prisma es: {area:F2}");
            Console.WriteLine($"la diagonal del prisma es: {diagonal:F2}");
            }
            catch (Exception)
            {

                Console.WriteLine("algo se ingreso incorrectamente");
            }
        }
    }
}
