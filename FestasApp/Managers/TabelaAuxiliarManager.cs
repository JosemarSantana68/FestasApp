//------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do módulo: 12/07/2024
//   Ultima Alteração: 12/07/2024
//   
//   Classe TabelaAuxiliarManager
//
//------------------------------------------------------------
//

namespace FestasApp.Managers
{
    public class TabelaAuxiliarManager
    {
        /// <summary>
        /// construtor padrão
        /// </summary>
        public TabelaAuxiliarManager() 
        {

        }

        /// <summary>
        /// Lista com nomes das Tabelas Auxiliares
        /// </summary>
        public readonly List<string> tabelasAuxiliares = new List<string>
        {
            "Itens das Festas",
            "Espaços",
            "Contratos",
            "Pacotes",
            "Status",
            "Temas",
            "Tipo de Eventos"
        };
        /// <summary>
        /// método que retorna true ou flase se o nome da tabela está selecionada no dtgTabelas
        /// </summary>
        /// <param name="tabela"></param>
        /// <param name="form"></param>
        /// <param name="dtgTabelas"></param>
        /// <returns></returns>
        public bool IsTabelaSelecionada(string tabela, FormAuxiliaresMain? form = null, DataGridView? dtgTabelas = null)
        {
            dtgTabelas ??= form?.dtgTabelasAuxiliares;

            if (dtgTabelas == null || dtgTabelas.SelectedRows.Count == 0) return false;

            DataGridViewRow selectedRow = dtgTabelas.SelectedRows[0];
            var tabelaSelecionada = selectedRow.Cells[0].Value.ToString();
            return tabelaSelecionada == tabela;
        }
        //
        public bool IsTabelaItensFestasSelecionada(DataGridView dtgTabelas)
        {
            return IsTabelaSelecionada("Itens das Festas", null, dtgTabelas);
        }
        //
        public bool IsTabelaEspacosSelecionada(DataGridView dtgTabelas)
        {
            return IsTabelaSelecionada("Espaços", null, dtgTabelas);
        }
        //
        public bool IsTabelaContratosSelecionada(DataGridView dtgTabelas)
        {
            return IsTabelaSelecionada("Contratos", null, dtgTabelas!);
        }
        //
        public bool IsTabelaPacotesSelecionada(DataGridView dtgTabelas)
        {
            return IsTabelaSelecionada("Pacotes", null, dtgTabelas!);
        }
        //
        public bool IsTabelaStatusSelecionada(DataGridView dtgTabelas)
        {
            return IsTabelaSelecionada("Status", null, dtgTabelas!);
        }
        //
        public bool IsTabelaTemasSelecionada(DataGridView dtgTabelas)
        {
            return IsTabelaSelecionada("Temas", null, dtgTabelas!);
        }
        //
        public bool IsTabelaTipoEventosSelecionada(DataGridView dtgTabelas)
        {
            return IsTabelaSelecionada("Tipo de Eventos", null, dtgTabelas!);
        }

        // Adicione mais métodos conforme necessário para outras tabelas

    } // end class TabelaAuxiliarManager
} // end namespace FestasApp.Managers
