using MockExam.Manage.API.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyDatabase(builder.Configuration);
builder.Services.AddDependencyRepository();
builder.Services.AddDependencyFactory();
builder.Services.AddDependencyService();

// Add services to the container.
builder.Services.AddGrpc();
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
