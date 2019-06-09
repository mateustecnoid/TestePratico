'use strict';
(function () {
    function AgendamentoService($http, UrlApi) {
        var url = UrlApi.UrlApi + "agendamento";

        var service = {
            buscarAgendamentos: buscarAgendamentos,
            buscarAgendamento: buscarAgendamento,
            inserirAgendamento: inserirAgendamento,
            atualizarAgendamento: atualizarAgendamento,
            excluirAgendamento: excluirAgendamento,
            agendamento: {},
            agendamentos: []
        };

        function buscarAgendamentos(request) {
            return $http.get(url, { params: request }).then(function (resposta) {
                service.agendamentos = resposta.data;
            });
        }

        function buscarAgendamento(codigo) {
            return $http.get(url + "/" + codigo).then(function (resposta) {
                service.agendamento = resposta.data;
            });
        }

        function inserirAgendamento(request) {
            return $http.post(url, request).then(function () {
            });
        }

        function atualizarAgendamento(request) {
            request.codigoPaciente = request.paciente.codigo
            return $http.put(url, request).then(function () {
            });
        }

        function excluirAgendamento(codigo) {
            return $http.delete(url + "/" + codigo).then(function () {
            });
        }


        return service;
    }
    angular.module('TestePratico').factory("AgendamentoService", AgendamentoService);
})();