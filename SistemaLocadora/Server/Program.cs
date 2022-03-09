using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Server.Context;
using SistemaLocadora.Server.Repositories;
using SistemaLocadora.Service.Policies;
using SistemaLocadora.Service.Policies.Interfaces;
using SistemaLocadora.Service.Services;
using SistemaLocadora.Service.Services.Interfaces;
using SistemaLocadora.Service.Services.Interfaces.ReportServices;
using SistemaLocadora.Service.Services.ReportServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigureServices(builder.Services);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();


void ConfigureServices(IServiceCollection services)
{
    string connectionString;

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddTransient<IClienteRepository, ClienteRepository>();
    services.AddTransient<IFilmeRepository, FilmeRepository>();
    services.AddTransient<ILocacaoRepository, LocacaoRepository>();

    services.AddScoped<IDataDevolucaoPolicy, DataDevolucaoPolicy>();

    services.AddTransient<IClienteService, ClienteService>();
    services.AddTransient<IFilmeService, FilmeService>();
    services.AddTransient<ILocacaoService, LocacaoService>();
    services.AddTransient<IClienteServiceReport, ClienteServiceReport>();
    services.AddTransient<IFilmeReportService, FilmeReportService>();

    //connectionString = "Server=localhost;Port=3306;Database=sistema_locadora;Uid=root;Pwd=admin;";
    //connectionString = "User ID=Dev;Password=DevAdmin;Host=localhost;Port=5432;Database=SistemaLocacao;Pooling=true;Connection Lifetime=0;";
    connectionString = "Data Source=MAGNO-PC\\MSSQLSRVMAGNO;Initial Catalog=SistemaLocacao;User ID=sistemasteste;Password=123456;Connect Timeout=0;Application Name=SistemaLocacao";

    //services.AddDbContext<LocadoraContext>(context =>
    //    context.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

    builder.Services.AddDbContext<LocadoraContext>(context =>
        context.UseSqlServer(connectionString));
}
