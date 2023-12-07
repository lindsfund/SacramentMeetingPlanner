using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DinkToPdf;
using DinkToPdf.Contracts;
using SacramentMeetingPlanner.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MusicalNumbersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MusicalNumbersContext") ?? throw new InvalidOperationException("Connection string 'MusicalNumbersContext' not found.")));
builder.Services.AddDbContext<MeetingPlanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeetingPlanContext") ?? throw new InvalidOperationException("Connection string 'MeetingPlanContext' not found.")));
builder.Services.AddDbContext<SpeakersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpeakersContext") ?? throw new InvalidOperationException("Connection string 'SpeakersContext' not found.")));
builder.Services.AddDbContext<HymnsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HymnsContext") ?? throw new InvalidOperationException("Connection string 'HymnsContext' not found.")));

// Configure DinkToPdf
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<PdfGenerator>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
