using System;

namespace INVENTARIO_TIENDA;
class program
{
  const int MAX_PRODUCTOS = 5;
  static string[] nombres = new string [MAX_PRODUCTOS];
  static double[] precios = new double[MAX_PRODUCTOS];
  static int[] stock = new int[MAX_PRODUCTOS];
  static int totalProductos = 0;
  
  static void Main(string[] args)
  { 
        int opcion;
        do
        {
            MostrarMenu();
            if (!int.TryParse(Console.ReadLine(), out opcion))
            opcion = -1; // entrada no numérica → opción inválida

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
  static void MostrarMenu()
  {
    Console.WriteLine("===INVENTARIO_TIENDA===");
    Console.WriteLine("1. Agregar producto nuevo");
    Console.WriteLine("2. Consultar / Actualizar producto");
    Console.WriteLine("3. Mostrar todo el inventario");
    Console.WriteLine("0. Salir");
  }

  static void AgregarProducto()
  {
    if (totalProductos >=MAX_PRODUCTOS)
    {
        Console.WriteLine("El inventario esta lleno. No se puede agregar mas productos")
        return;
    }

    Console.Write("Ingrese el nombre del producto: ");
    string nombre = Console.ReadLine()?.Trim();

      if(string.IsNullOrEmpt(nombre))
      {
        Console.WriteLine("El nombre no puede estar vacio.");
        return;
      }

      for(int i=0; i < totalProductos; i++)
      {
        if(nombres[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
          {
            Console.WriteLine($"El producto '{nombre})' ya existe en el inventario.");
            return;
          }
      }
          
      
      Console.Write("Ingrese el precio del producto: $");
      if(!double.TryParse(Console.ReadLine(), out double precio)|| precio < 0)
      {
        Console.WriteLine("Precio invalido.");
        return;
      }
      Console.Write("Ingrese la cantidad en stock: ");
      if(!int.TryParse(Console.ReadLine(), out int cantidad)|| cantidad<0)
      {
        Console.WriteLine("Cantidad invalida.");
        return;
      }
      nombres[totalProductos] = nombre;
      precios[totalProductos] = precio;
      stock[totalProductos] = cantidad;
      totalProductos++;

      COnsole.WriteLine($"Producto '{nombre}' agregado exitosamente.")
    }
  static void BuscarProducto()
  {
    //Raul empieza la primera mitad
    {
         if (TotalProductos == 0)
        {
            console.WriteLine("El inventario esta vacio: ");
            return;
        }
        Console.Write("Ingrese el nombre del producto a buscar: ");
        string nombreBuscado = Console.ReadLine()?.trim();
      
        if (string.IsNullOrEmpt(nombreBuscado)) ;
        {
        console.WriteLine("Nombre Invalido. ");
        return;
        }

        int indice = -1;
        for (int i = 0; i < TotalProductos; i++)
        {
          if (nombres[i].Equals(nombreBuscado, StringComparisom.OrdinalIgnoreCase))
          {
            indice = 1;
            break;
          }
        }
        if (indice == -1)
        {
          Console.WriteLine($"El producto {nombreBuscado} no existe en el inventario: ");
          return;
        }
    }
       //producto encontrado + monstrar info y dar opciones
    string categoria = ObtenerCategoria(precio[indice]);
    Console.WriteLine($"\nProducto encontrado: ");
    Console.WriteLine($"   nombre: {nombres[indice]}");
    Console.WriteLine($"   precio: ${precios[indice]:F2}");
    Console.WriteLine($"   Stock actual: {Stock[indice]}unidades");
    Console.WriteLine($"   categoria: {categoria}");
 
    //submenú para actualizar stock
    Console.WriteLine($"\n¿Qué desea hacer?");
    Console.WriteLine("1. Añadir unidades");
    Console.WriteLine("2. Quitar unidades");
    Console.WriteLine("0. Volver al menú principal");
    Console.Write("Seleccione una opción: ");
 
    if (!int.TryParse(Console.ReadLine(), out int opcionSub))
    {
      Console.WriteLine("Opción inválida.");
      return;
    }

    switch (opcionSub)
    {
    case 1:
        Console.Write("¿Cuántas unidades desea AÑADIR? ");
        if (int.TryParse(Console.ReadLine(), out int agregar) && agregar > 0)
        {
            stock[indice] += agregar;
            Console.WriteLine($"Se añadieron {agregar} unidades. Nuevo stock: {stock[indice]}");
        }
        else
        {
            Console.WriteLine("Cantidad inválida. Debe ser un número entero positivo.");
        }
        break;
    case 2:
        Console.Write("¿Cuántas unidades desea QUITAR? ");
        if (int.TryParse(Console.ReadLine(), out int quitar) && quitar > 0)
        {
            if (quitar > stock[indice])
            {
              Console.WriteLine($"No puede quitar {quitar} unidades. Solo hay {stock[indice]} en stock.");
            }
            else
            {
              stock[indice] -= quitar;
              Console.WriteLine($"Se quitaron {quitar} unidades. Nuevo stock: {stock[indice]}");
            }
        }
        else
        {
            Console.WriteLine("Cantidad inválida. Debe ser un número entero positivo.");
        }
        break;
    case 0:
        Console.WriteLine("Volviendo al menú principal...");
        break;

    default:
        Console.WriteLine("Opción no válida.");
        break;
    }
    
  static void ObtenerCategoria(double precio)
  {
    int nivel;
    
    if (precio < 20)
    {
      nivel = 1;
    }
    else if (precio >= 20 && precio < 100)
    {
      nivel = 2;
    }
    else // cuando el precio es mayor o igual a 100
    {
      nivel = 3;
    }
    switch (nivel) //Dependera del nivel obtenido
    {
      case 1:
        return "Económico";
      case 2:
        return "Estándar";
      case 3:
        return "Premium";
      default:
        return "Desconocida";
    }
  }
  static void MostrarInventario()
  {
    if (totalProductos == 0)
    {
      Console.WriteLine("El inventario está vacio. ");
    }
    Console.WriteLine("=== INVENTARIO COMPLETO ===");
    Console.WriteLine("{0,-20} ${1,-12} {2,-10} {3,-12}", "Producto", "Precio", "Stock", "Categoria");
    Console.WriteLine(newstring('-',55));
    
  }


}


