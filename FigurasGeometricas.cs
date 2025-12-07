using System;

namespace FigurasGeometricas
{
    // Clase Circulo: Representa un círculo y permite calcular su área y perímetro
    public class Circulo
    {
        // Campo privado que almacena el radio del círculo
        private double radio;

        // Propiedad pública Radio con validación para asegurar que el radio sea positivo
        public double Radio
        {
            get { return radio; }
            set
            {
                if (value > 0)
                    radio = value;
                else
                    throw new ArgumentException("El radio debe ser mayor que cero");
            }
        }

        // Constructor que inicializa el círculo con un radio específico
        // Parámetro: radioInicial - el valor del radio del círculo
        public Circulo(double radioInicial)
        {
            Radio = radioInicial;
        }

        // CalcularArea es un método que devuelve un valor double
        // Se utiliza para calcular el área del círculo usando la fórmula: A = π * r²
        // Retorna: el área del círculo
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // CalcularPerimetro es un método que devuelve un valor double
        // Se utiliza para calcular el perímetro (circunferencia) del círculo usando la fórmula: P = 2 * π * r
        // Retorna: el perímetro del círculo
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }

        // MostrarInformacion es un método que muestra los datos del círculo en la consola
        public void MostrarInformacion()
        {
            Console.WriteLine($"=== CÍRCULO ===");
            Console.WriteLine($"Radio: {radio:F2}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
            Console.WriteLine();
        }
    }

    // Clase Rectangulo: Representa un rectángulo y permite calcular su área y perímetro
    public class Rectangulo
    {
        // Campos privados que almacenan la base y altura del rectángulo
        private double baseRectangulo;
        private double altura;

        // Propiedad pública Base con validación para asegurar que la base sea positiva
        public double Base
        {
            get { return baseRectangulo; }
            set
            {
                if (value > 0)
                    baseRectangulo = value;
                else
                    throw new ArgumentException("La base debe ser mayor que cero");
            }
        }

        // Propiedad pública Altura con validación para asegurar que la altura sea positiva
        public double Altura
        {
            get { return altura; }
            set
            {
                if (value > 0)
                    altura = value;
                else
                    throw new ArgumentException("La altura debe ser mayor que cero");
            }
        }

        // Constructor que inicializa el rectángulo con base y altura específicas
        // Parámetros:
        //   baseInicial - el valor de la base del rectángulo
        //   alturaInicial - el valor de la altura del rectángulo
        public Rectangulo(double baseInicial, double alturaInicial)
        {
            Base = baseInicial;
            Altura = alturaInicial;
        }

        // CalcularArea es un método que devuelve un valor double
        // Se utiliza para calcular el área del rectángulo usando la fórmula: A = base * altura
        // Retorna: el área del rectángulo
        public double CalcularArea()
        {
            return baseRectangulo * altura;
        }

        // CalcularPerimetro es un método que devuelve un valor double
        // Se utiliza para calcular el perímetro del rectángulo usando la fórmula: P = 2 * (base + altura)
        // Retorna: el perímetro del rectángulo
        public double CalcularPerimetro()
        {
            return 2 * (baseRectangulo + altura);
        }

        // MostrarInformacion es un método que muestra los datos del rectángulo en la consola
        public void MostrarInformacion()
        {
            Console.WriteLine($"=== RECTÁNGULO ===");
            Console.WriteLine($"Base: {baseRectangulo:F2}");
            Console.WriteLine($"Altura: {altura:F2}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
            Console.WriteLine();
        }
    }

    // Clase Program: Contiene el punto de entrada del programa para probar las clases
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** PROGRAMA DE FIGURAS GEOMÉTRICAS ***\n");

            try
            {
                // Crear una instancia de Circulo con radio de 5 unidades
                Circulo miCirculo = new Circulo(5.0);
                miCirculo.MostrarInformacion();

                // Crear una instancia de Rectangulo con base de 8 y altura de 4 unidades
                Rectangulo miRectangulo = new Rectangulo(8.0, 4.0);
                miRectangulo.MostrarInformacion();

                // Ejemplo de modificación de propiedades
                Console.WriteLine("--- Modificando las figuras ---\n");
                miCirculo.Radio = 7.5;
                miCirculo.MostrarInformacion();

                miRectangulo.Base = 10.0;
                miRectangulo.Altura = 6.0;
                miRectangulo.MostrarInformacion();
            }
            catch (ArgumentException ex)
            {
                // Capturar y mostrar errores de validación
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}