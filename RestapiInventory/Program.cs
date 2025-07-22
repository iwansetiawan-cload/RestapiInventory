using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using RestapiInventory.Services;
using RestapiInventory.Dao;
using RestapiInventory.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



var sessionFactory = Fluently.Configure()
    .Database(MsSqlConfiguration.MsSql2012
        .ConnectionString(connectionString)
        .Driver<MicrosoftDataSqlClientDriver>()
        .Dialect<NHibernate.Dialect.MsSql2012Dialect>()
        //.ShowSql()
        )
    //.ExposeConfiguration(cfg =>
    //{
    //    new SchemaUpdate(cfg).Execute(false, true);
    //})
    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PurchaseRequestHeader>())

.BuildSessionFactory();

//DAO
builder.Services.AddScoped(typeof(CommonDao<>));
builder.Services.AddScoped<PurchaseRequestHeaderDao>();
builder.Services.AddScoped<PurchaseRequestDetailDao>();
builder.Services.AddScoped<UserProfileDao>();

// SERVICE
builder.Services.AddScoped<PurchaseRequestService>();
builder.Services.AddScoped<UserProfileService>();

builder.Services.AddSingleton(sessionFactory);
builder.Services.AddScoped(factory => sessionFactory.OpenSession());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
