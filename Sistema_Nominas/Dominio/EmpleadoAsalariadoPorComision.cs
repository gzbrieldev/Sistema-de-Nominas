namespace Sistema_Nominas.Dominio
{
    // En vez de heredar directamente de Empleado, hereda de Empleado asalariado, así ya cuenta con el atributo de salarioSemanal
    // y el metodo base.
    public class EmpleadoAsalariadoPorComision : EmpleadoAsalariado
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
        public EmpleadoAsalariadoPorComision(string primernombre, string apellidopaterno, string nss, decimal salariosemanal, decimal ventasbrutas, decimal tarifacomision) : base(primernombre, apellidopaterno, nss, salariosemanal)
        {
            VentasBrutas = ventasbrutas;
            TarifaComision = tarifacomision;
        }

        public override decimal CalcularPago()
        {
            return base.CalcularPago() + (VentasBrutas * TarifaComision);
        }

        public override string ToString() { return base.ToString() + $", Tipo: Asalariado + Comisión, Base: {SalarioSemanal:C}, Ventas: {VentasBrutas:C}, Comisión: {TarifaComision:P}"; }

    }
}
