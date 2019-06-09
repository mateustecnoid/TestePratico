'use strict';
(function () {
    function AtualizarPacienteController(PacienteService, $state, $stateParams) {
        var vm = this;
        //Inicialização de variáveis
        var codigo = $stateParams.codigo;        
        vm.paciente = {};

        //Registrando funções no escopo       
        vm.atualizar = atualizar;

        //Funções executadas ao iniciar o controlador        
        recuperar();

        // Declaração de funções
        function recuperar(){
            PacienteService.buscarPaciente(codigo).then(function(){
                vm.paciente = PacienteService.paciente
                console.log("vm.paciente", vm.paciente);
            })
        }

        function atualizar() {
            PacienteService.atualizarPaciente(vm.paciente).then(function () {
                $state.go("app.paciente");
            });
        }
    };

    // Registrando o controlador no módulo
    angular.module('TestePratico').controller('AtualizarPacienteController', AtualizarPacienteController);
})();
