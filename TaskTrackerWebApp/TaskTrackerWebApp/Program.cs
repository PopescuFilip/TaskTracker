using TaskTrackerWebApp.BusinessLogic;
using TaskTrackerWebApp.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//    //options.IdleTimeout = TimeSpan.FromMinutes(3);
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

//app.UseSession();

////begin SetString() hack
//app.Use(async delegate (HttpContext Context, Func<Task> Next)
//{
//    //this throwaway session variable will "prime" the SetString() method
//    //to allow it to be called after the response has started
//    var TempKey = Guid.NewGuid().ToString(); //create a random key
//    Context.Session.Set(TempKey, Array.Empty<byte>()); //set the throwaway session variable
//    Context.Session.Remove(TempKey); //remove the throwaway session variable
//    await Next(); //continue on with the request
//});
////end SetString() hack

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
