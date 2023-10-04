using Domain.Lists;
using System;
using System.Data;

namespace Domain.Queries
{
    public class ConsultarDespesas_DO : ConsultarCentralDeDados_DO//Não mudar essa herança senão vai dar erros.
    {
        //============================================| Consultar Despesas Gerais de Todos os Anos |====================================================================//

        public ListaDeValoresMeses ConsultarDespesasGeraisDeTodosOsAnos()
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Declare @Janeiro decimal (18, 2)" +
                "Set @Janeiro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Janeiro'))" +

                "Declare @Fevereiro decimal(18, 2)" +
                "Set @Fevereiro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Fevereiro'))" +

                "Declare @Marco decimal(18, 2)" +
                "Set @Marco = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Março'))" +

                "Declare @Abril decimal(18, 2)" +
                "Set @Abril = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Abril')) " +

                "Declare @Maio decimal(18, 2)" +
                "Set @Maio = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Maio'))" +

                "Declare @Junho decimal(18, 2)" +
                "Set @Junho = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Junho'))" +

                "Declare @Julho decimal(18, 2)" +
                "Set @Julho = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Julho'))" +

                "Declare @Agosto decimal(18, 2)" +
                "Set @Agosto = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Agôsto'))" +

                "Declare @Setembro decimal(18, 2)" +
                "Set @Setembro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Setembro'))" +

                "Declare @Outubro decimal(18, 2)" +
                "Set @Outubro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Outubro'))" +

                "Declare @Novembro decimal(18, 2)" +
                "Set @Novembro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Novembro'))" +

                "Declare @Dezembro decimal(18, 2)" +
                "Set @Dezembro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Despesas Gerais' And Mes = 'Dezembro'))" +

                "Select(Select @Janeiro) as Janeiro," +
                "(Select @Janeiro + @Fevereiro) as Fevereiro," +
                "(Select @Janeiro + @Fevereiro + @Marco) as Marco," +
                "(Select @Janeiro + @Fevereiro + @Marco + @Abril) as Abril," +
                "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio) as Maio," +
                "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho) as Junho," +
                "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho) as Julho," +
                "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto) as Agosto," +
                "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto + @Setembro) as Setembro," +
                "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto + @Setembro + @Outubro) as Outubro," +
                "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto + @Setembro + @Outubro + @Novembro) as Novembro," +
                "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto + @Setembro + @Outubro + @Novembro + @Dezembro) as Dezembro," +
                "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto + @Setembro + @Outubro + @Novembro + @Dezembro) as TotalAno");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Meses meses = new()
                {
                    Janeiro = Convert.ToDecimal(dataRow["Janeiro"]),
                    Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]),
                    Marco = Convert.ToDecimal(dataRow["Marco"]),
                    Abril = Convert.ToDecimal(dataRow["Abril"]),
                    Maio = Convert.ToDecimal(dataRow["Maio"]),
                    Junho = Convert.ToDecimal(dataRow["Junho"]),
                    Julho = Convert.ToDecimal(dataRow["Julho"]),
                    Agosto = Convert.ToDecimal(dataRow["Agosto"]),
                    Setembro = Convert.ToDecimal(dataRow["Setembro"]),
                    Outubro = Convert.ToDecimal(dataRow["Outubro"]),
                    Novembro = Convert.ToDecimal(dataRow["Novembro"]),
                    Dezembro = Convert.ToDecimal(dataRow["Dezembro"]),
                    TotalAno = Convert.ToDecimal(dataRow["TotalAno"])
                };
                ListaDeValoresMeses.Add(meses);
            }
            return ListaDeValoresMeses;
        }
    }
}
