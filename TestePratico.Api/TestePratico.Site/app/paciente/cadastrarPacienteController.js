'use strict';
(function () {
    function CadastrarPacienteController(PacienteService, $state) {
        var vm = this;
        //Inicialização de variáveis
        vm.paciente = {};

        //Registrando funções no escopo
        vm.inserir = inserir;

        //Funções executadas ao iniciar o controlador        

        // Declaração de funções
        function inserir(){
            PacienteService.inserirPaciente(vm.paciente).then(function(){
                $state.go("app.paciente");
            });
        }
    };

    // Registrando o controlador no módulo
    angular.module('TestePratico').controller('CadastrarPacienteController', CadastrarPacienteController);
})();
