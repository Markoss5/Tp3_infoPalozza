using System;

public class Cliente
{
    public int DNI { get; private set; }
    public string Apellido { get; private set; }
    public string Nombre { get; private set; }
    public DateTime FechaInscripcion { get; set; }
    public int TipoEntrada { get; set; }
    public int Cantidad { get; set; }

    public Cliente(int dni, string apellido, string nombre, DateTime fechaInscripcion, int tipoEntrada, int cantidad)
    {
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        FechaInscripcion = fechaInscripcion;
        TipoEntrada = tipoEntrada;
        Cantidad = cantidad;
    }

    public int CalcularImporte()
    {
        switch (TipoEntrada)
        {
            case 1: return 45000 * Cantidad;
            case 2: return 60000 * Cantidad;
            case 3: return 30000 * Cantidad;
            case 4: return 100000 * Cantidad;
            default: return 0;
        }
    }
}

