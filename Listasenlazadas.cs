using System;

namespace ListasEnlazadas
{
    // Clase Nodo para representar cada elemento de la lista
    public class Nodo
    {
        public int Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Clase Lista Enlazada
    public class ListaEnlazada
    {
        private Nodo cabeza;

        public ListaEnlazada()
        {
            cabeza = null;
        }

        // Método para agregar un elemento al final de la lista
        public void Agregar(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        // EJERCICIO 3: Método de búsqueda que retorna el número de veces que aparece un dato
        public int Buscar(int valorBuscado)
        {
            int contador = 0;
            Nodo actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato == valorBuscado)
                {
                    contador++;
                }
                actual = actual.Siguiente;
            }

            if (contador == 0)
            {
                Console.WriteLine($"El dato {valorBuscado} no fue encontrado en la lista.");
            }

            return contador;
        }

        // EJERCICIO 4: Método para eliminar nodos fuera de un rango
        public void EliminarFueraDeRango(int valorMinimo, int valorMaximo)
        {
            // Validar que el rango sea correcto
            if (valorMinimo > valorMaximo)
            {
                Console.WriteLine("Error: El valor mínimo no puede ser mayor que el valor máximo.");
                return;
            }

            // Eliminar nodos al inicio de la lista que estén fuera del rango
            while (cabeza != null && (cabeza.Dato < valorMinimo || cabeza.Dato > valorMaximo))
            {
                Console.WriteLine($"Eliminando nodo con valor {cabeza.Dato} (fuera del rango)");
                cabeza = cabeza.Siguiente;
            }

            // Eliminar nodos en el resto de la lista
            if (cabeza != null)
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    if (actual.Siguiente.Dato < valorMinimo || actual.Siguiente.Dato > valorMaximo)
                    {
                        Console.WriteLine($"Eliminando nodo con valor {actual.Siguiente.Dato} (fuera del rango)");
                        actual.Siguiente = actual.Siguiente.Siguiente;
                    }
                    else
                    {
                        actual = actual.Siguiente;
                    }
                }
            }

            Console.WriteLine($"\nEliminación completada. Nodos fuera del rango [{valorMinimo}, {valorMaximo}] han sido removidos.");
        }

        // Método para mostrar todos los elementos de la lista
        public void Mostrar()
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo actual = cabeza;
            Console.Write("Lista: ");
            while (actual != null)
            {
                Console.Write(actual.Dato + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }

        // Método para contar el número de elementos en la lista
        public int ContarElementos()
        {
            int contador = 0;
            Nodo actual = cabeza;
            while (actual != null)
            {
                contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        // Método para verificar si la lista está vacía
        public bool EstaVacia()
        {
            return cabeza == null;
        }
    }

    // Clase principal con el programa
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("  EJERCICIOS DE LISTAS ENLAZADAS EN C#");
            Console.WriteLine("========================================\n");

            // EJERCICIO 3: Demostración del método de búsqueda
            Console.WriteLine("--- EJERCICIO 3: MÉTODO DE BÚSQUEDA ---\n");
            
            ListaEnlazada lista1 = new ListaEnlazada();
            
            // Agregar algunos elementos de prueba (con repeticiones)
            int[] valoresPrueba = { 5, 10, 15, 10, 20, 5, 30, 10, 5 };
            Console.WriteLine("Creando lista con valores: 5, 10, 15, 10, 20, 5, 30, 10, 5");
            foreach (int valor in valoresPrueba)
            {
                lista1.Agregar(valor);
            }
            
            lista1.Mostrar();
            Console.WriteLine();

            // Buscar diferentes valores
            int valorBuscar1 = 10;
            int veces1 = lista1.Buscar(valorBuscar1);
            if (veces1 > 0)
            {
                Console.WriteLine($"El valor {valorBuscar1} se encontró {veces1} vez/veces en la lista.\n");
            }

            int valorBuscar2 = 5;
            int veces2 = lista1.Buscar(valorBuscar2);
            if (veces2 > 0)
            {
                Console.WriteLine($"El valor {valorBuscar2} se encontró {veces2} vez/veces en la lista.\n");
            }

            int valorBuscar3 = 100;
            int veces3 = lista1.Buscar(valorBuscar3);
            Console.WriteLine();

            // EJERCICIO 4: Lista con 50 números aleatorios y eliminación por rango
            Console.WriteLine("\n--- EJERCICIO 4: LISTA CON 50 NÚMEROS ALEATORIOS ---\n");
            
            ListaEnlazada lista2 = new ListaEnlazada();
            Random random = new Random();
            
            // Generar 50 números aleatorios entre 1 y 999
            Console.WriteLine("Generando 50 números aleatorios entre 1 y 999...\n");
            for (int i = 0; i < 50; i++)
            {
                int numeroAleatorio = random.Next(1, 1000); // 1 a 999
                lista2.Agregar(numeroAleatorio);
            }
            
            Console.WriteLine("Lista original:");
            lista2.Mostrar();
            Console.WriteLine($"Cantidad de elementos: {lista2.ContarElementos()}\n");

            // Solicitar el rango de valores al usuario
            Console.Write("Ingrese el valor mínimo del rango: ");
            int minimo = int.Parse(Console.ReadLine());
            
            Console.Write("Ingrese el valor máximo del rango: ");
            int maximo = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"\nEliminando nodos fuera del rango [{minimo}, {maximo}]...\n");
            
            // Eliminar nodos fuera del rango
            lista2.EliminarFueraDeRango(minimo, maximo);
            
            // Mostrar la lista después de la eliminación
            Console.WriteLine("\nLista después de eliminar nodos fuera del rango:");
            lista2.Mostrar();
            Console.WriteLine($"Cantidad de elementos restantes: {lista2.ContarElementos()}");

            Console.WriteLine("\n========================================");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}