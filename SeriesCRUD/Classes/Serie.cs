using SeriesCRUD.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesCRUD.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private string Ano { get; set; }
        public int Temporadas { get; set; }

        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, string ano, int temporadas)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Temporadas = temporadas;
            Excluido = false;
        }
        public string GetTitulo()
        {
            return Titulo;
        }

        public int GetId()
        {
            return Id;
        }

        public bool GetExcluido()
        {
            return Excluido;
        }

        public void Excluir()
        {
            Excluido = true;
        }

        public override string ToString()
        {
            return $"Nome: {Titulo}\nDescrição: {Descricao}\nAno: {Ano}\nGênero: {Genero}\nTemporadas: {Temporadas}";
        }

    }
}
