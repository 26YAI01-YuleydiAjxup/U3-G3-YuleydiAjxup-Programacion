using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_Tienda
{
    internal class Program
    {
        // Declaración de la matriz global de 10 filas y 3 columnas para almacenar el inventario
        // Columna 0: Código del producto
        // Columna 1: Nombre del producto
        // Columna 2: Cantidad en existencia
        static string[,] inventario = new string[10, 3];

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("    MENÚ - CONTROL DE TIENDA     ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Registrar producto");
                Console.WriteLine("2. Mostrar productos");
                Console.WriteLine("3. Actualizar producto");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                // Estructura de control para manejar las opciones del menú
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("=== REGISTRAR PRODUCTO ===");
                        RegistrarProducto();
                        Pausa();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("=== LISTA DE PRODUCTOS ===");
                        MostrarProductos();
                        Pausa();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("=== ACTUALIZAR PRODUCTO ===");
                        ActualizarProducto();
                        Pausa();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("=== ELIMINAR PRODUCTO ===");
                        EliminarProducto();
                        Pausa();
                        break;
                    case 5:
                        Console.WriteLine("\nSaliendo del sistema de inventario...");
                        break;
                    default:
                        Console.WriteLine("\nOpción inválida. Intente de nuevo.");
                        Pausa();
                        break;
                }
            } while (opcion != 5);
        }

        // Método para registrar un producto en el primer espacio disponible de la matriz
        static void RegistrarProducto()
        {
            bool registrado = false;

            for (int i = 0; i < 10; i++)
            {
                // Verifica si la fila está vacía para almacenar el nuevo producto
                if (string.IsNullOrEmpty(inventario[i, 0]))
                {
                    Console.Write("Ingrese Código del producto: ");
                    inventario[i, 0] = Console.ReadLine();

                    Console.Write("Ingrese Nombre del producto: ");
                    inventario[i, 1] = Console.ReadLine();

                    Console.Write("Ingrese Cantidad en existencia: ");
                    inventario[i, 2] = Console.ReadLine();

                    Console.WriteLine("\n¡Producto registrado exitosamente!");
                    registrado = true;
                    break;
                }
            }

            if (!registrado)
            {
                Console.WriteLine("\nLa matriz de inventario está llena.");
            }
        }

        // Método para mostrar todos los productos registrados en la matriz
        static void MostrarProductos()
        {
            Console.WriteLine("\nCÓDIGO\t\tNOMBRE\t\tCANTIDAD");
            Console.WriteLine("--------------------------------------------------");

            for (int i = 0; i < 10; i++)
            {
                // Muestra únicamente las filas que contienen información
                if (!string.IsNullOrEmpty(inventario[i, 0]))
                {
                    Console.WriteLine(inventario[i, 0] + "\t\t" + inventario[i, 1] + "\t\t" + inventario[i, 2]);
                }
            }
        }

        // Método para buscar un producto por su código y modificar su nombre o cantidad
        static void ActualizarProducto()
        {
            string codigoBuscar;
            bool encontrado = false;

            Console.Write("Ingrese el código del producto a buscar: ");
            codigoBuscar = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                if (inventario[i, 0] == codigoBuscar)
                {
                    Console.Write("Nuevo nombre del producto: ");
                    inventario[i, 1] = Console.ReadLine();

                    Console.Write("Nueva cantidad en existencia: ");
                    inventario[i, 2] = Console.ReadLine();

                    Console.WriteLine("\n¡Registro de producto actualizado con éxito!");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("\nNo se encontró ningún producto con ese código.");
            }
        }

        // Método para eliminar un producto utilizando su código (limpia la fila)
        static void EliminarProducto()
        {
            string codigoEliminar;
            bool encontrado = false;

            Console.Write("Ingrese el código del producto a eliminar: ");
            codigoEliminar = Console.ReadLine();

            for (int i = 0; i < 10; i++)
            {
                if (inventario[i, 0] == codigoEliminar)
                {
                    inventario[i, 0] = "";
                    inventario[i, 1] = "";
                    inventario[i, 2] = "";

                    Console.WriteLine("\n¡Producto eliminado del inventario!");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("\nCódigo no encontrado en el sistema.");
            }
        }

        // Método auxiliar para pausar la consola antes de limpiar la pantalla
        static void Pausa()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
