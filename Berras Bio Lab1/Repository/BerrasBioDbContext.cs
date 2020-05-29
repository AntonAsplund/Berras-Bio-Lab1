
using Berras_Bio_Lab1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Berras_Bio_Lab1.Repository
{
    public class BerrasBioDbContext : DbContext
    {
        public BerrasBioDbContext(DbContextOptions<BerrasBioDbContext> options) : base(options)
        { 
        
        }

        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<TheaterModel> Theaters { get; set; }
        public DbSet<ViewingModel> Viewings { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-6MGRJ4I\SQLEXPRESS02;Initial Catalog=BerrasBio;Integrated Security=True;");
        //}

    }
}