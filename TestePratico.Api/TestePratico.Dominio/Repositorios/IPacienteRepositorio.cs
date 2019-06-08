using System;
using System.Collections.Generic;
using System.Text;
using TestePratico.Dominio.Entidades;

namespace TestePratico.Dominio.Repositorios
{
    public interface IPacienteRepositorio
    {
        void Inserir(Paciente paciente);
        void Atualizar(Paciente paciente);
        void Excluir(Paciente paciente);
        Paciente Recuperar(int codigo);
        IEnumerable<Paciente> Recuperar(int? codigoPaciente, string nome, DateTime? dataNascimento);
    }
}
