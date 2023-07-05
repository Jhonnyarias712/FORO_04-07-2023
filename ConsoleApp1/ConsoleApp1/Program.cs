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
        //agregarEstudiante();
        //consultarEstudiantes();
        //consultarEstudiante();
        //modificarEstudiante();
        //eliminarEstudiante();
        //consultarEstudiantesFunciones();
        //guardarEstudianteYdireccion();
        //guardarEstudianteYdireccionTransaction();
        //consultarDirecciones();
        //consultarDireccion();
        //consultarDireccion2();
        mainmenu();
    }

    private static void mainmenu()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Consultar estudiantes");
            Console.WriteLine("3. Consultar estudiante");
            Console.WriteLine("4. Modificar estudiante");
            Console.WriteLine("5. Eliminar estudiante");
            Console.WriteLine("6. Consultar estudiantes con funciones");
            Console.WriteLine("7. Guardar estudiante y dirección");
            Console.WriteLine("8. Guardar estudiante y dirección con transacción");
            Console.WriteLine("9. Consultar direcciones");
            Console.WriteLine("10. Consultar dirección");
            Console.WriteLine("11. Consultar dirección 2");
            Console.WriteLine("12.[TOMAR ESTA OPCION] Agregar alumno y direccion con validacion");
            Console.WriteLine("0. Salir");
            Console.WriteLine("-----------------");
            Console.Write("Ingrese una opción: ");

            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        agregarEstudiante();
                        break;
                    case 2:
                        consultarEstudiantes();
                        break;
                    case 3:
                        consultarEstudiante();
                        break;
                    case 4:
                        modificarEstudiante();
                        break;
                    case 5:
                        eliminarEstudiante();
                        break;
                    case 6:
                        consultarEstudiantesFunciones();
                        break;
                    case 7:
                        guardarEstudianteYdireccion();
                        break;
                    case 8:
                        guardarEstudianteYdireccionTransaction();
                        break;
                    case 9:
                        consultarDirecciones();
                        break;
                    case 10:
                        consultarDireccion();
                        break;
                    case 11:
                        consultarDireccion2();
                        break;
                    case 12:
                        agregarEstudianteValidado();
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


    public static void guardarEstudianteYdireccion()
    {
        Console.WriteLine("Metodo agregar estudiante y direccion");

        SchoolContext context = new SchoolContext();
        Student std = new Student();
        StudentAddress stdAddress = new StudentAddress();
        
        std.Name = "Ciri";
        context.Students.Add(std);
        context.SaveChanges();

        stdAddress.Address1 = "direccion 1";
        stdAddress.Address2 = "direccion 2";
        stdAddress.StudentID = std.StudentId;
        stdAddress.City = "gye";
        stdAddress.State = "ecu";
        stdAddress.Student= std;
       
        context.StudentAddresses.Add(stdAddress);

        context.SaveChanges();

    }

    public static void guardarEstudianteYdireccionTransaction()
    {
        Console.WriteLine("Metodo agregar estudiante y direccion");

        SchoolContext context = new SchoolContext();
        Student std = new Student();
        StudentAddress stdAddress = new StudentAddress();
        var dbContextTransaction = context.Database.BeginTransaction();
        
        try
        {
            std.Name = "Karina";
            context.Students.Add(std);
            context.SaveChanges();

            stdAddress.Address1 = "direccion 1";
            stdAddress.Address2 = "direccion 2";
            stdAddress.StudentID = std.StudentId;
            stdAddress.City = "gye";
            stdAddress.State = "ecu";

            context.StudentAddresses.Add(stdAddress);

            context.SaveChanges();
            dbContextTransaction.Commit();
            Console.WriteLine("Datos guardados con exito");
        }
        catch (Exception e)
        {
            dbContextTransaction.Rollback();
            Console.WriteLine("Error "+ e.ToString());
        }
       

    }

    public static void consultarDirecciones()
    {
        Console.WriteLine("Consultar direcciones");
        //Console.WriteLine("Metodo consultar estudiante por Id");
        SchoolContext context = new SchoolContext();
        List<StudentAddress> listaDirecciones;
        listaDirecciones = context.StudentAddresses
            .Include(x=> x.Student)
            .ToList();
        
        foreach (var item in listaDirecciones)
        {
            Console.WriteLine("Codigo:"+ item.Student.StudentId +
                " Nombre: " + item.Student.Name + 
                " Direccion:" + item.Address1);
        }
        

    }

    public static void consultarDireccion()
    {
        Console.WriteLine("Consultar direccion por Id");
        //Console.WriteLine("Metodo consultar estudiante por Id");
        SchoolContext context = new SchoolContext();
        StudentAddress address = new StudentAddress();
        address = context.StudentAddresses
            .Where(x =>x.StudentID==16)
            .Include(x => x.Student)
            .ToList()[0];

        
        Console.WriteLine("Codigo: " + address.Student.StudentId +
                " Nombre: " + address.Student.Name +
                " Direccion: " + address.Address1);


    }

    public static void consultarDireccion2()
    {
        Console.WriteLine("Consultar direccion por Id, metodo 2");
        
        SchoolContext context = new SchoolContext();
        StudentAddress address = new StudentAddress();
        address = context.StudentAddresses
            .Single(x => x.StudentID == 1);
           

        context.Entry(address)
            .Reference(x => x.Student)
            .Load();

        /*
        context.Entry(address)
          .Collection(x => x.Student)
          .Load();
        */

        Console.WriteLine("Codigo: " + address.Student.StudentId +
                " Nombre: " + address.Student.Name +
                " Direccion: " + address.Address1);


    }
    //agregar estudiante
    public static void agregarEstudiante()
    {
        Console.WriteLine("Metodo agregar estudiante");
        
        SchoolContext context = new SchoolContext();
        Student std = new Student();
        std.Name = "Pedro";
        context.Students.Add(std);
        context.SaveChanges();
      
        Console.WriteLine("Codigo: "+ std.StudentId + " Nombre: "+ std.Name);

    }

    public static void agregarEstudianteValidado()
    {
        Student std = new Student();
        SchoolContext context = new SchoolContext();
        StudentAddress stdAddress = new StudentAddress();
        var dbContextTransaction = context.Database.BeginTransaction();
        string entrada_nombre = "";
        string direccion1 = "";
        string direccion2 = "";
        string ciudad = "";
        string estado = "";

        Console.WriteLine("Digite su nombre por favor");
        entrada_nombre = Console.ReadLine();

        Console.WriteLine("Digite su Direccion");
        direccion1 = Console.ReadLine();
        Console.WriteLine("Digite otra Direccion ");
        direccion2 = Console.ReadLine();
        Console.WriteLine("Digite su CIUDAD");
        ciudad = Console.ReadLine();
        Console.WriteLine("Digite su ESTADO");
        estado = Console.ReadLine();
        
        try
        {
        std.Name = entrada_nombre;
        context.Students.Add(std);
        context.SaveChanges();
        stdAddress.Address1 = direccion1;
        stdAddress.Address2 = direccion2;
        stdAddress.StudentID = std.StudentId;
        stdAddress.City = ciudad;
        stdAddress.State = estado;

        context.StudentAddresses.Add(stdAddress);
        context.SaveChanges();

            if (string.IsNullOrEmpty(entrada_nombre) || string.IsNullOrEmpty(direccion1) || string.IsNullOrEmpty(direccion2) || string.IsNullOrEmpty(ciudad) || string.IsNullOrEmpty(estado))
            {
                Console.WriteLine("Ha ingresado uno o más campos vacíos. Por favor, complete todos los campos.");
                dbContextTransaction.Rollback();
            }
            else {
                dbContextTransaction.Commit();
                Console.WriteLine("Datos guardados con exito");
            }

        }
        catch (Exception e)
        {
            dbContextTransaction.Rollback();
            Console.WriteLine("Error " + e.ToString());
        }
        /*
         try
        {
        SchoolContext context = new SchoolContext();
        Student std = new Student();
        StudentAddress stdAddress = new StudentAddress();
        var dbContextTransaction = context.Database.BeginTransaction();

            std.Name = "Karina";
            context.Students.Add(std);
            context.SaveChanges();

            stdAddress.Address1 = "direccion 1";
            stdAddress.Address2 = "direccion 2";
            stdAddress.StudentID = std.StudentId;
            stdAddress.City = "gye";
            stdAddress.State = "ecu";

            context.StudentAddresses.Add(stdAddress);

            context.SaveChanges();
            dbContextTransaction.Commit();
            Console.WriteLine("Datos guardados con exito");
        }
        catch (Exception e)
        {
            dbContextTransaction.Rollback();
            Console.WriteLine("Error "+ e.ToString());
        }*/

    }
    public static void consultarEstudiantes()
    {
        Console.WriteLine("Metodo consultar estudiantes");
        SchoolContext context = new SchoolContext();
        List<Student> listEstudiantes= context.Students.ToList() ;

        foreach (var item in listEstudiantes)
        {
            Console.WriteLine("Codigo: " + item.StudentId + " Nombre: " + item.Name);
        }
        
    }

    public static void consultarEstudiante()
    {
        Console.WriteLine("Metodo consultar estudiante por Id");
        SchoolContext context = new SchoolContext();
        Student std = new Student();
        std = context.Students.Find(11);

       Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);
      
    }

    public static void modificarEstudiante()
    {
        Console.WriteLine("Metodo modificar estudiante");
        SchoolContext context = new SchoolContext();
        Student std = new Student();
        std = context.Students.Find(1);

        std.Name = "Anahi";
        context.SaveChanges();
        Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);

    }

    public static void eliminarEstudiante()
    {
        Console.WriteLine("Metodo eliminar estudiante");
        SchoolContext context = new SchoolContext();
        Student std = new Student();
        std = context.Students.Find(5);
        context.Remove(std);
        context.SaveChanges();
        Console.WriteLine("Codigo: " + std.StudentId + " Nombre: " + std.Name);

    }
    public static void consultarEstudiantesFunciones()
    {
        Console.WriteLine("Metodo consultar estudiantes con el uso de funciones");
        SchoolContext context = new SchoolContext();
        List<Student> listEstudiantes;

        Console.WriteLine("Cantidad de registros: " + context.Students.Count());
        Student std = context.Students.First();

        Console.WriteLine("Primer elemento de la tabla:" +  std.StudentId +"-" +std.Name);

        //listEstudiantes = context.Students.Where(s => s.StudentId > 2 && s.Name == "Anita").ToList();

        //listEstudiantes = context.Students.Where(s => s.Name == "Patty" || s.Name == "Anita").ToList();

        listEstudiantes = context.Students.Where(s => s.Name.StartsWith("A")).ToList();

        foreach (var item in listEstudiantes)
        {
            Console.WriteLine("Codigo: " + item.StudentId + " Nombre: " + item.Name);
        }


        /*
        var query = context.Students.GroupBy( s => s.Name) 
        .Select(g => new
        {
            Nombre = g.Key,
            Cantidad = g.Count()
        }). ToList();

        foreach (var result in query)
        {
            Console.WriteLine($"Nombre: {result.Nombre}, Cantidad: {result.Cantidad}");
        }
        */





    }
}