// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using OPGAVESTYRINGSSYSTEM;
using OPGAVESTYRINGSSYSTEM.Model;
using System;
using System.Collections.Generic;
using System.Linq;

Menu();

static void Menu()
{
    Console.WriteLine("1: SeedTasks");
    Console.WriteLine("2: ListItems");
    var input = Convert.ToInt32(Console.ReadLine());
    switch (input)
    {
        case 1:
            SeedTasks();
            break;

        case 2:
            ListItems();
            break;

        case 3:
            PrintIncompleteTasksandTodos();
            break;

        case 4:
            SeedWorkers();
            break;
    }
}
static void SeedTasks()
{
    using (OpgaveStyringsDBContext context = new())
    {
        try
        {
            Task task = new();
            task.Name = "Produce Softwave";
            task.Todos.Add(new Todo("Write code", false));
            task.Todos.Add(new Todo("Compile source", false));
            task.Todos.Add(new Todo("Test program", false));
            context.Tasks.Add(task);
            task = new();
            task.Name = "Brew coffee";
            task.Todos.Add(new Todo("Pour water", false));
            task.Todos.Add(new Todo("Pour coffee", false));
            task.Todos.Add(new Todo("Turn on", false));
            context.Tasks.Add(task);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
static void SeedWorkers()
{
    using (OpgaveStyringsDBContext context = new())
    {
        try
        {
            Team frontend = new Team("frontend");
            Team backend = new Team("Backend");
            Team testere = new Team("Testere");
            context.TeamWorkers.Add(new TeamWorker
            {
                Team = frontend,
                Worker = new Worker { Name = "Steen Secher" },
            });
            context.TeamWorkers.Add(new TeamWorker
            {
                Team = frontend,
                Worker = new Worker { Name = "Ejvind Møller" },
            });
            context.TeamWorkers.Add(new TeamWorker
            {
                Team = frontend,
                Worker = new Worker { Name = "Konrad Sommer" },
            });
            context.TeamWorkers.Add(new TeamWorker
            {
                Team = backend,
                Worker = new Worker { Name = "Konrad Sommer" },
            });
            context.TeamWorkers.Add(new TeamWorker
            {
                Team = backend,
                Worker = new Worker { Name = "Sofus Lotus" },
            });
            context.TeamWorkers.Add(new TeamWorker
            {
                Team = backend,
                Worker = new Worker { Name = "Remo Lademann" },
            });
            context.TeamWorkers.Add(new TeamWorker
            {
                Team = testere,
                Worker = new Worker { Name = "Ella Fanth" },
            });
            context.TeamWorkers.Add(new TeamWorker
            {
                Team = testere,
                Worker = new Worker { Name = "Anne Dam" },
            });
            context.TeamWorkers.Add(new TeamWorker
            {
                Team = testere,
                Worker = new Worker { Name = "Steen Secher" },
            });
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
static void ListItems()
{
    using (OpgaveStyringsDBContext context = new())
    {
        var tasks = context.Tasks.Include(task => task.Todos);
        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.Name}");
            foreach (var todo in task.Todos)
            {
                Console.WriteLine($"- {todo.Name}");
            }
        }
    }
    Console.ReadKey();
}
static void PrintIncompleteTasksandTodos()
{
    using (OpgaveStyringsDBContext context = new())
    {
        var tasks = context.Tasks.Include(task => task.Todos).Where(x => x.Todos.Any(x => x.IsComplete == false));
        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.Name}");
            foreach (var todo in task.Todos)
            {
                Console.WriteLine($"- {todo.Name}");
            }
        }
    }
}