using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        //este nombre no indica nada, debe cambiarse
        public static List<string> TaskList { get; set; } //o también ListOfTasks

        static void Main(string[] args)
        {
            TaskList = new List<string>();
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
                    ShowTaskListMenu(); //lo mismo que lo anterior
                }
            } while ((MenuOptions)menuSelected != MenuOptions.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string peticionARealizar = Console.ReadLine();
            return Convert.ToInt32(peticionARealizar);
        }

        public static void ShowRemoveMenu()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowTaskList();

                string removerTarea = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(removerTarea) - 1;
                if (indexToRemove > -1)
                {
                    if (TaskList.Count > 0)
                    {
                        string tareaRemovida = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + tareaRemovida + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
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
            }
        }

        public static void ShowTaskListMenu()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            }
            else
            {
                ShowTaskList();
            }
        }

        private static void ShowTaskList()
        {
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + TaskList[i]);
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
}