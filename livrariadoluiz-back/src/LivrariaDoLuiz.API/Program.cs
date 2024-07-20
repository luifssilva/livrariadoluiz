using LivrariaDoLuiz.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder
    .Services.AddApiVersioning(option =>{
        option.ReportApiVersions = true;
    });
    
builder.Services.AddSwaggerConfiguration();


builder.Services.AddCors(options =>
    options.AddPolicy(name: "AllowAll", p =>
        p.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod()
    ));

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddDependecyInjectionConfiguration();
builder.Services.AddAutoMapperConfigurations();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var db = new LivrariaDoLuizMigration())
await db.RunMigrations(app);

app.Run();

