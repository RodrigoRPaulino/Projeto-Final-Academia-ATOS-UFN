using ProjetoFinal_RodrigoPaulino.Models;

namespace ProjetoFinal_RodrigoPaulino.Repositorio
{

    /// <summary>
    /// depois de criar a string de conexão criamos a pasta repositorio
    /// que sera responsavel por adicionar excluir buscar e atualizar as informacoes da tabela de lojas
    /// </summary>
    public interface ILojasRepositorio
    {
        /// <summary>
        /// depois de ir no método editar na cotroller 
        /// vamos criar o método de interfaçe
        /// para buscar o id do banco
        ///  recebendo um int id
        ///  retornando um contato model
        /// </summary>
        /// <returns></returns>
        LojasModel BuscarId(int id);

        /// <summary>
        /// depois que inserimos o novo cadastro no banco de dados 
        /// criamos um método de interfaçe
        /// para buscar do banco
        /// </summary>
        /// <returns></returns>
        List<LojasModel> BuscarTodos();

        /// <summary>
        /// criamos um método de interfaçe 
        /// para Cadastrar as lojas no banco
        /// </summary>
        /// <param name="lojas"></param>
        /// <returns></returns>
        LojasModel Cadastrar(LojasModel lojas);

        /// <summary>
        /// método de interfaçe para atualizar uma loja
        /// cadastrada no banco
        /// </summary>
        /// <param name="lojas"></param>
        /// <returns></returns>
        LojasModel Atualizar(LojasModel lojas);
        
        /// <summary>
        /// método para apagar  um registro do banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Apagar(int id);
        
    }
}
