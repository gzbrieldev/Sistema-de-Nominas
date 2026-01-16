namespace Sistema_Nominas.Dominio
{
    public abstract class Empleado
    {
        private static int contador;
        private string primerNombre;
        private string apellidoPaterno;
        private string numeroSeguroSocial; // Solo se puede inicializar, no modificar 

        public string PrimerNombre
        {
            get => primerNombre; 
            set => primerNombre = value; 
        }
        public string ApellidoPaterno
        {
            get => apellidoPaterno; 
            set => apellidoPaterno = value; 
        }

        public string NumeroSeguroSocial
        {
            get => numeroSeguroSocial;
        }

        public static int Contador
        {
            get => contador;
        }

        public Empleado(string primernombre, string apellidopaterno, string nss)
        {
            PrimerNombre= primernombre;
            ApellidoPaterno= apellidopaterno;
            numeroSeguroSocial= nss;
            contador++;
        }

        public abstract decimal CalcularPago();

        public override string ToString() { return $"- Nombre: {PrimerNombre} {ApellidoPaterno}, NSS: {numeroSeguroSocial}"; }
    }
}
