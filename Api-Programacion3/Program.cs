using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using static Infrastructure.Services.AuthenticateService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("Api-Programacion3BearerAuth", new OpenApiSecurityScheme() 
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Ingresar aqui el token."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Api-Programacion3BearerAuth" }
                }, new List<string>() }
    });
});

//repositories
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//services
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService,  ProductService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.Configure<AuthenticateServiceOptions>(
    builder.Configuration.GetSection(AuthenticateServiceOptions.AuthenticateService));
builder.Services.AddScoped<ICustomAuthenticationService, AuthenticateService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(
builder.Configuration["ConnectionStrings:MayoristaDBConnectionString"], b => b.MigrationsAssembly("Api-Programacion3")));

builder.Services.AddAuthentication("Bearer") 
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["AuthenticateService:Issuer"],
            ValidAudience = builder.Configuration["AuthenticateService:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AuthenticateService:SecretForKey"]))
        };
    }
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
