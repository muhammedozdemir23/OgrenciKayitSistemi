using OgrenciKayitSistemi.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"appsettings.prod.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
builder.Services.AddHttpContextAccessor();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", policy =>
{
    policy
    .WithOrigins("http://localhost:7118")
    .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("ApiCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
