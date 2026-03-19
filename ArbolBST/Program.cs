using System;

namespace ArbolBST
{
    class Program
    {
        static ArbolBinario arbol = new ArbolBinario();

        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("  ARBOL BINARIO DE BUSQUEDA");
                Console.WriteLine("================================");
                Console.WriteLine("  1. Insertar valor");
                Console.WriteLine("  2. Buscar valor");
                Console.WriteLine("  3. Eliminar valor");
                Console.WriteLine("  4. Recorridos");
                Console.WriteLine("  5. Minimo, Maximo y Altura");
                Console.WriteLine("  6. Visualizar arbol");
                Console.WriteLine("  7. Limpiar arbol");
                Console.WriteLine("  0. Salir");
                Console.WriteLine("================================");
                Console.Write("  Opcion: ");

                switch (Console.ReadLine()?.Trim())
                {
                    case "1":
                        Console.Write("  Valor(es) separados por coma: ");
                        foreach (string s in Console.ReadLine()!.Split(','))
                            if (int.TryParse(s.Trim(), out int v))
                            { arbol.Insertar(v); Console.WriteLine($"  OK: {v} insertado."); }
                        break;
                    case "2":
                        Console.Write("  Valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int vb))
                            Console.WriteLine(arbol.Buscar(vb) ? $"  SI existe {vb}." : $"  NO existe {vb}.");
                        break;
                    case "3":
                        Console.Write("  Valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int ve))
                            Console.WriteLine(arbol.Eliminar(ve) ? $"  {ve} eliminado." : $"  {ve} no encontrado.");
                        break;
                    case "4":
                        arbol.Preorden();
                        arbol.Inorden();
                        arbol.Postorden();
                        break;
                    case "5":
                        Console.WriteLine($"  Minimo : {arbol.ObtenerMinimo()}");
                        Console.WriteLine($"  Maximo : {arbol.ObtenerMaximo()}");
                        Console.WriteLine($"  Altura : {arbol.Altura()}");
                        break;
                    case "6":
                        arbol.MostrarArbol();
                        break;
                    case "7":
                        arbol.Limpiar();
                        Console.WriteLine("  Arbol limpiado.");
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("  Opcion invalida.");
                        break;
                }
                if (continuar)
                {
                    Console.Write("\n  Enter para continuar...");
                    Console.ReadLine();
                }
            }
        }
    }
}