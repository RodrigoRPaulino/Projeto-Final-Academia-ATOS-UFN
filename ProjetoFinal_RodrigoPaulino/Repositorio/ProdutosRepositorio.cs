using ProjetoFinal_RodrigoPaulino.Data;
using ProjetoFinal_RodrigoPaulino.Models;

namespace ProjetoFinal_RodrigoPaulino.Repositorio
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ProdutosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public ProdutosModel CadastrarProdutos(ProdutosModel produtos)
        {
            _bancoContext.Produtos.Add(produtos);
            _bancoContext.SaveChanges();
            return produtos;

        }

        public ProdutosModel EditarProdutos(ProdutosModel produtos)
        {
            throw new NotImplementedException();
        }

        public ProdutosModel AtualizarProduto(ProdutosModel produtos)
        {
            throw new NotImplementedException();
        }

        public ProdutosModel BuscarIdProduto(int idproduto)
        {
            throw new NotImplementedException();
        }

        public List<ProdutosModel> BuscarTodos()
        {
            throw new NotImplementedException();
        }

       
    }



}
