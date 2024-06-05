namespace DesafioBT.Context
{
    public interface IPrincipalContext
    {
        bool ConsultarAtivo(string ativo, double valorMaior, double valorMenor);
    }
}
