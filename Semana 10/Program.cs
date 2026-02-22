using System;
using System.Collections.Generic;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// ═══════════════════════════════════════════════════════════════
//   DATOS FICTICIOS - NOMBRES Y APELLIDOS
// ═══════════════════════════════════════════════════════════════

string[] nombres = {
    "Santiago", "Valentina", "Mateo", "Isabella", "Sebastian",
    "Camila", "Nicolas", "Sofia", "Alejandro", "Valeria",
    "Daniel", "Gabriela", "Diego", "Mariana", "Andres",
    "Natalia", "Juan", "Paula", "Carlos", "Laura",
    "Felipe", "Andrea", "Miguel", "Carolina", "David",
    "Monica", "Luis", "Paola", "Jorge", "Diana",
    "Ricardo", "Claudia", "Sergio", "Viviana", "Cristian",
    "Daniela", "Fernando", "Tatiana", "Hector", "Juliana",
    "Oscar", "Melissa", "Raul", "Vanessa", "Ivan",
    "Catalina", "Esteban", "Stephanie", "Manuel", "Patricia"
};

string[] apellidos = {
    "Garcia", "Rodriguez", "Martinez", "Lopez", "Gonzalez",
    "Perez", "Sanchez", "Ramirez", "Torres", "Flores",
    "Rivera", "Gomez", "Diaz", "Cruz", "Morales",
    "Reyes", "Gutierrez", "Ortiz", "Chavez", "Ramos",
    "Vargas", "Castillo", "Jimenez", "Moreno", "Romero",
    "Herrera", "Medina", "Aguilar", "Vega", "Rojas",
    "Mendoza", "Castro", "Nunez", "Alvarez", "Ruiz",
    "Soto", "Rios", "Fuentes", "Guerrero", "Cardenas",
    "Acosta", "Pena", "Valencia", "Salazar", "Montoya",
    "Suarez", "Molina", "Delgado", "Espinoza", "Paredes"
};

// ═══════════════════════════════════════════════════════════════
//   PASO 1: CREAR CONJUNTO UNIVERSO - 500 CIUDADANOS
// ═══════════════════════════════════════════════════════════════

var rnd = new Random(42); // semilla fija: resultados siempre iguales
var listaCiudadanos = new List<string>();

for (int i = 1; i <= 500; i++)
{
    string nombre    = nombres[rnd.Next(nombres.Length)];
    string apellido1 = apellidos[rnd.Next(apellidos.Length)];
    string apellido2 = apellidos[rnd.Next(apellidos.Length)];
    listaCiudadanos.Add($"{nombre} {apellido1} {apellido2}");
}

// Se usa HashSet para garantizar unicidad y aplicar teoría de conjuntos
HashSet<string> conjuntoU = new HashSet<string>(listaCiudadanos);

// ═══════════════════════════════════════════════════════════════
//   PASO 2: CREAR CONJUNTO A - 75 VACUNADOS CON PFIZER
// ═══════════════════════════════════════════════════════════════

// Se toman los primeros 75 ciudadanos del universo
HashSet<string> conjuntoA = new HashSet<string>(
    conjuntoU.Take(75)
);

// ═══════════════════════════════════════════════════════════════
//   PASO 3: CREAR CONJUNTO B - 75 VACUNADOS CON ASTRAZENECA
// ═══════════════════════════════════════════════════════════════

// Se toman 75 ciudadanos a partir del ciudadano #51
// Esto genera un solapamiento en los ciudadanos #51 a #75
// que representa a quienes recibieron AMBAS vacunas
HashSet<string> conjuntoB = new HashSet<string>(
    conjuntoU.Skip(50).Take(75)
);

// ═══════════════════════════════════════════════════════════════
//   PASO 4: OPERACIONES DE TEORÍA DE CONJUNTOS
// ═══════════════════════════════════════════════════════════════

// --- UNIÓN: A ∪ B ---
// Todos los ciudadanos que recibieron al menos una vacuna
HashSet<string> unionAB = new HashSet<string>(conjuntoA);
unionAB.UnionWith(conjuntoB);

// --- INTERSECCIÓN: A ∩ B ---
// Ciudadanos que recibieron AMBAS dosis (Pfizer y AstraZeneca)
HashSet<string> conjuntoAmbasDosis = new HashSet<string>(conjuntoA);
conjuntoAmbasDosis.IntersectWith(conjuntoB);

