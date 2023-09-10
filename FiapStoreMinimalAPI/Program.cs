using FiapStoreMinimalAPI.Entity;
using FiapStoreMinimalAPI.Interface;
using FiapStoreMinimalAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Endpoint GET
app.MapGet("/obter-todos-usuario", (IUserRepository userRepository) =>
{
    return userRepository.GetAll();
});

//Endpoint GET
app.MapGet("/obter-usuario/{id}", (int id, IUserRepository userRepository) =>
{
    return userRepository.GetById(id);
});

//Endpoint POST
app.MapPost("/user", (User user, IUserRepository userRepository) =>
{
    userRepository.Insert(user);
});

//Endpoint PUT
app.MapPut("/user", (User user, IUserRepository userRepository) =>
{
    userRepository.Update(user);
});

//Endpoint DELETE
app.MapDelete("/user/{id}", (int id, IUserRepository userRepository) =>
{
    userRepository.Delete(id);
});

app.Run();

