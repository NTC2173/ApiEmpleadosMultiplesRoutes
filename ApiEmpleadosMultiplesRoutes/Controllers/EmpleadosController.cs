using ApiEmpleadosMultiplesRoutes.Models;
using ApiEmpleadosMultiplesRoutes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpleadosMultiplesRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        //NO PODEMOS LLAMAR DOS ROUTES IGUALES

        //api/Empleados
        [HttpGet]
        public ActionResult<List<Empleado>> GetEmpleados()
        {
            List<Empleado> empleados = this.repo.GetEmpleados();
            return empleados;
        }

        //api/Empleados/99
        [HttpGet("{id}")]
        public ActionResult<Empleado> FindEmpleado(int id)
        {
            Empleado empleado = this.repo.FindEmpleado(id);
            return empleado;
        }

        //api/empleados/oficios
        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<string>> Oficios()
        {
            List<string> oficios = this.repo.GetOficios();

            return oficios;
        }

        //api/empleados/empleadosoficio/DIRECTOR (algo)
        [HttpGet]
        [Route("[action]/{oficio}")]
        public ActionResult<List<Empleado>> FindEmpleadosOficio(string oficio)
        {
            List<Empleado> empleados = this.repo.GetEmpleadosOficio(oficio);
            return empleados;
        }

        [HttpGet]
        [Route("[action]/{salario}")]
        public ActionResult<List<Empleado>> EmpleadosSalario(int salario)
        {
            List<Empleado> empleados = this.repo.GetEmpleadosSalario(salario);
            return empleados;
        }

    }
}
