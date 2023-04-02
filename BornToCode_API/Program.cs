var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSpaStaticFiles(config => config.RootPath = "dist");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(config => config
    .WithOrigins("http://localhost:*")
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseRouting();
app.UseAuthorization();
// app.UseHttpsRedirection(); //  Disable if frontend have CORS issues
app.MapControllers();

app.UseSpaStaticFiles();
app.UseSpa(config =>
{
    if (app.Environment.IsDevelopment())
        config.UseProxyToSpaDevelopmentServer("http://localhost:3000/");
});

app.Run();