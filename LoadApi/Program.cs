using LoadBusiness;
using LoadBusiness.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IDelayBusiness, DelayBusiness>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();