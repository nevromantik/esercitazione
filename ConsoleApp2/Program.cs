﻿using System;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    static void Main()
    {
        Task task1 = new Task(1, "giocare", false, true);
        Task task2 = new Task(2, "studiare", false, false);
        Task task3 = new Task(3, "lavorare", false, true);
        List<Task> tasks = new List<Task>();
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
        int userChoice;
        mainMenu: 
        Console.WriteLine(":: DASHBOARD MAIN MENU :: \n" +
               "Seleziona la voce desiderata \n" +
               "1. Visualizza tutti i tasks \n" +
               "2. Aggiungi nuovi task \n" +
               "3. Visualizza gli urgenti \n" +
               "4. Modifica un task \n" +
               "5. Visualizza i completati \n" 
              );
        do
        {
           

            userChoice = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (userChoice)
            {
                case 1:
                    showAll();
                    goToSection("0", "tornare al menu principale");
                    if(userChoice == 0)
                    {
                        Console.Clear();

                        goto mainMenu;

                    }


                    break;
                case 2:
                    addNewTask();
                    if (userChoice == 0)
                    {
                        Console.Clear();

                        goto mainMenu;
                    }
                    break;

                case 3:
                    showUrgent();
                    if (userChoice == 0)
                    {
                        Console.Clear();

                        goto mainMenu;
                    }
                    break;
                case 4:
                    updateTask();
                    if (userChoice == 0)
                    {
                        Console.Clear();

                        goto mainMenu;
                    }
                    break;
                case > 4 :
                    Console.WriteLine("Comando inserito non valido");
                    goToSection("0", "tornare al menu principale");
                    if (userChoice == 0)
                    {
                        Console.Clear();

                        goto mainMenu;
                    }
                    break;

                case < 0:
                    Console.WriteLine("Comando inserito non valido");
                    goToSection("0", "tornare al menu principale");
                    if (userChoice == 0)
                    {
                        Console.Clear();

                        goto mainMenu;
                    }
                    break;
                
            }
        } while (userChoice != 0);


        Console.ReadKey();


         void showAll()
        {
            foreach (Task task in tasks)
            {
                Console.WriteLine($" ID: {task.Id} NAME: { task.Name} PRIORITY: {task.Urgent}  STATE: {task.Completed}");
            }
        }

        void goToSection(string userChoiceInput, string section)
        {
            Console.WriteLine($"Digita {userChoiceInput} per {section}");
            userChoice = int.Parse(Console.ReadLine());
        }
        
        void addNewTask()
        {

            do
            {

                int suggestedID = tasks[tasks.Count - 1].Id;
                int convertedID = suggestedID + 1;

                Console.WriteLine("Inserisci Nome task:");

                string name = Console.ReadLine();

                Console.WriteLine("Inserisci true se è urgente, false se non è urgente:");

                bool isUrgent = bool.Parse(Console.ReadLine());

                Task newTask = new Task(convertedID, name, false, isUrgent); 

                tasks.Add(newTask);

                
                Console.WriteLine("Digita 2 per aggiungere un nuovo task oppure");
                goToSection("0", "tornare al menu principale");

            } while (userChoice != 0);
        }

        void showUrgent()
        {
            Console.WriteLine(":: Task urgenti :: ");
            List<Task> urgentTasks = tasks.FindAll(urgent => urgent.Urgent == true);
            foreach(Task task in urgentTasks)
            {
                Console.WriteLine(task.Name);
            }
            goToSection("0", "tornare al menu principale");

        }

        void updateTask()
        {
            Console.WriteLine("::MODIFICA TASK::");
            Console.WriteLine("Inserisci l'id del task che vuoi modificare: ");
            int selectedTaskId = int.Parse(Console.ReadLine());
            Task selectedTask = tasks.Find(task => task.Id == selectedTaskId);
            Console.Clear();
            Console.WriteLine($"Titolo task: {selectedTask.Name} \n" +
                $" Priorità: {(selectedTask.Urgent == false ? "Non urgente" : "Urgente")} \n" +
                $" Completato: {(selectedTask.Completed == false ? "Non completato" : "Completato")} \n" );
            Console.WriteLine("Inserisci il nuovo titolo: ");
            string newTitle = Console.ReadLine();
            selectedTask.Name = newTitle;

            Console.WriteLine("Cambia la priorità: ");
            bool isUrgent = bool.Parse(Console.ReadLine());
            selectedTask.Urgent = isUrgent;

            Console.WriteLine("Cambia lo stato: ");
            bool isCompleted = bool.Parse(Console.ReadLine());
            selectedTask.Completed = isUrgent;


            goToSection("0", "tornare al menu principale");

        }


    }

 


    public class Task
    {
        int taskID;
        string taskNAME;
        bool isCompleted = false;
        bool isUrgent;



        public Task(int taskID, string taskNAME, bool isCompleted, bool isUrgent)
        {
            this.taskID = taskID;
            this.taskNAME = taskNAME;
            this.isCompleted = isCompleted;
            this.isUrgent = isUrgent; 
        }

        public string Name
        {
            get { return this.taskNAME; }
            set { taskNAME = value; }
        }

        public int Id
        {
            get { return this.taskID; }
            set { taskID = value; }
        }

        public bool Completed 
        {
            get { return this.isCompleted; }
            set { this.isCompleted = value; }
        }

        public bool Urgent
        {
            get { return this.isUrgent; }
            set
            {
                try
                {
                    this.isUrgent = (bool)value; 
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Errore! :-(   Il valore inserito deve essere true o false!  "); 
                }
            }
        }




    }
}