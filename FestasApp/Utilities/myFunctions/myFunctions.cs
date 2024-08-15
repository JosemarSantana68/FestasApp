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
        /// <summary>
        /// obtém os tamanhos dos campos nas tabelas, para determinar MaxLenght do TextBoxes
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static int GetMaxLength(string tableName, string columnName)
        {
            try
            {
                using (MySqlConnection connection = new(myConnMySql.strConnMySql))
                {
                    connection.Open();

                    string query = $@"
                    SELECT CHARACTER_MAXIMUM_LENGTH
                    FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_NAME = @tableName AND COLUMN_NAME = @columnName";

                    using (MySqlCommand command = new(query, connection))
                    {
                        command.Parameters.AddWithValue("@tableName", tableName);
                        command.Parameters.AddWithValue("@columnName", columnName);

                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            //return Convert.ToInt32(result);

                            int maxLength = Convert.ToInt32(result);
                            return maxLength == -1 ? int.MaxValue : maxLength;
                        }
                    }
                }
            }
            catch (Exception) { }

            return int.MaxValue; // Retorna int.MaxValue para tipos que não têm tamanho, como int, date, etc.
        }
        //
        /// <summary>
        /// configurar e /ou adicionar colunas de datagriviews
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="colIndex"></param>
        /// <param name="headerText"></param>
        /// <param name="width"></param>
        /// <param name="name"></param>
        /// <param name="alignment"></param>
        /// <param name="padding"></param>
        /// <param name="visible"></param>
        //
        public static void ConfigurarAdicionarColuna(
                                    DataGridView dtg,
                                    int colIndex,
                                    string headerText,
                                    int width,
                                    string? name = null,
                                    DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft,
                                    Padding? padding = null,
                                    bool visible = true
                                    )
        {

            // Verifique se a coluna já existe
            if (dtg.Columns.Count > colIndex)
            {
                // configura coluna existente
                dtg.Columns[colIndex].Name = !string.IsNullOrEmpty(name) ? name : headerText; // nome
                dtg.Columns[colIndex].HeaderText = headerText; // cabeçalho
                dtg.Columns[colIndex].Width = width; // largura
                dtg.Columns[colIndex].DefaultCellStyle.Alignment = alignment; // alinhamento
                if (padding.HasValue)
                    dtg.Columns[colIndex].DefaultCellStyle.Padding = padding.Value; // padding
                dtg.Columns[colIndex].Visible = visible; // visível
            }
            else
            {
                // Adiciona uma nova coluna se não existir
                var col = new DataGridViewTextBoxColumn
                {
                    Name = !string.IsNullOrEmpty(name) ? name : headerText, // nome
                    HeaderText = headerText,
                    Width = width,
                    DefaultCellStyle = { Alignment = alignment },
                    Visible = visible
                };
                if (padding.HasValue)
                {
                    col.DefaultCellStyle.Padding = padding.Value;
                }
                // insere a coluna
                dtg.Columns.Insert(colIndex, col);
            }
        }
        //
        //****************************************************************************************
        //
        /// <summary>
        /// estatisticas em DataGridViews, Total de Registros, Datas max e min, e Soma de Colunas
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="colunaDataIndex"></param>
        /// <param name="colunaValorIndex"></param>
        /// <param name="totalRegistros"></param>
        /// <param name="menorData"></param>
        /// <param name="maiorData"></param>
        /// <param name="somaColuna"></param>
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
        /// <summary>
        /// somar coluna especifica DatagridView
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="colunaIndex"></param>
        /// <returns></returns>
        public static decimal SomarColunaSEMUSO(DataGridView dataGridView, int colunaIndex)
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
        //  
        /// <summary>
        /// popula comboboxes com id e nome de tabelas, retorna DataTable
        /// </summary>
        /// <param name="tabela"></param>
        /// <param name="campoId"></param>
        /// <param name="campoNome"></param>
        /// <returns></returns>
        public static DataTable GetDataComboBoxSEMUSO(string tabela, string campoId, string campoNome)
        {
            DataTable dt = new();
            // Consulta SQL para selecionar os dados das tabelas
            string sql = $" SELECT {campoId}, {campoNome} FROM {tabela}";
            try
            {
                using (MySqlConnection cn = new(myConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlDataAdapter da = new(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                FormMenuMain.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}", "Erro MySql");
                //return null; // Retorna null em caso de erro
            }
            catch (Exception ex)
            {
                FormMenuMain.ShowMyMessageBox($"Erro ao obter dados do banco de dados: {ex.Message}\nGetDataComboBox", "Carregar ComboBoxe");
                //return null; // Retorna null em caso de erro
            }
            // Retorna DataTable
            return dt;
        }
        //
        /// <summary>
        /// configurar colunas de datagriviews
        /// </summary>
        /// <param name="dtg"></param>
        /// <param name="colIndex"></param>
        /// <param name="headerText"></param>
        /// <param name="width"></param>
        /// <param name="alignment"></param>
        /// <param name="padding"></param>
        /// <param name="visible"></param>
        public static void ConfigurarColunaSEMUSO(
                            DataGridView dtg,
                            int colIndex,
                            string headerText,
                            int width,
                            DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft,
                            Padding? padding = null,
                            bool visible = true
                            )
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

        // adicionar outros métodos de configuração comuns aqui

    } // end class
} // end namespace