// --- DIFERENCIA: A \ B ---
// Ciudadanos que SOLO recibieron Pfizer (están en A pero NO en B)
HashSet<string> conjuntoSoloPfizer = new HashSet<string>(conjuntoA);
conjuntoSoloPfizer.ExceptWith(conjuntoB);

// --- DIFERENCIA: B \ A ---
// Ciudadanos que SOLO recibieron AstraZeneca (están en B pero NO en A)
HashSet<string> conjuntoSoloAstraZeneca = new HashSet<string>(conjuntoB);
conjuntoSoloAstraZeneca.ExceptWith(conjuntoA);

// --- COMPLEMENTO: U \ (A ∪ B) ---
// Ciudadanos que NO se han vacunado con ninguna dosis
HashSet<string> conjuntoNoVacunados = new HashSet<string>(conjuntoU);
conjuntoNoVacunados.ExceptWith(unionAB);

// ═══════════════════════════════════════════════════════════════
//   PASO 5: MOSTRAR RESUMEN ESTADÍSTICO
// ═══════════════════════════════════════════════════════════════

Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║       MINISTERIO DE SALUD - CAMPAÑA VACUNACIÓN COVID-19    ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
Console.WriteLine();
Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
Console.WriteLine("  CONJUNTOS CREADOS");
Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
Console.WriteLine($"  Conjunto U  (universo de ciudadanos):       {conjuntoU.Count,5}");
Console.WriteLine($"  Conjunto A  (vacunados con Pfizer):         {conjuntoA.Count,5}");
Console.WriteLine($"  Conjunto B  (vacunados con AstraZeneca):    {conjuntoB.Count,5}");
Console.WriteLine();
Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
Console.WriteLine("  RESULTADOS POR OPERACIÓN DE CONJUNTOS");
Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
Console.WriteLine($"  No vacunados      U \\ (A ∪ B):             {conjuntoNoVacunados.Count,5}");
Console.WriteLine($"  Ambas dosis           A ∩ B  :             {conjuntoAmbasDosis.Count,5}");
Console.WriteLine($"  Solo Pfizer           A \\ B  :             {conjuntoSoloPfizer.Count,5}");
Console.WriteLine($"  Solo AstraZeneca      B \\ A  :             {conjuntoSoloAstraZeneca.Count,5}");
Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
int verificacion = conjuntoNoVacunados.Count + conjuntoAmbasDosis.Count
                 + conjuntoSoloPfizer.Count  + conjuntoSoloAstraZeneca.Count;
Console.WriteLine($"  Verificacion total (debe ser 500):          {verificacion,5}");
Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

// ═══════════════════════════════════════════════════════════════
//   PASO 6: MOSTRAR LOS 4 LISTADOS SOLICITADOS
// ═══════════════════════════════════════════════════════════════

MostrarListado(
    "LISTADO 1 — CIUDADANOS NO VACUNADOS  [ U \\ (A ∪ B) ]",
    conjuntoNoVacunados);

MostrarListado(
    "LISTADO 2 — CIUDADANOS CON AMBAS DOSIS  [ A ∩ B ]",
    conjuntoAmbasDosis);

MostrarListado(
    "LISTADO 3 — CIUDADANOS SOLO CON PFIZER  [ A \\ B ]",
    conjuntoSoloPfizer);

MostrarListado(
    "LISTADO 4 — CIUDADANOS SOLO CON ASTRAZENECA  [ B \\ A ]",
    conjuntoSoloAstraZeneca);

Console.WriteLine("\n✅ Procesamiento completado exitosamente.");

// ═══════════════════════════════════════════════════════════════
//   MÉTODO AUXILIAR PARA IMPRIMIR CADA LISTADO
// ═══════════════════════════════════════════════════════════════

static void MostrarListado(string titulo, HashSet<string> conjunto)
{
    Console.WriteLine();
    Console.WriteLine($"┌─────────────────────────────────────────────────────────┐");
    Console.WriteLine($"│  {titulo}");
    Console.WriteLine($"│  Total: {conjunto.Count} ciudadanos");
    Console.WriteLine($"└─────────────────────────────────────────────────────────┘");

    int i = 1;
    foreach (var ciudadano in conjunto.OrderBy(c => c))
    {
        Console.WriteLine($"   {i,3}. {ciudadano}");
        i++;
    }
}