using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Nueva Inscripción");
            Console.WriteLine("2. Obtener Estadísticas del Evento");
            Console.WriteLine("3. Buscar Cliente");
            Console.WriteLine("4. Cambiar entrada de un Cliente");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    NuevaInscripcion();
                    break;
                case "2":
                    ObtenerEstadisticas();
                    break;
                case "3":
                    BuscarCliente();
                    break;
                case "4":
                    CambiarEntrada();
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private static void NuevaInscripcion()
    {
        Console.Write("Ingrese DNI: ");
        if (int.TryParse(Console.ReadLine(), out int dni))
        {
            Console.Write("Ingrese Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Tipo de Entrada: ");
            Console.WriteLine("1. Día 1 - $45000");
            Console.WriteLine("2. Día 2 - $60000");
            Console.WriteLine("3. Día 3 - $30000");
            Console.WriteLine("4. Full Pass - $100000");
            Console.Write("Seleccione tipo de entrada: ");
            if (int.TryParse(Console.ReadLine(), out int tipoEntrada) && tipoEntrada >= 1 && tipoEntrada <= 4)
            {
                Console.Write("Ingrese cantidad de entradas: ");
                if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                {
                    Cliente nuevoCliente = new Cliente(dni, apellido, nombre, DateTime.Now, tipoEntrada, cantidad);
                    int idGenerado = Ticketera.AgregarCliente(nuevoCliente);
                    Console.WriteLine($"Inscripción exitosa. ID de entrada: {idGenerado}");
                }
                else
                {
                    Console.WriteLine("Cantidad de entradas no válida.");
                }
            }
            else
            {
                Console.WriteLine("Tipo de entrada no válido.");
            }
        }
        else
        {
            Console.WriteLine("DNI no válido.");
        }
    }

    private static void ObtenerEstadisticas()
    {
        List<string> estadisticas = Ticketera.EstadisticasTicketera();
        foreach (var linea in estadisticas)
        {
            Console.WriteLine(linea);
        }
    }

    private static void BuscarCliente()
    {
        Console.Write("Ingrese el ID del cliente: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Cliente cliente = Ticketera.BuscarCliente(id);
            if (cliente != null)
            {
                Console.WriteLine($"Cliente encontrado: DNI: {cliente.DNI}, Nombre: {cliente.Nombre} {cliente.Apellido}, Fecha Inscripción: {cliente.FechaInscripcion}, Tipo Entrada: {cliente.TipoEntrada}, Cantidad: {cliente.Cantidad}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID no válido.");
        }
    }

    private static void CambiarEntrada()
    {
        Console.Write("Ingrese el ID del cliente: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Nuevo Tipo de Entrada: ");
            Console.WriteLine("1. Día 1 - $45000");
            Console.WriteLine("2. Día 2 - $60000");
            Console.WriteLine("3. Día 3 - $30000");
            Console.WriteLine("4. Full Pass - $100000");
            Console.Write("Seleccione nuevo tipo de entrada: ");
            if (int.TryParse(Console.ReadLine(), out int tipoEntrada) && tipoEntrada >= 1 && tipoEntrada <= 4)
            {
                Console.Write("Ingrese nueva cantidad de entradas: ");
                if (int.TryParse(Console.ReadLine(), out int cantidad) && cantidad > 0)
                {
                    bool cambioExitoso = Ticketera.CambiarEntrada(id, tipoEntrada, cantidad);
                    if (cambioExitoso)
                    {
                        Console.WriteLine("Cambio de entrada realizado con éxito.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo realizar el cambio. Verifique que el nuevo importe sea superior al importe anterior.");
                    }
                }
                else
                {
                    Console.WriteLine("Cantidad de entradas no válida.");
                }
            }
            else
            {
                Console.WriteLine("Tipo de entrada no válido.");
            }
        }
        else
        {
            Console.WriteLine("ID no válido.");
        }
    }
}

