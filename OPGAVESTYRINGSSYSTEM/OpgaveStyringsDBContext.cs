using Microsoft.EntityFrameworkCore;
using OPGAVESTYRINGSSYSTEM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPGAVESTYRINGSSYSTEM
{
    public class OpgaveStyringsDBContext : DbContext
    {
        public DbSet<Model.Task> Tasks { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<TeamWorker> TeamWorkers { get; set; }

        public string DbPath { get; }

        public OpgaveStyringsDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "OpgaveStyringsDatabase.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamWorker>().HasKey(p => new { p.WorkerId, p.TeamId });
            modelBuilder.Entity<Team>().HasOne(x => x.CurrentTask);
            modelBuilder.Entity<Worker>().HasOne(x => x.CurrentTodo);
        }
    }
}