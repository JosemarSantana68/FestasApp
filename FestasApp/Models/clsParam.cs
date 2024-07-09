//***************************************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 06/07/2024
//   Ultima Alteração: 06/07/2024
//   
//   CLASSE clsParam para auxiliar na passagem de parametros entre forms
//  
//***************************************************************************

namespace FestasApp.Models
{
    /// <summary>
    /// Classe auxiliar para passagem de parâmetros entre formulários.
    /// </summary>
    public class clsParam
    {
        /// <summary>
        /// Identificador único do cliente.
        /// </summary>
        public int? Id { get; set; }

        // Construtores
        public clsParam() { }

        public clsParam(int? id)
        {
            Id = id;
        }

        // Validação
        public bool IsValid()
        {
            // Permite que o Id seja nulo ou maior-igual que 0
            return !Id.HasValue || Id.Value >= 0;
        }
    }
}

