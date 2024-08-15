//-----------------------------------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 09/08/2024
//   Ultima Alteração: 09/08/2024
//   
//   CLASSE ClientesViewModel responsável por lidar com a lógica de apresentação relacionada aos clientes.
//   interage com o repositório para carregar dados e expô-los de maneira mais adequada para a interface do usuário.
//  
//-----------------------------------------------------------------------------------------
//

namespace FestasApp.ViewModels
{
    /// <summary>
    /// Classe ClienteViewModel
    /// </summary>
    public class ClientesViewModel : INotifyPropertyChanged
    {
        //Propriedades e Instâncias da Calsse
        // declara um instância do repositório
        private readonly repClientesEF _repClientes;
        //
        public ObservableCollection<clsClientes> Clientes { get; private set; }
        public ObservableCollection<string> ErrosValidacao { get; private set; } = new ObservableCollection<string>();
        public ObservableCollection<clsFestas> FestasDoCliente { get; set; }
        //
        // Propriedade ClienteSelecionado
        private clsClientes? _clienteSelecionado;
        // Campo _clienteSelecionado
        public clsClientes? ClienteSelecionado
        {
            get => _clienteSelecionado;
            set
            {
                _clienteSelecionado = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public ClientesViewModel()
        {
            // inicializa a nova instância do repositórioClientes
            _repClientes = new repClientesEF();

            // inicializa um novo objeto Clientes e carrega uma lista com dados dos clientes
            Clientes = new ObservableCollection<clsClientes>(_repClientes.GetClientesEF());

            // inicializa o objeto da instância, para receber as festas do cliente
            FestasDoCliente = new ObservableCollection<clsFestas>();
        }



        /// <summary>
        /// Captura um cliente por id
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        public clsClientes? GetCliente(int clienteId)
        {
            /*  GetCliente que primeiro tenta encontrar o cliente na lista Clientes que foi carregada
             *  na inicialização. Se ele não encontrar o cliente na lista, ele faz uma chamada
             *  ao repositório para buscar o cliente diretamente no banco de dados. */

            // chamada resumida
            //return Clientes.FirstOrDefault(c => c.cli_id == clienteId) ?? _repClientes.GetCliente(clienteId);

            // abordagem mais completa
            // Tenta encontrar o cliente na lista carregada
            var cliente = Clientes.FirstOrDefault(c => c.cli_id == clienteId);

            // Se o cliente não estiver na lista carregada, busca no banco de dados
            if (cliente == null)
            {
                cliente = _repClientes.GetCliente(clienteId);

                // Opcionalmente, adicionar o cliente carregado na lista de clientes, se desejado
                if (cliente != null)
                    Clientes.Add(cliente);

            }
            // atualiza cliente selecionado
            ClienteSelecionado = cliente;
            return cliente;
        }
        /// <summary>
        /// Valida o Cliente Atual
        /// </summary>
        /// <param name="clienteAtual"></param>
        /// <returns></returns>
        public bool ValidarCliente(clsClientes clienteAtual)
        {
            var erros = clsValidator.isValidObject(clienteAtual);
            
            // Limpa a coleção de erros anterior
            ErrosValidacao.Clear();

            // Se houver erros, armazena-os e retorna false
            if (erros.Any())
            {
                // Poderia também armazenar os erros em uma propriedade para exibição na View
                // ou tratar de outra forma conforme a necessidade.
                foreach (var erro in erros)
                {
                    // Trate cada erro ou armazene em uma lista de erros para exibir na View
                    // Por exemplo, adicionar a uma lista ObservableCollection<string> Erros para a View.
                    
                    ErrosValidacao.Add(erro.ErrorMessage!);
                    
                    Console.WriteLine(erro.ErrorMessage);
                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// Retorna as festas relacionadas ao cliente.
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        public ObservableCollection<clsFestas> ObterFestasPorCliente(int clienteId)
        {
            using (var context = new clsFestasContext())
            {
                var festas = context.Festas
                    .Include(f => f.TipoEvento)
                    .Include(f => f.Pacote)
                    .Include(f => f.Tema)
                    .Include(f => f.Espaco)
                    .Include(f => f.Status)
                    .Where(f => f.fest_cli_id == clienteId)
                    .ToList();

                return new ObservableCollection<clsFestas>(festas);
            }
        }
        /// <summary>
        /// Salvar cliente em ClientesViewModel
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool SaveCliente(clsClientes cliente)
        {
            int cliId = cliente.cli_id;

            bool sucesso = _repClientes.SaveCliente(cliente);
            //
            if (sucesso)
            {
                if (cliId > 0) // EDITA
                {
                    // Atualiza a lista existente
                    int index = Clientes.IndexOf(cliente);
                    if (index >= 0)
                        Clientes[index] = cliente;
                }
                else // NOVO
                {
                    // Adiciona um novo cliente a lista
                    Clientes.Add(cliente);
                }
                // Recarregar a lista de clientes do repositório
                Clientes = new ObservableCollection<clsClientes>(_repClientes.GetClientesEF());
                ClienteSelecionado = cliente;
            }
            return sucesso;
        }

        /// <summary>
        /// Deletar cliente em ClientesViewModel
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool DeleteCliente(clsClientes cliente)
        {
            bool sucesso = _repClientes.DeleteClienteEF(cliente);
            if (sucesso)
            {
                Clientes.Remove(cliente);
            }
            return sucesso;
        }

        /*  PropertyChanged: É um evento definido pela interface INotifyPropertyChanged. 
         *  Esse evento é disparado sempre que o valor de uma propriedade do ViewModel muda. 
         *  A View pode se inscrever nesse evento para ser notificada e, 
         *  assim, atualizar a interface automaticamente quando os dados mudam. */

        /// <summary>
        /// Evento PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /*  OnPropertyChanged([CallerMemberName] string propertyName = null): 
         *  Esse é um método protegido que você chama quando uma propriedade muda de valor. 
         *  O parâmetro propertyName é o nome da propriedade que mudou, 
         *  e ele usa o atributo [CallerMemberName] para capturar automaticamente o nome da propriedade 
         *  que invocou o método, caso você não o passe explicitamente. */

        /// <summary>
        /// Método OnPropertyChanged
        /// </summary>
        /// <param name="propertyName"> Nome da propriedade que mudou, capturado automaticamente se não for fornecido.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) // CS8625
        {
            /* Aqui, o evento PropertyChanged é disparado com o nome da propriedade que foi alterada,
             * alertando a View sobre a mudança. Se propertyName for nulo, um valor vazio será usado no lugar. */

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? string.Empty));
        }

        /*  Aplicação Prática
         *  Data Binding: No MVVM, a View normalmente se vincula (bind) a propriedades no ViewModel. 
         *  Quando a propriedade ClienteSelecionado muda, o método OnPropertyChanged é chamado, 
         *  disparando o evento PropertyChanged. Isso notifica a View para que ela atualize automaticamente
         *  a interface do usuário, refletindo o novo valor de ClienteSelecionado.
         *
         *  Interatividade Dinâmica: Suponha que a View tenha um formulário que exibe detalhes do cliente. 
         *  Quando o usuário seleciona um cliente diferente na lista, a propriedade ClienteSelecionado é atualizada. 
         *  Isso aciona o evento PropertyChanged, e a View se atualiza para exibir os detalhes do 
         *  novo cliente selecionado sem a necessidade de código adicional para manipular a interface.
         *
         *  Esse padrão é uma parte essencial do MVVM, pois permite uma separação clara entre a lógica de 
         *  apresentação e a interface do usuário, facilitando o desenvolvimento, manutenção e testes do aplicativo. */
        
        /// <summary>
        /// Método para testar a conexão em repClientes.
        /// </summary>
        /// <returns></returns>
        public bool TestarConexao()
        {
            return _repClientes.TestarConexao();
        }
        //

    } // end class ClientesViewModel : INotifyPropertyChanged
} // end namespace FestasApp.ViewModels

