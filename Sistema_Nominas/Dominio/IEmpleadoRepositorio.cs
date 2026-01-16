namespace Sistema_Nominas.Dominio
{
    public interface IEmpleadoRepositorio
    {
        void AgregarEmpleado(Empleado empleado);
        void ActualizarEmpleado(Empleado empleado);

        List<Empleado> ListarEmpleados();
        void GenerarReporte();
    }
}
