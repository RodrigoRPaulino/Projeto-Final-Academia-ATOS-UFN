using ProjetoFinal_RodrigoPaulino.Data;
using ProjetoFinal_RodrigoPaulino.Models;

namespace ProjetoFinal_RodrigoPaulino.Repositorio
{
  public interface IProdutosRepositorio 
    {
        ProdutosModel BuscarIdProduto( int id);
        List<ProdutosModel> BuscarTodos();
        ProdutosModel AtualizarProduto(ProdutosModel produtos);
        ProdutosModel CadastrarProdutos(ProdutosModel produtos);
        ProdutosModel EditarProdutos(ProdutosModel produtos);
      

       
    }
}
