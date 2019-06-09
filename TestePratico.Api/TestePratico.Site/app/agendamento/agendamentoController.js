'use strict';
(function () {
    function AgendamentoController(NgTableParams, AgendamentoService, PacienteService) {
        var vm = this;
        //Inicialização de variáveis
        vm.filtro = {};
        vm.pacientes = [];

        //Registrando funções no escopo
        vm.pesquisar = pesquisar;
        vm.excluir = excluir;

        //Funções executadas ao iniciar o controlador
        buscarPacientes();

        vm.TabelaAgendamentos = new NgTableParams({}, {
            getData: function (params) {
                return AgendamentoService.buscarAgendamentos(vm.filtro).then(function () {
                    var agendamentos = AgendamentoService.agendamentos;
                    return agendamentos;
                })
            }
        });


        // Declaração de funções
        function pesquisar() {
            vm.TabelaAgendamentos.reload();
        }

        function excluir(codigo) {
            AgendamentoService.excluirAgendamento(codigo).then(function () {
                pesquisar();
            })
        }

        function buscarPacientes() {
            PacienteService.buscarPacientes(vm.filtro).then(function () {
                vm.pacientes = PacienteService.pacientes;
                console.log("vm.pacientes", vm.pacientes);
            });
        }
    };

    // Registrando o controlador no módulo
    angular.module('TestePratico').controller('AgendamentoController', AgendamentoController);
})();
