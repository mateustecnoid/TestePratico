angular.module('TestePratico', ['ui.bootstrap', 'ui.router', 'ngTable'])
    .constant('UrlApi', {
        //URL Local:
        UrlApi: "http://localhost/TestePratico.Api/api/"
    })
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/app');
        $stateProvider
            .state('app', {
                url: '/app',
                template: '<ui-view></ui-view>',
                controller: 'AppController',
                controllerAs: 'vm'
            })
            .state('app.inicio', {
                url: '/inicio',
                templateUrl: 'app/inicio/inicio.html',
                controller: 'InicioController',
                controllerAs: 'vm'
            })
            .state('app.paciente', {
                url: '/paciente',
                templateUrl: 'app/paciente/paciente.html',
                controller: 'PacienteController',
                controllerAs: 'vm'
            })
            .state('app.cadastrar-paciente', {
                url: '/cadastrar-paciente',
                templateUrl: 'app/paciente/cadastrar.html',
                controller: 'CadastrarPacienteController',
                controllerAs: 'vm'
            })
            .state('app.atualizar-paciente', {
                url: '/atualizar-paciente/:codigo',
                templateUrl: 'app/paciente/atualizar.html',
                controller: 'AtualizarPacienteController',
                controllerAs: 'vm'
            })
            .state('app.agendamento', {
                url: '/agendamento',
                templateUrl: 'app/agendamento/agendamento.html',
                controller: 'AgendamentoController',
                controllerAs: 'vm'
            })
            .state('app.cadastrar-agendamento', {
                url: '/cadastrar-agendamento',
                templateUrl: 'app/agendamento/cadastrar.html',
                controller: 'CadastrarAgendamentoController',
                controllerAs: 'vm'
            })
            .state('app.atualizar-agendamento', {
                url: '/atualizar-agendamento/:codigo',
                templateUrl: 'app/agendamento/atualizar.html',
                controller: 'AtualizarAgendamentoController',
                controllerAs: 'vm'
            });
    })