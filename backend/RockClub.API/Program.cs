using RockClub.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServices();
builder.AddDatabase();
builder.AddInjections();
builder.AddValidations();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RockClub v1"));

}

// Configurar o pipeline HTTP
app.UseCors("AllowMyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
