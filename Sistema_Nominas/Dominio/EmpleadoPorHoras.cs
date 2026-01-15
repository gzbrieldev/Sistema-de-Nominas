namespace Sistema_Nominas.Dominio
{
    public class EmpleadoPorHoras : Empleado
    {
        private int horasTrabajadas;
        private decimal sueldoPorHora;
        public int HorasTrabajadas
        {
            get => horasTrabajadas;
            set => horasTrabajadas = (value >= 0) ? value : 0; // Evitar horas negativas pero aceptar 0 horas (si no trabaja)
        }

        public decimal SueldoPorHora
        {
            get => sueldoPorHora;
            set => sueldoPorHora = (value < 0) ? 0 : value;
        }


        public EmpleadoPorHoras(string primernombre, string apellidopaterno, string nss, decimal sueldoporhora, int horastrabajadas) : base(primernombre, apellidopaterno, nss)
        {
            SueldoPorHora= sueldoporhora;
            HorasTrabajadas = horastrabajadas;
        }

        public override decimal CalcularPago()
        {
            if (horasTrabajadas <= 40)
            {
                return (sueldoPorHora * horasTrabajadas);
            }
            else if (horasTrabajadas >= 40)
            {
                return (sueldoPorHora * 40) + (sueldoPorHora * 1.5m * (horasTrabajadas - 40));
            }
            else { return 0; }
        }
    }
}
