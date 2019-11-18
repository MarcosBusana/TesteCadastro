using System.Threading.Tasks;

namespace Dominio.Fornecedores.Validacao
{
    public interface IFornecedorValidador
    {
        bool EhValido(Fornecedor fornecedor);
    }
}
