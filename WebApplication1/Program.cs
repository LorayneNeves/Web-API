using Application.AutoMapper;
using Application.Interfaces;
using Application.Services;
using Data.AutoMapper;
using Data.Providers.MongoDb.Configuration;
using Data.Providers.MongoDb.Interfaces;
using Data.Providers.MongoDb;
using Data.Repository;
using Domain.Interface;
using Microsoft.Extensions.Options;
using Infra.EmailService;
using MongoDB.Driver;
using Infra;
using Infra.Autenticacao.Models;
using Google.Apis.Discovery;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor inclua o token no campo valor:",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[]{}
    }
    }); c.AddSecurityRequirement(new OpenApiSecurityRequirement{
    {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                 Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

    builder.Services.Configure<MongoDbSettings>(
        builder.Configuration.GetSection("MongoDbSettings"));

    builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
           serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

    builder.Services.AddAutoMapper(typeof(DomainToApplication), typeof(ApplicationToDomain));
    builder.Services.AddAutoMapper(typeof(DomainToCollection), typeof(CollectionToDomain));

    builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

    builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
    builder.Services.AddScoped<IProdutoService, ProdutoService>();

    builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
    builder.Services.AddScoped<ICategoriaService, CategoriaService>();

    builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
    builder.Services.AddScoped<IFornecedorService, FornecedorService>();


    builder.Services.Configure<Token>(
        builder.Configuration.GetSection("token"));


    builder.Services.AddScoped<ITokenService, TokenService>();

    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    builder.Services.AddScoped<IUsuarioService, UsuarioService>();

    builder.Services.Configure<EmailConfig>(
        builder.Configuration.GetSection("EmailConfig"));

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
