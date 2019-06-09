'use strict';
(function () {
    function CadastrarAgendamentoController(PacienteService, AgendamentoService, $state) {
        var vm = this;

        //Inicialização de variáveis
        vm.agendamento = {};
        vm.pacientes = [];


        //Registrando funções no escopo
        vm.inserir = inserir;

        //Funções executadas ao iniciar o controlador        
        buscarPacientes();

        // Declaração de funções
        function inserir() {
            AgendamentoService.inserirAgendamento(vm.agendamento).then(function () {
                $state.go("app.agendamento")
            });
        }

        function buscarPacientes() {
            PacienteService.buscarPacientes(vm.filtro).then(function () {
                vm.pacientes = PacienteService.pacientes;
                console.log("vm.pacientes", vm.pacientes);
            });
        }
    };

    // Registrando o controlador no módulo
    angular.module('TestePratico').controller('CadastrarAgendamentoController', CadastrarAgendamentoController);
})();
