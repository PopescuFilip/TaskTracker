using System.Reflection;
using TaskAPI.Db;
using TaskAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<ITaskService, TaskService>();

builder.Services.AddDbContextFactory<TaskTrackerDbContext, TaskTrackerDbContextFactory>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.IdleTimeout = TimeSpan.FromMinutes(3);
});

if (!IsRunningOnLocalEnvironment())
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(8082);
    });
}

var app = builder.Build();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseSession();
app.UseAuthorization();


app.MapControllers();

app.Run();

static bool IsRunningOnLocalEnvironment() => Environment.GetEnvironmentVariable("DB_HOST") == null;