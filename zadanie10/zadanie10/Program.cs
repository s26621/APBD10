using Microsoft.EntityFrameworkCore;
using zadanie10.Entities;
using zadanie10.Repositories;
using zadanie10.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddTransient<IMedicamentRepository, MedicamentRepository>();
builder.Services.AddTransient<IPatientRepository, PatientRepository>();
builder.Services.AddTransient<IPrescriptionService, PrescriptionService>();

builder.Services.AddDbContext<HospitalDbContext>(opt =>
{
    string connString = builder.Configuration.GetConnectionString("DbConnString");
    opt.UseSqlServer(connString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

// w metodach service, controller i reposotory nie używamy z entities tylko DTO wszystko, nawet jak są te same pola
// testowa strategia - robię DTO tylko kiedy potrzebuję ich do końcówki, na początku są takie same pola, a potem najwyżej usunę te nieużywane?

// przechodzimy przez wszystkie pola na rysunku klasy, tam gdzie FK robimy tamtą akcję
// zaczynamy konfiguracje tam, gdzie jest liczność 1 - FK

// skopiować linq tutorials!

// dotnet jak zainstalować? kolejne kroki

// dotnet ef migrations add Start

// dotnet ef database update

// dotnet ef migrations remove jak nie pyknie i nie jest jeszcze na bazie