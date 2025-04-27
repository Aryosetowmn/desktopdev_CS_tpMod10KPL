var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Tambahkan ini supaya aplikasi jalan lebih aman:
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Map endpoint controller
app.MapControllers();

app.Run();