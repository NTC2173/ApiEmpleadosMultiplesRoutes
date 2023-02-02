using ApiEmpleadosMultiplesRoutes.Data;
using ApiEmpleadosMultiplesRoutes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ApiEmpleadosMultiplesRoutes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //CONFIGURAMOS INYECCION DE DEPENDENCIAS

            //ASIGNAMOS LA CADENA DE CONEXION A UNA VARIABLE 'connectionString' LEYÉNDOLA DEL 
            //ARCHIVO DE CONFIGURACION CON EL NOMBRE 'sqlhospital'
            string connectionString = builder.Configuration.GetConnectionString("sqlhospital");

            //AGREGA UN SERVICIO TRANSITORIO PARA LA CLASE 'RepositoryEmpleados'. SIGNIFICA QUE
            //UNA NUEVA INSTANCIA DE LA CLASE 'RepositoryEmpleados' SERA CREADA CADA VEZ QUE SEA
            //NECESARIO
            builder.Services.AddTransient<RepositoryEmpleados>();

            //AGREGA UN SERVICIO DE CONTEXTO DE BASE DE DATOS 'EmpleadosContext' A LA APLICACION. 
            //EL CONTEXTO DE LA BD SE REGISTRA CON UNA FUNCION DE CONFIGURACION QUE ESPECIFICA QUE
            //SE UTILIZARA EL PROVEEDOR DE LA BASE DE DATOS SQL SERVER Y LA CADENA DE CONEXION DADA.
            //SIGNIFICA QUE CADA  VEZ QUE SE REQUIERE UNA INSTANCIA DE LA CLASE 'EmpleadosContext' 
            //SE UTILIZARA LA CADENA DE CONEXION PROPORCIONADA PARA CONECTARSE A LA BD
            builder.Services.AddDbContext<EmpleadosContext>
                (options => options.UseSqlServer(connectionString));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    { 
                        Title = "Api Empleados Multiples Routes", Version = "v1"
                    });
                });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiEmpleadosMultiplesRoutes v1");
                options.RoutePrefix = "";
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}