using ValidaCpf;

namespace API_Desafio_Angular.Util
{
    public static class Cpf
    {
        public static bool ValidacaoCPF(string cpf)
        {            
            return ValidaCpfExtension.Validate(cpf);;
        }
    }
}