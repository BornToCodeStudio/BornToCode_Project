using DataContext.Postgresql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BornToCodeContext>();

builder.Services.AddCors();
builder.Services.AddControllers().AddNewtonsoftJson();
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

app.UseCors(config =>
{
    if (app.Environment.IsDevelopment())
        config
            .WithOrigins("http://localhost:8000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    else
        config
            .WithOrigins("https://borntocode-api.onrender.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
});

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