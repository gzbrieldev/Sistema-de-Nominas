namespace Sistema_Nominas.Dominio
{
    public abstract class Empleado
    {
        private string primerNombre;
        private string apellidoPaterno;
        private readonly string numeroSeguroSocial;

        public string PrimerNombre
        {
            get { return primerNombre; }
            set { primerNombre = value; }
        }
        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }

        public Empleado(string primernombre, string apellidopaterno, string nss)
        {
            PrimerNombre= primernombre;
            ApellidoPaterno= apellidopaterno;
            numeroSeguroSocial= nss;
        }

        public abstract decimal CalcularPago();
    }
}
