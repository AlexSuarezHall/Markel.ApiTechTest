using Markel.Data;
using Markel.Repositories;
using Markel.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IClaimRepository, ClaimRepository>();
builder.Services.AddControllers();

var inMemoryOptions = new DbContextOptionsBuilder<MarkelContext>()
    .UseInMemoryDatabase("MarkelContext")
    .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
    .Options;

builder.Services.AddDbContext<MarkelContext>(options =>
    options.UseInMemoryDatabase("MarkelContext")
    .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MarkelContext>();
    MarkelSeedData.MarkelSeed(context);
}

app.Run();

