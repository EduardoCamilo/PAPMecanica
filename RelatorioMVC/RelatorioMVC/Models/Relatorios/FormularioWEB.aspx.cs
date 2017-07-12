

using RelatorioMVC.Models.Relatorios.DataSets;
using System;
using System.Data;
using System.Linq;

namespace RelatorioMVC.Models.Relatorios
{
    public partial class FormularioWEB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarRelatorio();
            }
        }

        private void CarregarRelatorio()
        {
            rvVisualizador.ProcessingMode =
                Microsoft.Reporting.WebForms.ProcessingMode.Local;

            //Limpando datasources relatorio
            rvVisualizador.LocalReport.DataSources.Clear();

            //Escolhendo qual relatorio
            rvVisualizador.LocalReport.ReportPath =
                Request.MapPath(
                    Request.ApplicationPath + @"Models\Relatorios\Report\rptProdutosAnalitico.rdlc"
                );

            //Informando os dados
            Contexto db = new Contexto();
            var resultadoConsulta = db.Produtos.ToList();
            dsRelatorioProdutos dataSet = new dsRelatorioProdutos();
            foreach (Produto p in resultadoConsulta)
            {
                dataSet.dtProdutoAnalitico.AdddtProdutoAnaliticoRow(
                    p.Nome,
                    p.Descricao,
                    p.Preco,
                    p._Categoria.Nome
                    );
            }

            //Informando dataSet para o Relatorio
            rvVisualizador.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WebForms.ReportDataSource(
                "dsProdutos",
                (DataTable)dataSet.dtProdutoAnalitico
                )
            );

            //Carregando o relatorio
            rvVisualizador.LocalReport.Refresh();
        }
    }
}