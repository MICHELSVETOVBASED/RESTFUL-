using RESTREST_2.Services;
using RESTREST_2.Data;
using Microsoft.EntityFrameworkCore;
using RESTREST_2.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IProfileRepository,ProfileRepository>();
builder.Services.AddDbContext<Axer>(opt => opt.UseInMemoryDatabase("Profiles"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Добавляем маршрут для index.html
    
app.MapGet("/", (context) => {
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;
});

app.MapGet("/profiles", async (Axer db) =>
    await db.Profiles.ToListAsync());
app.MapGet("/profiles/complete", async (Axer db) =>
    await db.Profiles.Where(t => t.IsActive).ToListAsync());
app.MapGet("/profiles/{id}", async (int id, Axer db) =>
    await db.Profiles.FindAsync(id)
        is Profile profile
        ? Results.Ok(profile)
        : Results.NotFound());
app.MapPost("/profiles", async (Profile profile, Axer db) => {
    db.Profiles.Add(profile);
    await db.SaveChangesAsync();

    return Results.Created($"/profiles/{profile.Id}", profile);
});
app.MapPut("/profiles/{id}", async (int id, Profile inputProfile, Axer db) => {
    var profile = await db.Profiles.FindAsync(id);
    if (profile == null) return Results.NotFound();
    profile.Name = inputProfile.Name;
    profile.IsActive = inputProfile.IsActive;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/profiles/{id}", async (int id, Axer db) => {
    if (await db.Profiles.FindAsync(id) is Profile profile){
        db.Profiles.Remove(profile);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});


app.MapControllers();

app.Run();
