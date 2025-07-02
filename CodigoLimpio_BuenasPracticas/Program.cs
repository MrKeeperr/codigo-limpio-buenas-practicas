using System;
using System.Collections.Generic;

namespace ToDo; //no es necesario encerrar el codigo entero con el namespace

internal class Program
{
    public static List<string> TaskList { get; set; } = new List<string>();

    static void Main(string[] args)
    {
        int menuSelected = 0; //el nombre variable no indica nada
        do
        {
            menuSelected = ShowMainMenu();
            if ((MenuOptions)menuSelected == MenuOptions.AddTask)
            {
                ShowMenuAdd();
            }
            else if ((MenuOptions)menuSelected == MenuOptions.RemoveTask)
            {
                ShowRemoveMenu(); //showmenudos tampoco indica nada, tocaba leer el metodo para saber que hacía
            }
            else if ((MenuOptions)menuSelected == MenuOptions.ShowTasks)
            {
                ShowTaskList(); //lo mismo que lo anterior
            }
        } while ((MenuOptions)menuSelected != MenuOptions.Exit);
    }

    public static int ShowMainMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ingrese la opción a realizar: ");
        Console.WriteLine("1. Nueva tarea");
        Console.WriteLine("2. Remover tarea");
        Console.WriteLine("3. Tareas pendientes");
        Console.WriteLine("4. Salir");

        string peticionARealizar = Console.ReadLine();
        return Convert.ToInt32(peticionARealizar);
    }

    public static void ShowRemoveMenu()
    {
        try
        {
            Console.WriteLine("Ingrese el número de la tarea a remover: ");

            ShowTaskList();

            int indexToRemove = Convert.ToInt32(Console.ReadLine()) - 1;
            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                TaskList.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {TaskList[indexToRemove]} eliminada");
            }
            else if (indexToRemove > TaskList.Count - 1 || indexToRemove < 0)
            {
                Console.WriteLine("Tarea no encontrada");
            }
        }
        //puedes añadir la declaracion ex para mandar un mensaje al programador
        catch (Exception)
        {
            Console.WriteLine("Ha ocurrido un error al eliminar la tarea.");

        }
    }

    public static void ShowMenuAdd()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre de la tarea: ");
            string nombreTarea = Console.ReadLine();
            TaskList.Add(nombreTarea);
            Console.WriteLine("Tarea registrada");
        }
        catch (Exception)
        {
            Console.WriteLine("Ha ocurrido un error al registrar la tarea.");
        }
    }

    public static void ShowTaskList()
    {
        if (TaskList?.Count > 0) //operador null, el signo de pregunta verifica si es null o no, supongo que en caso de ser nulo entra en el else
        {
            Console.WriteLine("----------------------------------------");
            var indexTask = 1;
            //dentro del foreach utiliza una expresion lambda
            TaskList.ForEach(task => Console.WriteLine($"{indexTask++}. {task}"));
            Console.WriteLine("----------------------------------------");
        }
        else
        {
            Console.WriteLine("No hay tareas por realizar");
        }
    }
}

// Es recomendable utilizar enums para evitar los magic numbers
public enum MenuOptions
{
    AddTask = 1,
    RemoveTask = 2,
    ShowTasks = 3,
    Exit = 4
}
