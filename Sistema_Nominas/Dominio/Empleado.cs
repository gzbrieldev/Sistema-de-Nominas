namespace Sistema_Nominas.Dominio
{
    public abstract class Empleado
    {
        static int contador;
        private string primerNombre;
        private string apellidoPaterno;
        private readonly string numeroSeguroSocial; // Solo se puede inicializar, no modificar 

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
            contador++;
        }

        public abstract decimal CalcularPago();

        public override string ToString() { return $"Nombre: {PrimerNombre} {ApellidoPaterno}, NSS: {numeroSeguroSocial}"; }
    }
}
