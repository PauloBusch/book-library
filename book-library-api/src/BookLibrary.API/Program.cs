using BookLibrary.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services
    .AddBookInfraModule(
        builder.Configuration,
        registerConsumers: configurator => { }
    )
    .AddCors(setup =>
        setup.AddPolicy("default", cors =>
            cors.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
        )
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
