using Sistema_Nominas.Dominio;

namespace Sistema_Nominas.Aplicacion
{
    public class EmpleadoServicio
    {
        private readonly IEmpleadoRepositorio repoitorio;

        // Se implementa en la presentación y de aqui se llaman los metodos
        public EmpleadoServicio(IEmpleadoRepositorio repo)
        {
            repoitorio = repo;
        }

        public void RegistrarEmpleados(Empleado empleado)
        {
            repoitorio.AgregarEmpleado(empleado);
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            repoitorio.ActualizarEmpleado(empleado); // por implementar
        }

        public List<Empleado> ListarEmpleados()
        {
            return repoitorio.ListarEmpleados(); 
        }

        public void GenerarReporte()
        {
            repoitorio.GenerarReporte();
        }
    }
}
