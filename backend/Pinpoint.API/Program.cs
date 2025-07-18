using Microsoft.EntityFrameworkCore;
using Pinpoint.Data;
using Pinpoint.Data.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.InjectDependencies();

builder.Services.AddDbContextPool<Context>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Pinpoint")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAllPolicy",
        policy =>
        {
            // TODO: this is only for development and SHOULD NOT exist when deployed
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAllPolicy");

app.MapControllers();

app.Run();