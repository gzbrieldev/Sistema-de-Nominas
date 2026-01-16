namespace Sistema_Nominas.Dominio
{
    public interface IEmpleadoRepositorio
    {
        void AgregarEmpleado(Empleado empleado);
        void ActualizarEmpleado(Empleado empleado);

        Empleado BuscarPorNss(string nss);
        List<Empleado> ListarEmpleados();
        void GenerarReporte();
    }
}
