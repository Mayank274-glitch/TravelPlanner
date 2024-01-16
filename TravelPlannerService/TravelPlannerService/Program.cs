using Microsoft.EntityFrameworkCore;
using TravelPlannerService;
using TravelPlannerService.DbContextCreate;
using TravelPlannerService.Repository;
using TravelPlannerService.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Repositories
builder.Services.AddScoped<IItineraryRepository, ItineraryRepository>();
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();

// Configure Services
builder.Services.AddScoped<IItineraryService, ItineraryService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<INoteService, NoteService>();

// Enable CORS (adjust as needed)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Use the configuration and services from Startup class
var startup = new Startup(builder.Configuration);

// Configure the HTTP request pipeline.
//if (builder.Environment.IsDevelopment())
//{
//    startup.Configure(app,app.Environment);
//}

// Use additional middleware or configuration as needed

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRequestLocalization();

if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Itenary service");
    });
}


app.Run();
