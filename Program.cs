var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

//number string endpoint 1

app.MapGet("/addNums", (double num1, double num2 ) =>{
    return "The sum of " + num1 + " + " +  num2 + " is " + (num1 + num2);
} );

//endpoint 2

app.MapGet("/sentences", (string name, string whatTimeDidYouWakeUp) => {
    return "Greetings " + name + "! you woke up at " + whatTimeDidYouWakeUp; 

});

//Endpoint 3

app.MapGet("/compareNums", (double num1, double num2) =>{
    if(num1 > num2){
        return num1 + " is greater than " + num2;
    } else if(num1 < num2){
        return num2 + " is greater than " + num1;
    }else{
        return num1 + " is the same as " + num2;
    }
} );




app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
