using Microsoft.EntityFrameworkCore;
using SitecoreAssignmentAPI.Data;
using SitecoreAssignmentAPI.Mappings;
using SitecoreAssignmentAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Added dependency injection for the DbContext classes and also provided connection string for this this DBContext that is WalksConnectionStrign
builder.Services.AddDbContext<WalksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WalksConnectionString")));
builder.Services.AddScoped<IRegionRepository,SQLRegionRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Read about rest full api
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
