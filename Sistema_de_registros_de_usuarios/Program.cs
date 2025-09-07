using Sistema_de_registros_de_usuarios.DAO;
using Sistema_de_registros_de_usuarios.DataBase;
using Sistema_de_registros_de_usuarios.Models;
using Sistema_de_registros_de_usuarios.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_registros_de_usuarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (DbConnection.Instance.GetConnection()) { }
            } catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

                Menu();

        }

        public static void Menu()
        {
   
            int OptionSelected = 0;
            Console.WriteLine("Seleccioná una opción");

            while (OptionSelected != 6)
            {
                Console.WriteLine("1. Agregar usuario");
                Console.WriteLine("2. Listar usuarios");
                Console.WriteLine("3. Eliminar usuario");
                Console.WriteLine("4. Fichar ingreso");
                Console.WriteLine("5. Fichar Egreso");
                Console.WriteLine("6. Salir");
                Console.WriteLine("\n\n########## SOFTWARE DE GESTION DE ENTRADA Y SALIDA DE USUARIOS ##########");
                Console.WriteLine("#                                                                       #");
                Console.WriteLine("#                       By Leonel Carro                                 #");
                Console.WriteLine("#                                                                       #");
                Console.WriteLine("#########################################################################");

                try
                {
                    OptionSelected = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    OptionSelected = 4;
                }

                switch (OptionSelected)
                {
                    case 1:
                        Console.Clear();
                        AddUser();
                        break;
                    case 2:
                        Console.Clear();
                        PrintUsers();
                        break;
                    case 3:
                        Console.Clear();
                        DeleteUser();
                        break;
                    case 4:
                        Console.Clear();
                        EntryUser();
                        break;
                    case 5:
                        Console.Clear();
                        ExitUser();
                        break;
                    case 6:
                        Console.WriteLine("Programa Cerrado...");
                        break;
                    default: break;


                }
            }
        }

        public static void AddUser()
        {
            Console.WriteLine("Ingrese el nombre: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Ingrese su edad: ");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el codigo del usuario: ");
            string CodeUser = Console.ReadLine();

            UserDao userDao = new UserDao();
            UserService userService = new UserService(userDao);

            User user = new User()
            {
                Name = Name,
                Age = Age,
                CodeUser = CodeUser
            };

            userService.AddUserService(user);

            Console.Clear();
            Console.WriteLine("Usuario registrado");
        }
        
        public static void PrintUsers()
        {
            UserDao userDao = new UserDao();
            UserService userService = new UserService(userDao);

            List<User> users = userService.GetUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"##### Codigo de usuario: {user.Id} ######");
                Console.WriteLine($"Nombre: {user.Name}");
                Console.WriteLine($"Edad: {user.Age}");
                Console.WriteLine("################################################");
            }
        }

        public static void DeleteUser()
        {
            Console.WriteLine("Ingrese el Codigo de Usuario que quiere eliminar: ");
            UserDao userDao = new UserDao();
            UserService userService = new UserService(userDao);
            int id = int.Parse(Console.ReadLine());
            int AffectedRows = userService.DeleteUser(id);
            if (AffectedRows == 1) Console.WriteLine("Usuario eliminado.");
            if (AffectedRows == 0) Console.WriteLine("Usuario no encontrado.");
        }
        
        public static void EntryUser()
        {
            Console.WriteLine("Ingrese el identificador del usuario");
            int userId = int.Parse(Console.ReadLine());
            ScheduleDao scheduleDao = new ScheduleDao();
            ScheduleService scheduleService = new ScheduleService(scheduleDao);
            Schedule schedule = new Schedule()
            {
                EntryTime = DateTime.Now,
                UserId = userId
            };
            scheduleService.EntryDataTime(schedule);
            Console.WriteLine("Entrada de usuario registrada...");
        }

        public static void ExitUser()
        {
            Console.WriteLine("Ingrese el identificador del usuario");
            int userId = int.Parse(Console.ReadLine());
            ScheduleDao scheduleDao = new ScheduleDao();
            ScheduleService scheduleService = new ScheduleService(scheduleDao);
            Schedule schedule = new Schedule()
            {
                ExitTime = DateTime.Now,
                UserId = userId
            };
            scheduleService.EntryDataTime(schedule);
            Console.WriteLine("Salida de usuario registrada...");
        }

    }
}
