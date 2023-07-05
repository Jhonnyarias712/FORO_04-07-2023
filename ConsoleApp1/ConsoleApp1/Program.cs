using ConsoleApp1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        mainmenu();
    }

    private static void mainmenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("***********_MENU_***********");
            Console.WriteLine("1.Agregar AUTO");
            Console.WriteLine("0. Salir");
            Console.WriteLine("-----------------");
            Console.Write("Ingrese una opción: ");

            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        agregarAuto();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción inválida. Intente nuevamente.");
            }

            Console.WriteLine();
        }
    }

    private static void agregarAuto()
    {

        Auto aut = new Auto();
        Propietario pro = new Propietario();
        Color col = new Color();

        SchoolContext context = new SchoolContext();
        var dbContextTransaction = context.Database.BeginTransaction();
        string Modelo = "";
        string ano = "";

        string Nombre = "";
        string Apellido = "";
        string edad = "";

        string color = "";

        Console.WriteLine("Ingrese el modelo del auto:");
        Modelo = Console.ReadLine();

        Console.WriteLine("Ingrese el año del auto:");
        ano = Console.ReadLine();

        Console.WriteLine("Ingrese el nombre del propietario:");
        Nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el apellido del propietario:");
        Apellido = Console.ReadLine();

        Console.WriteLine("Ingrese la edad del propietario:");
        edad = Console.ReadLine();

        Console.WriteLine("Ingrese el color del auto:");
        color = Console.ReadLine();

        // Asignar los valores a las instancias de las clases
        try { 
        
        
        col.Nombre = color;
        context.colores.Add(col);
        context.SaveChanges();

        pro.Nombre = Nombre;
        pro.Apellido = Apellido;
        pro.Edad = Convert.ToInt32(edad);
        context.propietarios.Add(pro);
        context.SaveChanges();

        aut.Modelo = Modelo;
        aut.Ano = Convert.ToInt32(ano);
        aut.colorid = col;
        aut.propietarioid = pro;
         // Guardar en la base de datos
         context.autos.Add(aut);
         context.SaveChanges();

            if (string.IsNullOrEmpty(Modelo) || string.IsNullOrEmpty(ano) || string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido) || string.IsNullOrEmpty(edad) || string.IsNullOrEmpty(color))
        {
            Console.WriteLine("Ha ingresado uno o más campos vacíos. Por favor, complete todos los campos.");
            dbContextTransaction.Rollback();
        }
        else
        {
            dbContextTransaction.Commit();
            Console.WriteLine("Datos guardados con éxito");
        }
    }
    catch (Exception e)
    {
        dbContextTransaction.Rollback();
        Console.WriteLine("Error: " + e.ToString());

    }
    }       
}