namespace Sistema_Nominas.Dominio
{
    public class EmpleadoPorComision : Empleado
    {
        private decimal ventasBrutas;
        private decimal tarifaComision;

        public decimal VentasBrutas
        {
            get => ventasBrutas;
            set => ventasBrutas = (value >= 0) ? value : 0;
        }

        public decimal TarifaComision
        {
            get => tarifaComision;
            set
            {
                if (value < 0)
                {
                    tarifaComision = 0;
                }
                else if (value > 1)
                {
                    tarifaComision = value / 100;
                }
                else
                {
                    tarifaComision = 0;
                }

            }
        }
      
        public EmpleadoPorComision(string primernombre, string apellidopaterno, string nss, decimal ventasbrutas, decimal tarifacomision) : base(primernombre, apellidopaterno, nss)
        {
            VentasBrutas = ventasbrutas;
            TarifaComision = tarifacomision;
        }

        public override decimal CalcularPago()
        {
            return VentasBrutas * TarifaComision;
        }
    }
}
