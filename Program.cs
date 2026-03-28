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
        int tarsiHizoCambios= 0;
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

            foreach (KeyValuePair<string,int> recurso in dicRecursos)
            {
               Console.WriteLine("Tenés " + recurso.Value +" de " + recurso.Key + ".")     ;
            }
                break;

            case 2:
            string Recurso;
            int cantidad = 0;
              Recurso = pedirString("Que recurso queres cargar?");
                 if (dicRecursos.ContainsKey(Recurso))
                {
                   cantidad = pedirInt("Cuanto queres cargarle?");
                    dicRecursos[Recurso] += cantidad;
                }
                else{
                    dicRecursos.Add(Recurso, 0);

                }
                break;

            case 3:

                break;

            case 4:
                
                break;

            case 5:
              
                break;
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
