using System;
using System.Collections.Generic;

namespace EjerciciosPilas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("    EJERCICIOS DE PILAS (STACKS) EN C#");
            Console.WriteLine("==============================================\n");

            // Ejercicio 1: Verificación de paréntesis balanceados
            Console.WriteLine("--- EJERCICIO 1: Verificación de Paréntesis Balanceados ---\n");
            EjercicioParentesisBalanceados();

            Console.WriteLine("\n==============================================\n");

            // Ejercicio 2: Torres de Hanoi
            Console.WriteLine("--- EJERCICIO 2: Torres de Hanoi ---\n");
            EjercicioTorresHanoi();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // ============================================================
        // EJERCICIO 1: VERIFICACIÓN DE PARÉNTESIS BALANCEADOS
        // ============================================================
        static void EjercicioParentesisBalanceados()
        {
            // Ejemplos de prueba
            string[] expresiones = {
                "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}",
                "{[(5 + 3) * 2]}",
                "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]",  // Falta }
                "((3 + 5) * [2 - 1})",  // No coinciden los símbolos
                "{[()]}"
            };

            foreach (string expresion in expresiones)
            {
                bool balanceada = VerificarParentesisBalanceados(expresion);
                Console.WriteLine($"Expresión: {expresion}");
                Console.WriteLine($"Resultado: {(balanceada ? "✓ Fórmula balanceada" : "✗ Fórmula NO balanceada")}\n");
            }
        }

        /// <summary>
        /// Verifica si una expresión matemática tiene sus paréntesis, llaves y corchetes balanceados
        /// </summary>
        /// <param name="expresion">La expresión a verificar</param>
        /// <returns>true si está balanceada, false en caso contrario</returns>
        static bool VerificarParentesisBalanceados(string expresion)
        {
            // Creamos una pila para almacenar los símbolos de apertura
            Stack<char> pila = new Stack<char>();

            // Recorremos cada carácter de la expresión
            foreach (char caracter in expresion)
            {
                // Si es un símbolo de apertura, lo añadimos a la pila
                if (caracter == '(' || caracter == '{' || caracter == '[')
                {
                    pila.Push(caracter);
                    Console.WriteLine($"  [DEBUG] Push '{caracter}' - Tamaño de pila: {pila.Count}");
                }
                // Si es un símbolo de cierre, verificamos que coincida con el tope de la pila
                else if (caracter == ')' || caracter == '}' || caracter == ']')
                {
                    // Si la pila está vacía, no hay símbolo de apertura correspondiente
                    if (pila.Count == 0)
                    {
                        Console.WriteLine($"  [DEBUG] Error: '{caracter}' sin apertura correspondiente");
                        return false;
                    }

                    // Sacamos el tope de la pila
                    char tope = pila.Pop();
                    Console.WriteLine($"  [DEBUG] Pop '{tope}' comparando con '{caracter}' - Tamaño de pila: {pila.Count}");

                    // Verificamos que el símbolo de cierre coincida con el de apertura
                    if (!Coinciden(tope, caracter))
                    {
                        Console.WriteLine($"  [DEBUG] Error: '{tope}' no coincide con '{caracter}'");
                        return false;
                    }
                }
            }

            // Al final, la pila debe estar vacía (todos los símbolos fueron cerrados)
            bool resultado = pila.Count == 0;
            Console.WriteLine($"  [DEBUG] Pila final - Tamaño: {pila.Count} - Resultado: {resultado}");
            return resultado;
        }

        /// <summary>
        /// Verifica si un símbolo de apertura coincide con su correspondiente cierre
        /// </summary>
        static bool Coinciden(char apertura, char cierre)
        {
            return (apertura == '(' && cierre == ')') ||
                   (apertura == '{' && cierre == '}') ||
                   (apertura == '[' && cierre == ']');
        }

        // ============================================================
        // EJERCICIO 2: TORRES DE HANOI
        // ============================================================
        static void EjercicioTorresHanoi()
        {
            Console.WriteLine("Ingrese el número de discos (recomendado: 3-5): ");
            int numeroDiscos;
            
            // Validación de entrada
            while (!int.TryParse(Console.ReadLine(), out numeroDiscos) || numeroDiscos < 1)
            {
                Console.WriteLine("Por favor, ingrese un número válido mayor que 0: ");
            }

            Console.WriteLine($"\nResolviendo Torres de Hanoi con {numeroDiscos} disco(s)...\n");

            // Creamos las tres torres como pilas
            Stack<int> torreOrigen = new Stack<int>();
            Stack<int> torreAuxiliar = new Stack<int>();
            Stack<int> torreDestino = new Stack<int>();

            // Inicializamos la torre origen con los discos (del más grande al más pequeño)
            for (int i = numeroDiscos; i >= 1; i--)
            {
                torreOrigen.Push(i);
            }

            Console.WriteLine("Estado inicial:");
            MostrarTorres(torreOrigen, torreAuxiliar, torreDestino);
            Console.WriteLine();

            // Variable para contar los movimientos
            int contadorMovimientos = 0;

            // Resolvemos el problema
            ResolverTorresHanoi(numeroDiscos, torreOrigen, torreDestino, torreAuxiliar, 
                               "Origen", "Destino", "Auxiliar", ref contadorMovimientos);

            Console.WriteLine($"\n¡Problema resuelto en {contadorMovimientos} movimientos!");
            Console.WriteLine($"Número mínimo teórico de movimientos: {Math.Pow(2, numeroDiscos) - 1}");
        }

        /// <summary>
        /// Resuelve el problema de las Torres de Hanoi de forma recursiva
        /// </summary>
        /// <param name="n">Número de discos a mover</param>
        /// <param name="origen">Torre de origen</param>
        /// <param name="destino">Torre de destino</param>
        /// <param name="auxiliar">Torre auxiliar</param>
        /// <param name="nombreOrigen">Nombre de la torre origen</param>
        /// <param name="nombreDestino">Nombre de la torre destino</param>
        /// <param name="nombreAuxiliar">Nombre de la torre auxiliar</param>
        /// <param name="contador">Contador de movimientos</param>
        static void ResolverTorresHanoi(int n, Stack<int> origen, Stack<int> destino, 
                                       Stack<int> auxiliar, string nombreOrigen, 
                                       string nombreDestino, string nombreAuxiliar,
                                       ref int contador)
        {
            // Caso base: si solo hay 1 disco, moverlo directamente
            if (n == 1)
            {
                MoverDisco(origen, destino, nombreOrigen, nombreDestino, ref contador);
                return;
            }

            // Paso 1: Mover n-1 discos de origen a auxiliar (usando destino como auxiliar)
            ResolverTorresHanoi(n - 1, origen, auxiliar, destino, 
                               nombreOrigen, nombreAuxiliar, nombreDestino, ref contador);

            // Paso 2: Mover el disco más grande de origen a destino
            MoverDisco(origen, destino, nombreOrigen, nombreDestino, ref contador);

            // Paso 3: Mover n-1 discos de auxiliar a destino (usando origen como auxiliar)
            ResolverTorresHanoi(n - 1, auxiliar, destino, origen, 
                               nombreAuxiliar, nombreDestino, nombreOrigen, ref contador);
        }

        /// <summary>
        /// Mueve un disco de una torre a otra y muestra el estado
        /// </summary>
        static void MoverDisco(Stack<int> origen, Stack<int> destino, 
                              string nombreOrigen, string nombreDestino, ref int contador)
        {
            contador++;
            int disco = origen.Pop();
            destino.Push(disco);
            
            Console.WriteLine($"Movimiento {contador}: Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            
            // Obtener referencias a las tres torres para mostrarlas
            // (esto es simplificado; en producción se usaría una estructura mejor)
        }

        /// <summary>
        /// Muestra el estado actual de las tres torres
        /// </summary>
        static void MostrarTorres(Stack<int> torreA, Stack<int> torreB, Stack<int> torreC)
        {
            Console.WriteLine("Torre Origen:   " + MostrarPila(torreA));
            Console.WriteLine("Torre Auxiliar: " + MostrarPila(torreB));
            Console.WriteLine("Torre Destino:  " + MostrarPila(torreC));
        }

        /// <summary>
        /// Convierte una pila a string para visualización
        /// </summary>
        static string MostrarPila(Stack<int> pila)
        {
            if (pila.Count == 0)
                return "[vacía]";

            int[] elementos = pila.ToArray();
            Array.Reverse(elementos); // Mostrar de abajo hacia arriba
            return "[" + string.Join(", ", elementos) + "]";
        }
    }
}