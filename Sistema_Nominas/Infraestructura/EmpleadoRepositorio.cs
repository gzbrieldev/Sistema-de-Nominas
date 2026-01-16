using Sistema_Nominas.Dominio;
using System;

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
            var index = listaEmpleados.FindIndex(e => e.NumeroSeguroSocial == empleado.NumeroSeguroSocial);
            if (index != -1) { listaEmpleados[index] = empleado; }
        }

        public void GenerarReporte()
        {
            foreach (var empleadoAUX in listaEmpleados)
            {
                decimal pago = empleadoAUX.CalcularPago();
                Console.WriteLine($"{empleadoAUX.PrimerNombre} {empleadoAUX.ApellidoPaterno}, Tipo: {empleadoAUX.GetType().Name}. Pago: {pago:C}");
            }
        }

        public List<Empleado> ListarEmpleados()
        {
            return listaEmpleados;
        }

        public Empleado BuscarPorNss(string nss)
        {
            return listaEmpleados.FirstOrDefault(e => e.NumeroSeguroSocial == nss);
        }
    }
}
