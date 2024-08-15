//-------------------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do Módulo: 09/08/2024
//   Ultima Alteração: 09/08/2024 comentário: Validações de DataAnnotation
//   
//   CLASSE DE VALIDAÇÃO DE OBJETOS
//
//-------------------------------------------------------------------------

namespace FestasApp.ViewModels
{
    /// <summary>
    /// Classe auxiliar para validações de objetos
    /// </summary>
    public class clsValidator
    {
        /// <summary>
        /// Valida objetos com Data Annotation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IEnumerable<ValidationResult> isValidObject(object obj)
        {
            var validacao = new List<ValidationResult>();
            var context = new ValidationContext(obj, null, null);

            Validator.TryValidateObject(obj, context, validacao, true);

            return validacao;
        }

    } // public class clsValidator
} // end namespace FestasApp.ViewModels
