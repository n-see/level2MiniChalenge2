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


