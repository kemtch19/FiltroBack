using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// servicio de los controladores
builder.Services.AddControllers();

// servicio de los cors
builder.Services.AddCors(Options=>{
    Options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// servicio de la base de datos
builder.Services.AddDbContext<PracticaFiltroContext>(Options =>
    Options.UseMySql(builder.Configuration.GetConnectionString("FiltroBackDB"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// usamos los cors
app.UseCors("AllowAnyOrigin");
// mapeamos los controladores
app.MapControllers();

app.Run();
