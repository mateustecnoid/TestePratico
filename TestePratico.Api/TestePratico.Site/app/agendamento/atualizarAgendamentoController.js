'use strict';
(function () {
    function AtualizarAgendamentoController(PacienteService, AgendamentoService, $state, $stateParams) {
        var vm = this;
        //Inicialização de variáveis
        var codigo = $stateParams.codigo;
        vm.agendamento = {};
        vm.pacientes = [];

        //Registrando funções no escopo
        vm.atualizar = atualizar;

        //Funções executadas ao iniciar o controlador        
        recuperar();
        buscarPacientes();

        // Declaração de funções
        function recuperar() {
            AgendamentoService.buscarAgendamento(codigo).then(function () {
                vm.agendamento = AgendamentoService.agendamento;
                console.log("vm.agendamento", vm.agendamento)
            })
        }

        function buscarPacientes() {
            PacienteService.buscarPacientes().then(function () {
                vm.pacientes = PacienteService.pacientes;
                console.log("vm.pacientes", vm.pacientes);
            });
        }

        function atualizar(){
            AgendamentoService.atualizarAgendamento(vm.agendamento).then(function(){
                $state.go("app.agendamento");
            });
        }
    };

    // Registrando o controlador no módulo
    angular.module('TestePratico').controller('AtualizarAgendamentoController', AtualizarAgendamentoController);
})();
