using GolfWebApi.Data;
using GolfWebApi.Extensions;
using Microsoft.AspNetCore.HttpOverrides;  

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.
builder.Services.ConfigureCors();

builder.Services.ConfigureIISIntegration(); // Configure IIS Integration

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  
}
else
{
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();