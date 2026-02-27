using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Traductor
{
    // ── Diccionarios bidireccionales ─────────────────────────────────────────
    static Dictionary<string, string> engToEsp = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "time",       "tiempo"    },
        { "person",     "persona"   },
        { "year",       "año"       },
        { "way",        "camino"    },
        { "day",        "día"       },
        { "thing",      "cosa"      },
        { "man",        "hombre"    },
        { "world",      "mundo"     },
        { "life",       "vida"      },
        { "hand",       "mano"      },
        { "part",       "parte"     },
        { "child",      "niño"      },
        { "eye",        "ojo"       },
        { "woman",      "mujer"     },
        { "place",      "lugar"     },
        { "work",       "trabajo"   },
        { "week",       "semana"    },
        { "case",       "caso"      },
        { "point",      "punto"     },
        { "government", "gobierno"  },
        { "company",    "empresa"   }
    };

    static Dictionary<string, string> espToEng = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "tiempo",   "time"       },
        { "persona",  "person"     },
        { "año",      "year"       },
        { "camino",   "way"        },
        { "día",      "day"        },
        { "cosa",     "thing"      },
        { "hombre",   "man"        },
        { "mundo",    "world"      },
        { "vida",     "life"       },
        { "mano",     "hand"       },
        { "parte",    "part"       },
        { "niño",     "child"      },
        { "ojo",      "eye"        },
        { "mujer",    "woman"      },
        { "lugar",    "place"      },
        { "trabajo",  "work"       },
        { "semana",   "week"       },
        { "caso",     "case"       },
        { "punto",    "point"      },
        { "gobierno", "government" },
        { "empresa",  "company"    }
    };

    // ── Colores de consola ───────────────────────────────────────────────────
    static void Color(string texto, ConsoleColor color, bool newLine = true)
    {
        Console.ForegroundColor = color;
        if (newLine) Console.WriteLine(texto);
        else         Console.Write(texto);
        Console.ResetColor();
    }

    // ── Menú principal ───────────────────────────────────────────────────────
    static void MostrarMenu()
    {
        Console.WriteLine();
        Color("==================== MENÚ ====================", ConsoleColor.Cyan);
        Color("  1. Traducir una frase",                        ConsoleColor.White);
        Color("  2. Agregar palabras al diccionario",           ConsoleColor.White);
        Color("  3. Ver diccionario completo",                  ConsoleColor.White);
        Color("  0. Salir",                                     ConsoleColor.White);
        Color("==============================================", ConsoleColor.Cyan);
        Color("Seleccione una opción: ", ConsoleColor.Yellow, newLine: false);
    }

    // ── Traducir frase ───────────────────────────────────────────────────────
    static string TraducirFrase(string frase, Dictionary<string, string> diccionario)
    {
        // Separamos en tokens conservando signos de puntuación
        var tokens = Regex.Split(frase, @"(\b)");
        StringBuilder resultado = new StringBuilder();

        foreach (var token in tokens)
        {
            // Extraemos solo la parte alfabética para buscar en el diccionario
            string soloLetras = Regex.Replace(token, @"[^a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]", "");

            if (!string.IsNullOrEmpty(soloLetras) && diccionario.ContainsKey(soloLetras))
            {
                string traduccion = diccionario[soloLetras];

                // Respetar mayúscula inicial si la palabra original la tenía
                if (char.IsUpper(token[0]))
                    traduccion = char.ToUpper(traduccion[0]) + traduccion.Substring(1);

                // Reemplazar solo las letras, conservar puntuación pegada
                resultado.Append(token.Replace(soloLetras, traduccion,
                    StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                resultado.Append(token);
            }
        }
        return resultado.ToString();
    }

    // ── Opción 1: Traducir ───────────────────────────────────────────────────
    static void OpcionTraducir()
    {
        Console.WriteLine();
        Color("──────────────────────────────────────────────", ConsoleColor.DarkCyan);
        Color("  TRADUCTOR DE FRASES", ConsoleColor.Cyan);
        Color("──────────────────────────────────────────────", ConsoleColor.DarkCyan);

        Color("\n  Dirección de traducción:", ConsoleColor.White);
        Color("   [1] Español  →  Inglés", ConsoleColor.Gray);
        Color("   [2] Inglés   →  Español", ConsoleColor.Gray);
        Color("  Elija: ", ConsoleColor.Yellow, newLine: false);

        string dir = Console.ReadLine()?.Trim();
        Dictionary<string, string> diccionario;
        string etiqueta;

        if (dir == "1")      { diccionario = espToEng; etiqueta = "Español → Inglés"; }
        else if (dir == "2") { diccionario = engToEsp; etiqueta = "Inglés → Español"; }
        else { Color("\n  Opción no válida.", ConsoleColor.Red); return; }

        Color($"\n  [{etiqueta}]", ConsoleColor.DarkYellow);
        Color("  Ingrese la frase: ", ConsoleColor.Yellow, newLine: false);
        string frase = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(frase))
        {
            Color("\n  La frase no puede estar vacía.", ConsoleColor.Red);
            return;
        }

        string traduccion = TraducirFrase(frase, diccionario);

        Console.WriteLine();
        Color("  ✔ Original:   ", ConsoleColor.DarkGray, newLine: false);
        Color(frase,              ConsoleColor.White);
        Color("  ✔ Traducción: ", ConsoleColor.Green,   newLine: false);
        Color(traduccion,         ConsoleColor.Cyan);
        Color("──────────────────────────────────────────────", ConsoleColor.DarkCyan);
    }

    // ── Opción 2: Agregar palabras ───────────────────────────────────────────
    static void OpcionAgregarPalabra()
    {
        Console.WriteLine();
        Color("──────────────────────────────────────────────", ConsoleColor.DarkCyan);
        Color("  AGREGAR PALABRAS AL DICCIONARIO", ConsoleColor.Cyan);
        Color("──────────────────────────────────────────────", ConsoleColor.DarkCyan);

        Color("  Palabra en Español: ", ConsoleColor.Yellow, newLine: false);
        string esp = Console.ReadLine()?.Trim().ToLower();

        Color("  Palabra en Inglés:  ", ConsoleColor.Yellow, newLine: false);
        string eng = Console.ReadLine()?.Trim().ToLower();

        if (string.IsNullOrWhiteSpace(esp) || string.IsNullOrWhiteSpace(eng))
        {
            Color("\n  ✘ Ningún campo puede estar vacío.", ConsoleColor.Red);
            return;
        }

        bool yaExisteEsp = espToEng.ContainsKey(esp);
        bool yaExisteEng = engToEsp.ContainsKey(eng);

        if (yaExisteEsp || yaExisteEng)
        {
            Color($"\n  ⚠ La palabra '{(yaExisteEsp ? esp : eng)}' ya existe en el diccionario.", ConsoleColor.Yellow);
            Color("  ¿Desea sobreescribirla? (s/n): ", ConsoleColor.Yellow, newLine: false);
            if (Console.ReadLine()?.Trim().ToLower() != "s") { Color("  Operación cancelada.", ConsoleColor.DarkGray); return; }
        }

        espToEng[esp] = eng;
        engToEsp[eng] = esp;

        Color($"\n  ✔ Agregado correctamente: '{esp}' ↔ '{eng}'", ConsoleColor.Green);
        Color("──────────────────────────────────────────────", ConsoleColor.DarkCyan);
    }

    // ── Opción 3: Ver diccionario ────────────────────────────────────────────
    static void OpcionVerDiccionario()
    {
        Console.WriteLine();
        Color("──────────────────────────────────────────────", ConsoleColor.DarkCyan);
        Color("  DICCIONARIO COMPLETO", ConsoleColor.Cyan);
        Color($"  Total de palabras: {espToEng.Count}", ConsoleColor.DarkGray);
        Color("──────────────────────────────────────────────", ConsoleColor.DarkCyan);
        Color("  #   ESPAÑOL           INGLÉS", ConsoleColor.White);
        Color("  ─   ────────────────  ────────────────", ConsoleColor.DarkGray);

        int i = 1;
        foreach (var par in espToEng)
        {
            string num   = i.ToString().PadRight(4);
            string esp   = par.Key.PadRight(18);
            string eng   = par.Value;
            Color($"  {num}{esp}  {eng}", i % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.White);
            i++;
        }
        Color("──────────────────────────────────────────────", ConsoleColor.DarkCyan);
    }

    // ── MAIN ─────────────────────────────────────────────────────────────────
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Clear();

        Color("╔════════════════════════════════════════════╗", ConsoleColor.Cyan);
        Color("║       TRADUCTOR ESPAÑOL ↔ INGLÉS           ║", ConsoleColor.Cyan);
        Color("║       Desarrollado en C#                   ║", ConsoleColor.DarkCyan);
        Color("╚════════════════════════════════════════════╝", ConsoleColor.Cyan);

        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine()?.Trim();

            switch (opcion)
            {
                case "1":
                    OpcionTraducir();
                    break;
                case "2":
                    OpcionAgregarPalabra();
                    break;
                case "3":
                    OpcionVerDiccionario();
                    break;
                case "0":
                    Console.WriteLine();
                    Color("  ¡Hasta luego! / Goodbye!", ConsoleColor.Cyan);
                    continuar = false;
                    break;
                default:
                    Color("\n  ✘ Opción no válida. Intente de nuevo.", ConsoleColor.Red);
                    break;
            }

            if (continuar && opcion != "0")
            {
                Color("\n  Presione ENTER para continuar...", ConsoleColor.DarkGray, newLine: false);
                Console.ReadLine();
                Console.Clear();
                Color("╔════════════════════════════════════════════╗", ConsoleColor.Cyan);
                Color("║       TRADUCTOR ESPAÑOL ↔ INGLÉS           ║", ConsoleColor.Cyan);
                Color("╚════════════════════════════════════════════╝", ConsoleColor.Cyan);
            }
        }
    }
}