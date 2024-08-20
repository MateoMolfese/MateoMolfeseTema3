namespace ejercicio04.entidades
{
    public struct Prisma
    {
        private double longitud;
        private double ancho;
        private double altura;

        public void AsignarDimensiones(double longitud, double ancho, double altura)
        {
            if (ValidarDimensiones(longitud, ancho, altura))
            {
                this.longitud = longitud;
                this.ancho = ancho;
                this.altura = altura;
            }
            else
            {
                throw new ArgumentException("Las dimensiones deben ser valores positivos.");
            }
        }
        private bool ValidarDimensiones(double longitud, double ancho, double altura)
        {
            return longitud > 0 && ancho > 0 && altura > 0;
        }
        public double ObtenerLongitud() => longitud;
        public double ObtenerAncho() => ancho;
        public double ObtenerAltura() => altura;
        public double CalcularVolumen() => longitud * ancho * altura;
        public double CalcularArea() => 2 * (longitud * ancho + longitud * altura + ancho * altura);
        public double CalcularDiagonal() => Math.Sqrt(Math.Pow(longitud, 2) + Math.Pow(ancho, 2) + Math.Pow(altura, 2));
    }
}
