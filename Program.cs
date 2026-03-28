namespace Ej_Diccionarios;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> dicRecursos = new Dictionary<string, int>{
                { "Metal", 10 },
                 { "Madera", 15 },
                 {"Ladrillo", 13}
        };
        
        int menu;
        List<string> opciones = new List<string>()
        {
            "Ver inventario",
            "Actualizar el stock",
            "Consumir un recurso",
            "Consultar un recurso específico",
            "Salir"
        };
        menu = PedirOpcion(opciones, opciones.Count);

        while (menu != opciones.Count)
        {
            accionar(dicRecursos, opciones, menu);
            menu = PedirOpcion(opciones, opciones.Count);
        }

    }
    
    private static void accionar(Dictionary<string, int> dicRecursos,List<string> opciones, int menu)
    {
       

        switch (menu)
        {
            case 1:

            verInventario(dicRecursos);
                break;

            case 2:
            actualizarStock(dicRecursos);
                break;

            case 3:
                consumirRecurso(dicRecursos);
                break;

            case 4:
                consultarRecurso(dicRecursos);
                break;

        }
        }
        private static void consultarRecurso(Dictionary<string, int> dicRecursos)
    {
        string recurso = pedirString("¿Qué recurso desea consultar?: ");
        if (dicRecursos.ContainsKey(recurso))
        {
            Console.WriteLine("Hay " + dicRecursos[recurso] + " de " + recurso + ".");
        }
        else
        {
            Console.WriteLine("No tienes ese recurso");
        }
        
    }
        private static void consumirRecurso(Dictionary<string, int> dicRecursos)
    {
        string recurso;
        int cantidad = 0;
        int consumicion = 0;
        recurso = pedirString("¿Qué recurso desea consumir?: ");
        
        if (dicRecursos.ContainsKey(recurso))
        {
            cantidad = pedirInt("¿Cuánta cantidad desea consumir?: ");
            consumicion = dicRecursos[recurso] - cantidad;
            if(consumicion >= 0)
            {
                dicRecursos[recurso] = consumicion;
                Console.WriteLine("Te has quedado con " + consumicion + " de " + recurso + ".");
                if(consumicion < 5)
                {
                    Console.WriteLine("ALERTA: REABASTECER " + recurso + "!");
                }
            }
            else
            {
                Console.WriteLine("No puedes consumir esa cantidad.");
            }
        }
        else
        {
            Console.WriteLine("No tienes ese recurso disponible.");
        }
    }
        private static void actualizarStock(Dictionary<string, int> dicRecursos)
    {
        string recurso;
        int cantidad = 0;
              recurso = pedirString("¿Qué recurso desea cargar?: ");
              cantidad = pedirInt("¿Cuánta cantidad desea cargarle?: ");
                 if (dicRecursos.ContainsKey(recurso))
                {
                   
                    dicRecursos[recurso] += cantidad;
                }
                else{
                    
                    dicRecursos.Add(recurso, cantidad);

                }
    }
        private static void verInventario(Dictionary<string, int> dicRecursos)
    {
        foreach (KeyValuePair<string,int> recurso in dicRecursos)
            {
               Console.WriteLine("Hay " + recurso.Value +" de " + recurso.Key + ".")     ;
            }
    }
        private static int pedirInt(string x){
            Console.WriteLine(x);
            return int.Parse(Console.ReadLine());
        }
        private static string pedirString(string x){
            Console.WriteLine(x);
            return Console.ReadLine();
        }
  private static int PedirOpcion(List<string> opciones, int cantidadOpciones)
    {
        int x;
        do
        {
            Console.WriteLine("Ingrese la opcion del menú que desee: ");
            for (int i = 0; i < opciones.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + opciones[i]);
            }

            x = int.Parse(Console.ReadLine());

        } while (x < 1 || x > cantidadOpciones);

        return x;
    }
    
}
