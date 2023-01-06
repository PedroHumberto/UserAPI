using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserAPI.Services;
using UsersAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//DB Injection
builder.Services.AddDbContext<UserDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("UserConnection")));

//Idenity
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
    .AddEntityFrameworkStores<UserDbContext>();

builder.Services.Configure<IdentityOptions>(opts => {
    opts.Password.RequiredLength = 7;
});
//--------------------

//Injections
builder.Services.AddScoped<SingUpService, SingUpService>();


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
