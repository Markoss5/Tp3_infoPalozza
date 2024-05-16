using System;
using System.Collections.Generic;

public static class Ticketera
{
    private static Dictionary<int, Cliente> DicClientes = new Dictionary<int, Cliente>();
    private static int UltimoIDEntrada = 0;

    public static int DevolverUltimoID()
    {
        return UltimoIDEntrada;
    }

    public static int AgregarCliente(Cliente cliente)
    {
        UltimoIDEntrada++;
        DicClientes.Add(UltimoIDEntrada, cliente);
        return UltimoIDEntrada;
    }

    public static Cliente BuscarCliente(int id)
    {
        DicClientes.TryGetValue(id, out Cliente cliente);
        return cliente;
    }

    public static bool CambiarEntrada(int id, int tipo, int cantidad)
    {
        if (DicClientes.TryGetValue(id, out Cliente cliente))
        {
            int nuevoImporte = CalcularImporte(tipo, cantidad);
            int importeActual = cliente.CalcularImporte();

            if (nuevoImporte > importeActual)
            {
                cliente.TipoEntrada = tipo;
                cliente.Cantidad = cantidad;
                cliente.FechaInscripcion = DateTime.Now;
                return true;
            }
        }
        return false;
    }

    public static List<string> EstadisticasTicketera()
    {
        List<string> estadisticas = new List<string>();
        if (DicClientes.Count == 0)
        {
            estadisticas.Add("Aún no se anotó nadie");
            return estadisticas;
        }

        int totalClientes = DicClientes.Count;
        int[] cantidadPorTipo = new int[4];
        int[] recaudacionPorTipo = new int[4];

        foreach (var cliente in DicClientes.Values)
        {
            cantidadPorTipo[cliente.TipoEntrada - 1] += cliente.Cantidad;
            recaudacionPorTipo[cliente.TipoEntrada - 1] += cliente.CalcularImporte();
        }

        int totalRecaudacion = 0;
        foreach (int recaudacion in recaudacionPorTipo)
        {
            totalRecaudacion += recaudacion;
        }

        estadisticas.Add($"Cantidad de Clientes inscriptos: {totalClientes}");
        for (int i = 0; i < 4; i++)
        {
            estadisticas.Add($"Cantidad de Clientes que compraron Tipo {i + 1}: {cantidadPorTipo[i]}");
            estadisticas.Add($"Porcentaje de Tipo {i + 1}: {(double)cantidadPorTipo[i] / totalClientes * 100}%");
            estadisticas.Add($"Recaudación Tipo {i + 1}: ${recaudacionPorTipo[i]}");
        }
        estadisticas.Add($"Recaudación total: ${totalRecaudacion}");

        return estadisticas;
    }

    private static int CalcularImporte(int tipoEntrada, int cantidad)
    {
        switch (tipoEntrada)
        {
            case 1: return 45000 * cantidad;
            case 2: return 60000 * cantidad;
            case 3: return 30000 * cantidad;
            case 4: return 100000 * cantidad;
            default: return 0;
        }
    }
}
