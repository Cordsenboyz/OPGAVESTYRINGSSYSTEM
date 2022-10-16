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
            PrintTeamsWithTasks();
            break;

        case 4:
            PrintTeamProgress();
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
            task.Name = "Design Website";
            task.Todos.Add(new Todo("Write Css", false));
            task.Todos.Add(new Todo("Write Javascript", false));
            task.Todos.Add(new Todo("Draw the design", false));
            context.Tasks.Add(task);
            task = new();
            task.Name = "Design API";
            task.Todos.Add(new Todo("Write endpoints", false));
            task.Todos.Add(new Todo("Write dokumentation", false));
            task.Todos.Add(new Todo("Write sercurity", false));
            context.Tasks.Add(task);
            task = new();
            task.Todos.Add(new Todo("Test methods", false));
            task.Todos.Add(new Todo("Write Bugs/questions", false));
            task.Todos.Add(new Todo("Test buttons", false));
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
static void AddTasksAndTodos()
{
    using (OpgaveStyringsDBContext context = new())
    {
        Team frontend = context.Teams.First(x => x.TeamId == 1);
        Task frontendTask = context.Tasks.First(x => x.TaskId == 1);
        frontend.Tasks.Add(frontendTask);
        frontend.CurrentTask = frontendTask;
        context.Update(frontend);
        Team backend = context.Teams.First(x => x.TeamId == 2);
        Task backendTask = context.Tasks.First(x => x.TaskId == 2);
        backend.Tasks.Add(backendTask);
        backend.CurrentTask = backendTask;
        context.Update(backend);
        Team testere = context.Teams.First(x => x.TeamId == 3);
        Task testereTask = context.Tasks.First(x => x.TaskId == 3);
        testere.Tasks.Add(testereTask);
        testere.CurrentTask = testereTask;
        context.Update(testere);
        context.SaveChanges();
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
static void PrintTeamsWithoutTasks()
{
    using (OpgaveStyringsDBContext context = new())
    {
        List<Team> teams = context.Teams.Include(x => x.Tasks).Where(x => x.Tasks.Any(x => x.TaskId == null)).ToList();
        foreach (var team in teams)
        {
            Console.WriteLine($"Teams: {team.Name}");
        }
    }
}
static void PrintTeamsWithTasks()
{
    using (OpgaveStyringsDBContext context = new())
    {
        var Result = context.Teams.Include(x => x.CurrentTask).Where(x => x.CurrentTask != null);
        foreach (var teams in Result)
        {
            Console.WriteLine($"Team Name: {teams.Name}, Task: {teams.CurrentTask.Name}");
        }
    }
}
static void PrintTeamProgress()
{
    using (OpgaveStyringsDBContext context = new())
    {
        var Result = context.Teams.Include(x => x.CurrentTask.Todos);
        int Completed = 0;
        int TodosCount = 0;
        foreach (var team in Result)
        {
            TodosCount += team.CurrentTask.Todos.Count;
            foreach (var todo in team.CurrentTask.Todos)
            {
                if (team.CurrentTask.Todos.Any(x => x.IsComplete == true))
                {
                    Completed++;
                }
            }
            int percentComplete = (int)Math.Round((double)(100 * Completed) / TodosCount);
            Console.WriteLine($"Team Name: {team.Name}. Percentage of completed todos: {percentComplete}%");
        }
    }
}