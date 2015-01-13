using System;

namespace App
{
    #region Models...

    public class ProdutoModel
    {
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
    }

    public class CompraModel
    {
        public Int32 Codigo { get; set; }
        public ProdutoModel[] Produtos { get; set; }
        public Decimal Total { get; set; }
    }

    public class ClienteModel
    {
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public Int32 Idade { get; set; }
        public String Email { get; set; }
        public String Cpf { get; set; }

        public CompraModel Compra { get; set; }
    }

    public class Cidade
    {
        public int CidadeCodigo { get; set; }
        public string EstadoUF { get; set; }
        public string CidadeNome { get; set; }
        public string CidadeLogradouroCodificado { get; set; }
        public Nullable<int> CidadeCEPGeral { get; set; }
        public string CidadeNomeAbreviado { get; set; }
        public string CidadeTipoLocalidade { get; set; }
        public Nullable<System.DateTime> CidadeDataCriacao { get; set; }
        public Nullable<System.DateTime> CidadeDataAtualizacao { get; set; }
        public string CidadeValida { get; set; }
        public string CidadeNomeSemAcento { get; set; }
        public string CidadeNomecomEstado { get; set; }
    }

    #endregion

    public class Program
    {
        public static void Main(String[] args)
        {
            //http://pt.wikipedia.org/wiki/Heur%C3%ADstica
            //https://www.random.org/lists/

            var executer = Seeder.Seeder.CreateInstance();
            //var clientes = executer.Seed<ClienteModel>(100);

            var analyzed = executer.Analyze<ClienteModel>();

            //var cidades = executer.Seed<Cidade>(5);

            /*var randomizer = new Randomizer();
            var lorem = new LoremIpsum();

            var count = 15;
            var type = LoremIpsum.Type.Word;

            var text = lorem.CreateText(count, type, randomizer);*/

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}