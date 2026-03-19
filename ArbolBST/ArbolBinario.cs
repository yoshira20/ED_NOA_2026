using System;

namespace ArbolBST
{
    public class ArbolBinario
    {
        private Nodo? _raiz;

        public void Insertar(int valor)
        {
            _raiz = Insertar(_raiz, valor);
        }

        private Nodo Insertar(Nodo? nodo, int valor)
        {
            if (nodo == null) return new Nodo(valor);
            if (valor < nodo.Valor)
                nodo.Izquierdo = Insertar(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = Insertar(nodo.Derecho, valor);
            else
                Console.WriteLine($"  El valor {valor} ya existe.");
            return nodo;
        }

        public bool Buscar(int valor)
        {
            Nodo? actual = _raiz;
            while (actual != null)
            {
                if (valor == actual.Valor) return true;
                actual = valor < actual.Valor ? actual.Izquierdo : actual.Derecho;
            }
            return false;
        }

        public bool Eliminar(int valor)
        {
            if (!Buscar(valor)) return false;
            _raiz = Eliminar(_raiz, valor);
            return true;
        }

        private Nodo? Eliminar(Nodo? nodo, int valor)
        {
            if (nodo == null) return null;
            if (valor < nodo.Valor)
                nodo.Izquierdo = Eliminar(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = Eliminar(nodo.Derecho, valor);
            else
            {
                if (nodo.Izquierdo == null) return nodo.Derecho;
                if (nodo.Derecho == null) return nodo.Izquierdo;
                int sucesor = Minimo(nodo.Derecho);
                nodo.Valor = sucesor;
                nodo.Derecho = Eliminar(nodo.Derecho, sucesor);
            }
            return nodo;
        }

        public void Preorden()
        {
            if (Vacio()) { Console.WriteLine("  Arbol vacio."); return; }
            Console.Write("  Preorden: ");
            Preorden(_raiz);
            Console.WriteLine();
        }
        private void Preorden(Nodo? n)
        {
            if (n == null) return;
            Console.Write($"{n.Valor} ");
            Preorden(n.Izquierdo);
            Preorden(n.Derecho);
        }

        public void Inorden()
        {
            if (Vacio()) { Console.WriteLine("  Arbol vacio."); return; }
            Console.Write("  Inorden:  ");
            Inorden(_raiz);
            Console.WriteLine();
        }
        private void Inorden(Nodo? n)
        {
            if (n == null) return;
            Inorden(n.Izquierdo);
            Console.Write($"{n.Valor} ");
            Inorden(n.Derecho);
        }

        public void Postorden()
        {
            if (Vacio()) { Console.WriteLine("  Arbol vacio."); return; }
            Console.Write("  Postorden:");
            Postorden(_raiz);
            Console.WriteLine();
        }
        private void Postorden(Nodo? n)
        {
            if (n == null) return;
            Postorden(n.Izquierdo);
            Postorden(n.Derecho);
            Console.Write($"{n.Valor} ");
        }

        public int? ObtenerMinimo()
        {
            if (Vacio()) return null;
            return Minimo(_raiz!);
        }
        private int Minimo(Nodo n)
        {
            while (n.Izquierdo != null) n = n.Izquierdo;
            return n.Valor;
        }

        public int? ObtenerMaximo()
        {
            if (Vacio()) return null;
            Nodo n = _raiz!;
            while (n.Derecho != null) n = n.Derecho;
            return n.Valor;
        }

        public int Altura() => Altura(_raiz);
        private int Altura(Nodo? n)
        {
            if (n == null) return 0;
            return 1 + Math.Max(Altura(n.Izquierdo), Altura(n.Derecho));
        }

        public void Limpiar() => _raiz = null;

        public bool Vacio() => _raiz == null;

        public void MostrarArbol()
        {
            if (Vacio()) { Console.WriteLine("  Arbol vacio."); return; }
            Console.WriteLine();
            Mostrar(_raiz, "", true);
            Console.WriteLine();
        }
        private void Mostrar(Nodo? n, string prefijo, bool esUltimo)
        {
            if (n == null) return;
            Console.WriteLine(prefijo + (esUltimo ? "L-- " : "|-- ") + n.Valor);
            string p = prefijo + (esUltimo ? "    " : "|   ");
            if (n.Derecho != null) Mostrar(n.Derecho, p, n.Izquierdo == null);
            if (n.Izquierdo != null) Mostrar(n.Izquierdo, p, true);
        }
    }
}