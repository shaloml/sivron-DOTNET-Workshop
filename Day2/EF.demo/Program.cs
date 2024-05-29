using EF.demo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();
//services.AddDbContext<SamuraiDbContext>();
services.AddDbContext<SamuraiDbContext>(options =>
                    options.UseSqlite("Data Source=c:\\temp\\Samurai.db"));


var serviceProvider = services.BuildServiceProvider();

using (var context = serviceProvider.GetService<SamuraiDbContext>())
{
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();
    context.Database.Migrate();
    AddSampleData(context);
}

void AddSampleData(SamuraiDbContext context)
{
    context.Samurais.Add(new EF.demo.Model.Samurai
    {
        Name = "Shalom",
        Quotes = new List<EF.demo.Model.Quote> {
                                   new EF.demo.Model.Quote{Text="yes"},
                                    new EF.demo.Model.Quote{Text= "no"}
                        }
    });
    context.SaveChanges();
}

