using ProjetoFinal_RodrigoPaulino.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal_RodrigoPaulino.Models
{
    
    public class ProdutosModel 
    {
        [Key()]
        public int Id { get; set; }
        public int IdLoja { get; set; }
        public LojasModel Lojas { get; set; }
        public string NomeProduto { get; set; }
        public string Tamanho { get; set; }
        public string Cor { get; set; }
        public double Valor { get; set; }     
    }
}
