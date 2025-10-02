// See https://aka.ms/new-console-template for more information
Console.WriteLine("Banco America Capitan!");
Cuenta MiCuenta = new Cuenta(1, "Cuenta de Ahorros", "Ahorros", 0);
int opcion = 0;
while(opcion != 4)
{
    Console.WriteLine("################################################################");
    Console.WriteLine("-------------------------M-E-N-U--------------------------------");
    Console.WriteLine("Seleccione una opcion:");
    Console.WriteLine("1. Depositar");
    Console.WriteLine("2. Retirar");
    Console.WriteLine("3. Mostrar Movimientos");
    Console.WriteLine("4. Salir");
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingrese el monto a depositar:");
            double montoDeposito = double.Parse(Console.ReadLine());
            MiCuenta.MovimientoCuenta(1, montoDeposito);
            break;
        case 2:
            Console.WriteLine("Ingrese el monto a retirar:");
            double montoRetiro = double.Parse(Console.ReadLine());
            MiCuenta.MovimientoCuenta(2, montoRetiro);
            break;
        case 3:
            MiCuenta.MostrarMovimientos();
            break;
        case 4:
            Console.WriteLine("Gracias por usar Banco America Capitan!");
            break;
        default:
            Console.WriteLine("Opcion no valida, intente de nuevo.");
            break;
    }
}




public class Movimiento
{
    public DateTime Fecha { get; set; }
    public double Monto { get; set; }
    public string Tipo { get; set; } // "Deposito" o "Retiro"
    public Movimiento(DateTime fecha, string tipo, double monto)
    {
        Fecha = fecha;
        Monto = monto;
        Tipo = tipo;
    }
}

public class Cuenta
{
    public int Id { get; set; }
    public string NomCuenta { get; set; }
    public string Tipo { get; set; }
    public double Saldo { get; private set; }
    public List<Movimiento> Movimientos { get; private set; } = new();
    public Cuenta(int id, string nomCuenta, string tipo, double saldo)
    {
        Id = id;
        Tipo = tipo;
        Saldo = saldo;
        NomCuenta = nomCuenta;
        //Movimientos = new List<Movimiento>();
    }

    public void MovimientoCuenta(int tipotransaccion, double monto)
    {
        if (tipotransaccion == 1)
        {
            Saldo += (double)monto;
            Movimientos.Add(new Movimiento(DateTime.Now, "Depoosito", monto));
            Console.WriteLine($"Ha depositado Q. {monto} y su saldo es {Saldo}");
        }
        else if (tipotransaccion == 2)
        {
            if (monto >= Saldo)
            {

                Console.WriteLine("❌ no puede retirar mas de lo que tiene de saldo");
                return;
            }
            Saldo -= (double)monto;
            Movimientos.Add(new Movimiento(DateTime.Now, "Retiro", -monto));
            Console.WriteLine($"Ha retirado Q.  {monto} y su saldo es {Saldo}");
        }
        
    }

    public void MostrarMovimientos()
    {
       if (Movimientos.Count == 0)
        {
            Console.WriteLine("No hay movimientos para mostrar.");
            return;
        }
        Console.WriteLine("Fecha\t\t\t\tTipo\tMonto");
        foreach (var movimiento in Movimientos)
        {
            Console.WriteLine($"{movimiento.Fecha}\t{movimiento.Tipo}\t{movimiento.Monto}");
        }
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"Saldo actual: Q. {Saldo}");
        Console.WriteLine("----------------------------------------------------");

    }
}