using Microsoft.EntityFrameworkCore;
using VentasApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VentasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

var app = builder.Build();



    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
// 👉 Habilitar archivos estáticos (sirve wwwroot)
app.UseStaticFiles();
app.MapControllers();
app.Run();
