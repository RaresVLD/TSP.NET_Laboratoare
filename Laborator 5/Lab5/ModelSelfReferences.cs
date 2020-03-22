namespace Lab5
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelSelfReferences : DbContext
    {

        public ModelSelfReferences()
            : base("name=ModelSelfReferences")
        {
        }

        public virtual DbSet<SelfReference> SelfReferences { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<SelfReference>()
                .HasMany(m => m.References)
                .WithOptional(m => m.ParentSelfReference);
        }

    }

}