using Sistema_Nominas.Dominio;

namespace Sistema_Nominas.Infraestructura
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private static List<Empleado> listaEmpleados = new List<Empleado>();

        public void AgregarEmpleado(Empleado empleado)
        {
            listaEmpleados.Add(empleado);
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public void GenerarReporte()
        {
            foreach (var empleadoAUX in listaEmpleados)
            {
                decimal pago = empleadoAUX.CalcularPago();
                Console.WriteLine($"{empleadoAUX.PrimerNombre} {empleadoAUX.ApellidoPaterno}, Tipo: {empleadoAUX.GetType().Name}. Pago: {pago:C}");
            }
        }

        public List<Empleado> listarEmpleados()
        {
            return listaEmpleados;
        }
    }
}
