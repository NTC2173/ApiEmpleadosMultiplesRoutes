using ApiEmpleadosMultiplesRoutes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiEmpleadosMultiplesRoutes.Data
{
    public class EmpleadosContext : DbContext
    {
        
        //EXPLICACION: (Este código es un constructor de la clase 'EmpleadosContext'
        //que es una subclase de 'DbContext' de Entity Framework.
        //El constructor está usando la inicialización base para inicializar la clase
        //base 'DbContext' con las opciones especificadas en 'options'.
        //'DbContext' es una clase central en Entity Framework que se utiliza para
        //interactuar con una base de datos y según los modelos de entidades definidos.
        //La clase 'EmpleadosContext' está proporcionando una implementación específica
        //del contexto para trabajar con una base de datos de empleados)
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options) { }


        //EXPLICACION: (Este código es una propiedad pública llamada 'Empleados'
        //de tipo DbSet<Empleado>.
        //'DbSet' es una clase en Entity Framework que representa
        //un conjunto de entidades en una base de datos. La propiedad 'Empleados' está
        //exponiendo un DbSet de entidades Empleado.
        //La propiedad 'Empleados' puede ser utilizada para realizar operaciones de base
        //de datos, como agregar, eliminar o actualizar entidades 'Empleado' en la base
        //de datos asociada al contexto de la aplicación)
        public DbSet<Empleado> Empleados { get; set; }
    }

}
