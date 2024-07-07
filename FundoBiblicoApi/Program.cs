using FundoBiblico.Infra.Ioc;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


//Registro de Idependecia e Configuração do banco de dados
builder.Services.AddInfrastuctureAPi(builder.Configuration);
builder.Services.IdentityInfraConfiguration();
// Add services to the container.
//Dependency Injector
builder.Services.AddClassesMatchingInterfaces(nameof(FundoBiblico));

//Swagger
builder.Services.RegisterSwagger();

builder.Services.JWTTokenConfiguration();
builder.Services.AddAuthentication();
var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var serviceProvider = serviceScope.ServiceProvider;
    await SeedRoles.CreateRoles(serviceProvider);
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerConfiguration();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapGroup("/identity").MapIdentityApi<IdentityUser>();

app.UseStaticFiles();

app.UseRouting(); // Adicione isso antes de UseEndpoints()

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
