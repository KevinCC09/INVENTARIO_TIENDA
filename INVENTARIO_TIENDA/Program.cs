using System;

namespace INVENTARIO_TIENDA
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

  static void AgregarProducto()
  {
    if (totalProductos >=MAX_PRODUCTOS)
    {
      Console.Writeline("El inventario esta lleno. No se puede agregar mas productos")
        return;
    }
    Console.Write("Ingrese el nombre del producto: ");
    string nombre = Console.ReadLine()?.Trim()

      if(string.IsNullorEmpt(nombre))
      {
        Console.WriteLine(#El nombre no puede estar vacio.");
        return;
      }

      for(int i=0; i < totalProductos; i++)
      {
        if(nombres[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
        {
          COnsole.WriteLine($"El producto '{nombre)' ya existe en el inventario.");
          return;
        }
      }
      Console.Write("Ingrese el precio del producto: $");
      if(!double.TryParce(Console.ReadLine(), out double precio)|| precio < 0)
      {
        Console.WriteLine("Precio invalido.");
        return;
      }
      COnsole.Write("Ingrese la cantidad en stock: ");
      if(!int.TryParce(Console.ReadLine(), out int cantidad)|| cantidad<0)
      {
        Console.WriteLine("Cantidad invalida.");
        return;
      }
  }


}


