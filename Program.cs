using RESTREST_2.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ProfileRepository>();

// Adding a Swagger service (after NuGet packages are installed)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
if (app.Environment.IsDevelopment()){
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
//app.MapGet("/", () => "Start succeeded");
app.UseMvc(routes =>
    routes.MapRoute(name: "default",
        template: "{controller=Profile}/{action=Index}"));
app.MapControllerRoute("default",
        "{controller=Profile}/{action=Index}");
app.MapControllers();

app.Run();//mod
