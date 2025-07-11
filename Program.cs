using APIRestful.Data;
using APIRestful.Mapper;
using APIRestful.Models.Dto.Category;
using APIRestful.Repository;
using APIRestful.Repository.IRepository;
using APIRestful.Service;
using APIRestful.Service.IService;
using APIRestful.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dependency injection for DB connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

//Dependency injections for repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//Dependency injections for services
builder.Services.AddScoped<ICategoryService, CategoryService>();

//Validators
builder.Services.AddScoped<IValidator<CategoryInsertDto>, CategoryInsertValidator>();
builder.Services.AddScoped<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();

//Mappers
builder.Services.AddAutoMapper(typeof(CategoryMappers));
builder.Services.AddAutoMapper(typeof(MovieMapper));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
