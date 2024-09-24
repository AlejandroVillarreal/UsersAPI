using Microsoft.EntityFrameworkCore;
using UserAPI.Core.Domain.RepositoryContracts;
using UserAPI.Core.ServiceContracts;
using UserAPI.Core.Services;
using UserAPI.Infrastructure.DbContext;
using UserAPI.Infrastructure.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins("http://localhost:4200/"
											  );
					  });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UserDbContext>(options =>
{

	try
	{
		options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
	}
	catch
	{
		options.UseMySql(connectionString, ServerVersion.AutoDetect(
			builder.Configuration.GetConnectionString("LocalHostConnection")
		));
	}

}
);

builder.Services.AddScoped<IUserGetAllService, UserGetAllService>();
builder.Services.AddScoped<IUserGetByIdService, UserGetByIdService>();
builder.Services.AddScoped<IUserAddService, UserAddService>();
builder.Services.AddScoped<IUserUpdateService, UserUpdateService>();
builder.Services.AddScoped<IUserCreateService, UserCreateService>();
builder.Services.AddScoped<IUserDeleteService, UserDeleteService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseHsts();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
