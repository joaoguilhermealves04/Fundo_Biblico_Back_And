using FundoBiblico.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


//Registro de Idependecia e Configuração do banco de dados
builder.Services.AddInfrastuctureAPi(builder.Configuration);
// Add services to the container.


//Dependency Injector
builder.Services.AddClassesMatchingInterfaces(nameof(FundoBiblico));

//Swagger
builder.Services.RegisterSwagger();


var app = builder.Build();

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
app.UseStaticFiles();

app.UseRouting(); // Adicione isso antes de UseEndpoints()

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
}); // UseEndpoints() deve ser chamado antes de app.Run()

//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fundo Biblico Api");
//    c.RoutePrefix = string.Empty;
//});

app.Run();
