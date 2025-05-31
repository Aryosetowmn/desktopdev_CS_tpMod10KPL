var builder = WebApplication.CreateBuilder(args);

// Menambahkan service controller ke dalam container
builder.Services.AddControllers();

// Menambahkan tools dokumentasi API (Swagger)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Konfigurasi middleware saat development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware keamanan dan routing
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Menghubungkan endpoint controller
app.MapControllers();

// Menjalankan aplikasi
app.Run();
