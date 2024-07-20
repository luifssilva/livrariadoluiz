using LivrariaDoLuiz.Domain.Entity;
using LivrariaDoLuiz.Infra.Data.Mapping;
using LivrariaDoLuiz.Infra.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LivrariaDoLuiz.Infra.Data.Context;

public class LivrariaDoLuizContext : DbContext
{
    private readonly IConfiguration? configuration;
    public LivrariaDoLuizContext(DbContextOptions<LivrariaDoLuizContext> options, IConfiguration Configuration)
    {
        configuration = Configuration;

        ChangeTracker.AutoDetectChangesEnabled = false;
        ChangeTracker.LazyLoadingEnabled = false;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;            
    }    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)            
            optionsBuilder.UseSqlServer(configuration!.GetSection("ConnectionStrings:LivrariaConnection").Value);            
        base.OnConfiguring(optionsBuilder);
    }    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AuthorMapping());
        builder.ApplyConfiguration(new BookMapping());
        builder.ApplyConfiguration(new GenderMapping());
               
        LivrariaSeed.Seed(builder);
        
        base.OnModelCreating(builder);
    }    

    public DbSet<Author> Author  { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Gender> Gender { get; set; }    
}