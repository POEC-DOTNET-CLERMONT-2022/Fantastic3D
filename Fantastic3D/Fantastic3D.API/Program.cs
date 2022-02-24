using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;
using Fantastic3D.Persistence;
using Fantastic3D.DataManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(IDataManager<,>), typeof(DbDataManager<,>));
builder.Services.AddScoped(typeof(INestedDataManager<>), typeof(DbNestedDataManager<>));
builder.Services.AddScoped<DbContext, LocalDbContext>();
#if DEBUG
string _connexionStringContext = "DefaultContext";
#else
string _connexionStringContext = "DockerContext";
#endif
builder.Services.AddDbContextFactory<LocalDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString(_connexionStringContext)));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<LocalDbContext>();

    context.Database.EnsureCreated();
    DataSeeder.PopulateData(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();