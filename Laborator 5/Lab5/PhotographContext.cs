namespace Lab5
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographContext : DbContext
    {
        // Your context has been configured to use a 'PhotographContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Lab5.PhotographContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PhotographContext' 
        // connection string in the application configuration file.
        public PhotographContext()
            : base("name=PhotographContext")
        {
        }

        public virtual DbSet<Photograph> Photographs { get; set; }
        public virtual DbSet<PhotographFullImage> PhotographFullImages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Photograph>()
                .HasRequired(p => p.PhotographFullImage)
                .WithRequiredPrincipal(p => p.Photograph); 
            modelBuilder.Entity<Photograph>()
                .ToTable("Photograph", "BazaDeDate"); 
            modelBuilder.Entity<PhotographFullImage>()
                .ToTable("Photograph", "BazaDeDate"); }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}