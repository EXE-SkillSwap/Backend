using Microsoft.EntityFrameworkCore;
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Data;
using SkillSwap.DAL.Implementation;
using SkillSwap.Services.Contract;
using SkillSwap.Services.HubService;
using SkillSwap.Services.HubService.Service;
using SkillSwap.Services.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Đăng ký Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký các dịch vụ và repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IConversationPartnersService, ConversationPartnersService>();
builder.Services.AddScoped<IConversationService, ConversationService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IPartnerShipService, PartnerShipService>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<IHubService, HubService>();
builder.Services.AddScoped<IJwtService, JWTService>();

// Đăng ký SignalR
builder.Services.AddSignalR();

// Đăng ký DbContext
builder.Services.AddDbContext<SwapSkillDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DB"]);
});

// Cấu hình CORS (nếu cần cho SignalR)
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting(); // Thêm middleware định tuyến

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Thêm middleware xử lý ngoại lệ toàn cục
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync("{\"error\": \"An unexpected error occurred. Please try again later.\"}");
    });
});

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // Áp dụng chính sách CORS

app.UseAuthorization();

// Định tuyến SignalR Hub
app.MapHub<NotificationHub>("/notifications");

app.MapControllers();

app.Run();