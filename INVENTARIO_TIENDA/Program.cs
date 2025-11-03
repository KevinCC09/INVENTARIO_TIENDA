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
            static void AgregarProducto()
        {
            if(totalProductos >= MAX_PRODUCTOS)
            {
                Console.WriteLine("EL inventario esta lleno. No se puede agregar mas productos.")return;

            }

            Console.WriteLine("Ingrese el nombre del producto: ")
            string nombre= Console.ReadLine()?.Trim();

            if(string.IsNu110rEmpty(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacio. ")
                return;
            }
            //Verificar si ya existe (opcional,según enunciado)
            for(int i=0; i < totalProductos; i++)
            {
                if(nombre[i].Equals(nombre, stringComparison.Ordina1IgnoreCase) )
                {
                    Console.WriteLine($"El producto '{nombre}' ya existe en el inventario.");
                    return;
                }
            }
            Console.WriteLine("INgrese el precio del producto: $")
            
            if(!double.TryParce(Console.ReadLine(), out double precio )|| precio < 0)
            {
                Console.WriteLine("Precio Invalido");
                return;
            }

            Console.WriteLine("Ingrese la cantidad en stock: ");
            if(!int.TryParce(Console.ReadLine(), out int cantidad)||cantidad < 0)
            {
                Console.WriteLine("Cantidad inválida.")
                return;
            }

            //Agregar inventario
            nombres[totalProductos] = nombre;
            precios[totalProductos] = precio;
            stock[totalProductos] = cantidad;
            totalProductos++;

            Console.WriteLine($"Producto '{nombre} agregado exitosamente.")
        }
  }


}


