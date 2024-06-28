using FiltroBack.Data;
using FiltroBack.Services;
using FiltroBack.Services.Interfaces;
using FiltroBack.Services.Repositories;
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
builder.Services.AddDbContext<FiltroBackContext>(Options =>
    Options.UseMySql(builder.Configuration.GetConnectionString("FiltroBackDB"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

// Creación de los scopes de cada repositorio
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IVetRepository, VetRepository>();
builder.Services.AddScoped<IQuoteRepository, QuoteRepository>();

// Builder para JWT con el token
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(configure =>
{
    configure.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = @Environment.GetEnvironmentVariable("jwtVar"),
        ValidAudience = @Environment.GetEnvironmentVariable("jwtVar"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3C7A6C4E2754B9A31F225E201C02D82E"))
    };
});

// Servicio del Slack API
builder.Services.AddHttpClient();
builder.Services.AddSingleton(sp => new SlackNotifier(sp.GetRequiredService<IHttpClientFactory>().CreateClient(), builder.Configuration["Slack:WebHookURL"]));

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
