using Practice.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.ConfigureSetUp(builder.Configuration);

var app = builder.Build();
app.UseCors();
app.MigrateDB();
app.MapControllers();

app.Run();
