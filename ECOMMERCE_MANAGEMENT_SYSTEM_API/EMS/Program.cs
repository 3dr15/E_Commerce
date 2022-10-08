using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.HOST.Resolver;
using BLL.Interfaces;
using BLL;

const string CORS_POLICY_NAME = "E_COMMERCE_CLIENT_CORS_POLICY";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DAL.Data.ECommerceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceContext") ?? throw new InvalidOperationException("Connection string 'ECommerceContext' not found.")));

var origins = builder.Configuration.GetValue<string>("AllowedOrigin");
builder.Services.AddCors(opt => 
    opt.AddPolicy(
        CORS_POLICY_NAME,
        builder => 
        builder.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod().AllowCredentials()
    )
);
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddTransient<IProductBusiness, ProductBusiness>();
builder.Services.AddTransient<ICategoryBusiness, CategoryBusiness>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commerce API", Version = "v1" });
});
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

app.UseCors(CORS_POLICY_NAME);
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
