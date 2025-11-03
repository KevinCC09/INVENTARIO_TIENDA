using System;

namespace INVENTARIO_TIENDA;
class program
{
  const int MAX_PRODUCTOS = 5;
  static string[] nombres = new string [MAX_PRODUCTOS];
  static double[] precios = new double[MAX_PRODUCTOS];
  static int[] stock = new int[MAX_PRODUCTOS];
  static int totalProductos = 0;

  static void main(string[] args)
  { 
        int opcion;
        do
        {
            strarMenu();
            opcion = LeerOpcion();

            switch (opcion)
            {
            case 1:
                AgregarProducto();
                break;
            case 2:
                BuscarProducto();
                break;
            case 3:
                MostrarInventario();
                break;
                case 0:
                Console.WriteLine("Saliendo del sistema. ¡Hasta luego!");
                break;
            default:
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }

        }while (opcion != 0);
  }


}


