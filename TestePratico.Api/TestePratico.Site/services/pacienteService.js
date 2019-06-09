'use strict';
(function () {
    function PacienteService($http, UrlApi) {
        var url = UrlApi.UrlApi + "paciente";

        var service = {
            buscarPacientes: buscarPacientes,
            buscarPaciente: buscarPaciente,
            inserirPaciente: inserirPaciente,
            atualizarPaciente: atualizarPaciente,
            excluirPaciente: excluirPaciente,
            paciente: {},
            pacientes: []
        };

        function buscarPacientes(request) {
            request.dataNascimento ? request.dataNascimento.toJSON() :'' 
            return $http.get(url, { params: request }).then(function (resposta) {
                service.pacientes = resposta.data;
            });
        };

        function buscarPaciente(codigo) {
            return $http.get(url + "/" + codigo).then(function (resposta) {
                service.paciente = resposta.data;
            });
        };

        function inserirPaciente(request) {
            return $http.post(url, request).then(function () {
            });
        };

        function atualizarPaciente(request) {
            return $http.put(url, request).then(function () {
            });
        }

        function excluirPaciente(codigo) {
            return $http.delete(url + "/" + codigo).then(function () {
            });
        }

        return service;
    }
    angular.module('TestePratico').factory("PacienteService", PacienteService);
})();