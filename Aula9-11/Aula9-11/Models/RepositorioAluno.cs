using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula9_11.Models
{
    public class RepositorioAluno
    {
        private static List<Aluno> listaAlunos = new List<Aluno>();

        public void Adicionar(Aluno aluno)
        {
            listaAlunos.Add(aluno);
        }

        public List<Aluno> Listar()
        {
            return listaAlunos;
        }

        public void Editar(string guid, Aluno aluno)
        {
            var alunoBuscado = listaAlunos.Find(a => a.Id == guid);

            if (alunoBuscado != null)
            {
                Remover(guid);
                Adicionar(aluno);
            }
        }

        public void Remover(string guid)
        {
            var aluno = listaAlunos.Find(a => a.Id == guid);

            if (aluno != null)
            {
                listaAlunos.Remove(aluno);
            }
        }

        public Aluno Buscar(string guid)
        {
            return listaAlunos.Find(a => a.Id == guid);
        }
    }
}