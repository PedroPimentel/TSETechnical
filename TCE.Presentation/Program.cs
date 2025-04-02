using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TCE.Application.Mappings;
using TCE.Application.Queries.ClienteQueries;
using TCE.Application.Validators;
using TCE.Domain.Core.IRepository;
using TCE.Infrastructure.Data;
using TCE.Infrastructure.Repositories;
using TCE.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<TCEDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(typeof(GetClientesQueryHandler).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<CompraCommandValidator>();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
