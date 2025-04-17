using WebApplication1.Bootstrap;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MapperProfile));

// Add repositories
builder.Services.AddScoped<ISampleRepository, SampleRepository>();
builder.Services.AddScoped<IHomeRepository, HomeRepository>();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<LoginRepository>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Add your frontend URL here
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
}); 

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        builder =>
//        {
//            builder.AllowAnyOrigin()
//                   .AllowAnyHeader()
//                   .AllowAnyMethod();
//        });
//});

var app = builder.Build();
// Add custom middleware to set Referrer-Policy header
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Referrer-Policy", "no-referrer-when-downgrade");
    await next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowLocalhost"); // Make sure this line is placed correctly


app.UseAuthorization();

app.MapControllers();

app.Run();
