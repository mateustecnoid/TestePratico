'use strict';
(function () {
    function PacienteController(NgTableParams, PacienteService) {
        var vm = this;
        //Inicialização de variáveis
        vm.filtro = {};

        //Registrando funções no escopo
        vm.pesquisar = pesquisar;
        vm.excluir = excluir;

        //Funções executadas ao iniciar o controlador
        vm.TabelaPacientes = new NgTableParams({}, {
            getData: function (params) {
                return PacienteService.buscarPacientes(vm.filtro).then(function () {
                    var pacientes = PacienteService.pacientes;
                    return pacientes;
                })
            }
        });

        // Declaração de funções        
        function pesquisar() {
            vm.TabelaPacientes.reload();
        }

        function excluir(codigo){
            PacienteService.excluirPaciente(codigo).then(function(){
                pesquisar();
            })
        }
    };

    // Registrando o controlador no módulo
    angular.module('TestePratico').controller('PacienteController', PacienteController);
})();
