angular.module('TestePratico', ['ui.bootstrap', 'ui.router'])
    .constant('UrlApi', {
        //URL Local:
        UrlApi: "http://localhost/TestePratico.Api/api/"
    })

    .config(function ($stateProvider, $urlRouterProvider, $httpProvider, $compileProvider) {
        $urlRouterProvider.otherwise('/inicio');
        $stateProvider
            .state('inicio', {
                url: '/inicio',
                templateUrl: 'app/inicio/inicio.html',
                controller: 'InicioController',
                controllerAs: 'vm'
            })
            .state('paciente', {
                url: '/paciente',
                templateUrl: 'app/paciente/paciente.html',
                controller: 'pacienteController',
                controllerAs: 'vm'
            })
            .state('agendamento', {
                url: '/agendamento',
                templateUrl: 'app/agendamento/agendamento.html',
                controller: 'agendamentoController',
                controllerAs: 'vm'
            });
    })