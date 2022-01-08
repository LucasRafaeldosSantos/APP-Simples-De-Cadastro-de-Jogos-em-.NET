using System;
using System.Collections.Generic;
using DIO.AppCadastro.Interfaces;

namespace DIO.AppCadastro
{
    public class JogosRepositorio : IRepositorio<Jogos>
    {
        private List<Jogos> ListaJogos = new List<Jogos>();
        public void Atualiza(int id, Jogos objeto)
        {
            ListaJogos[id] = objeto;
        }

        public void Exclui(int id)
        {
            ListaJogos[id].Excluir();
        }

        public void Insere(Jogos objeto)
        {
            ListaJogos.Add(objeto);
        }

        public List<Jogos> Lista()
        {
            return ListaJogos;
        }

        public int ProximoId()
        {
            return ListaJogos.Count;
        }

        public Jogos RetornarPorId(int id)
        {
            return ListaJogos[id];
        }
    }
}