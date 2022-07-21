using ProjetoFinal_RodrigoPaulino.Data;
using ProjetoFinal_RodrigoPaulino.Models;

namespace ProjetoFinal_RodrigoPaulino.Repositorio
{
    /// <summary>
    /// depois de criar a string de conexão criamos a pasta repositorio
    /// que sera responsavel por adicionar excluir buscar e atualizar as informacoes da tabela de lojas
    /// implementamos a ILojasRepositorio
    /// </summary>
    public class LojasRepositorio : ILojasRepositorio
    {
        /// <summary>
        /// para gravar precisamos injetar o BancoContext aqui na LojasRepositorio
        /// criamos tambem uma variavel privada para usarmos nessa classe
        /// para a injeção de dependencia
        /// </summary>
        private readonly BancoContext _bancoContext;
        
        public LojasRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
 
        /// <summary>
        /// esse método carrega toda a lista de lojas do banco de dados
        /// </summary>
        /// <returns></returns>
        public List<LojasModel> BuscarTodos()
        {
            return _bancoContext.Lojas.ToList();
        }

        /// <summary>
        /// Método para buscarmos o id do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public LojasModel BuscarId(int id)
        {
            //retornamos uma busca pelo primeiro
            //ou unico registro do banco passando uma
            //expressao lambda
            return _bancoContext.Lojas.FirstOrDefault(x=> x.Id == id);
        }

        public LojasModel Cadastrar(LojasModel lojas)
        {
            //gravar no banco de dados
            _bancoContext.Lojas.Add(lojas);
            _bancoContext.SaveChanges();
            return lojas;
        }

        public LojasModel Atualizar(LojasModel lojas)
        {
            //criamos uma varável lojasDb buscando o id da loja
            LojasModel lojasDB = BuscarId(lojas.Id);
            //criamos uma condição se a lojaDb for nula mostramos uma menssagem de erro 
            if (lojasDB == null) throw new Exception("Erro ao atualizar!\n Tente novamente");

            //se ele nao for nulo pegamos o dados do banco recebendo 
            //os dados quem vem da model
            lojasDB.Nome = lojas.Nome;
            lojasDB.Localizacao = lojas.Localizacao;
            lojasDB.Seguimento = lojas.Seguimento;
            lojasDB.Telefone = lojas.Telefone;
            //update no banco de dados
            _bancoContext.Lojas.Update(lojasDB);
            //salva as alteraçoes
            _bancoContext.SaveChanges();
            //retorna ao banco
            return lojasDB;
        }

        /// <summary>
        /// método que apaga de fato do banco de dados
        /// usando o id como parametro de entrada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool Apagar(int id) 
        {
            //buscamos o id a ser deletado
            LojasModel lojasDB = BuscarId(id);
            //condição onde se a loja for nula mostra a mensagem de erro
            if (lojasDB == null) throw new Exception("Não foi possivel excluir a loja selecionada.\n Tente novamente");
            // remoção do banco
            _bancoContext.Lojas.Remove(lojasDB);
            // grava as alterações
            _bancoContext.SaveChanges();
            return true;
        }
        
           
        
    }
}
