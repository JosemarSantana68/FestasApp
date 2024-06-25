//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do Módulo: 22/06/2024
//   Ultima Alteração: 22/06/2024
//   
//   FUNÇÕES AUXILIARES PARA FestasApp
//
//************************************************************

namespace FestasApp.Utilities.myFunctions
{
    public static class myFunctions
    {
        //
        // configurar colunas de datagriviews
        //
        public static void ConfigurarColuna(DataGridView dtg, 
                                            int colIndex, 
                                            string headerText, 
                                            int width, 
                                            DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft, 
                                            Padding? padding = null,
                                            bool visible = true)
        {
            if (dtg.Columns.Count > colIndex)
            {
                dtg.Columns[colIndex].HeaderText = headerText;
                dtg.Columns[colIndex].Width = width;
                dtg.Columns[colIndex].DefaultCellStyle.Alignment = alignment; // Atribui alignment diretamente
                if (padding.HasValue)
                {
                    dtg.Columns[colIndex].DefaultCellStyle.Padding = padding.Value;
                }
                dtg.Columns[colIndex].Visible = visible;
            }
        }
        //
        // estatisticas em DataGridViews, Total de Registros, Datas e Somas
        //
        public static void CalcularDataGridDatasSomas(DataGridView dataGridView, int colunaDataIndex, int colunaValorIndex, out int totalRegistros, out DateTime? menorData, out DateTime? maiorData, out decimal somaColuna)
        {
            totalRegistros = 0;
            menorData = null;
            maiorData = null;
            somaColuna = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Verificar e contar registros
                if (row.Cells[colunaDataIndex].Value != null && DateTime.TryParse(row.Cells[colunaDataIndex].Value.ToString(), out DateTime data))
                {
                    totalRegistros++;
                    if (menorData == null || data < menorData)
                    {
                        menorData = data;
                    }
                    if (maiorData == null || data > maiorData)
                    {
                        maiorData = data;
                    }
                }
                // Somar valores da coluna
                if (row.Cells[colunaValorIndex].Value != null && decimal.TryParse(row.Cells[colunaValorIndex].Value.ToString(), out decimal valor))
                {
                    somaColuna += valor;
                }
            }
        }
        //
        // somar coluna especifica DatagridView
        //
        public static decimal SomarColuna(DataGridView dataGridView, int colunaIndex)
        {
            decimal soma = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[colunaIndex].Value != null && decimal.TryParse(row.Cells[colunaIndex].Value.ToString(), out decimal valor))
                {
                    soma += valor;
                }
            }
            return soma;
        }

        // Você pode adicionar outros métodos de configuração comuns aqui


    } // end class
} // end namespace
