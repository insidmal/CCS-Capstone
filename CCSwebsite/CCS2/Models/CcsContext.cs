using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CCS2.Models
{
    public class CcsContext : DbContext
    {
        public CcsContext() :
            base("CyberSolutionsDB") { }

        public DbSet<UserProfile> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ProgressReport> Reports { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Bill> Bills { get; set; }
    }
}