namespace Sistema_Nominas.Dominio
{
    public class EmpleadoAsalariado : Empleado
    {
        private decimal salarioSemanal;
        public decimal SalarioSemanal
        {
            get => salarioSemanal;
            set => salarioSemanal = (value < 0) ? 0 : value; // Evitar cantidad negativa
        }
        public EmpleadoAsalariado(string primernombre, string apellidopaterno, string nss, decimal salariosemanal) : base(primernombre, apellidopaterno, nss)
        {
            SalarioSemanal = salariosemanal;
        }

        public override decimal CalcularPago()
        {
            return SalarioSemanal;
        }
    }
}
