using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private IRepositoryBase<Pokemon> _repository { get; set; }
        public PokemonService(IRepositoryBase<Pokemon> repository)
        {
            _repository = repository;
        }

        private void ValidarDados(Pokemon pokemon)
        {
            if (string.IsNullOrEmpty(pokemon.Name))
            {
                throw new ArgumentNullException(nameof(pokemon.Name), "Nome não pode estar vazio.");
            }

            if (string.IsNullOrEmpty(pokemon.Type))
            {
                throw new ArgumentNullException(nameof(pokemon.Type), "Tipo não pode estar vazio.");
            }

            if (string.IsNullOrEmpty(pokemon.Gender))
            {
                throw new ArgumentNullException(nameof(pokemon.Gender), "Genero nao pode estar vazio.");
            }
        }

        public void Criar(Pokemon pokemon)
        {
            ValidarDados(pokemon);

            _repository.Save(pokemon);
            _repository.SaveChanges();
        }

        public void Editar(Pokemon pokemon)
        {
            var dadosAntigos = _repository.Query(x => x.Id == pokemon.Id).FirstOrDefault();

            if (dadosAntigos == null)
            {
                throw new ArgumentException("Pokemon não encontrado");
            }
            Pokemon dadosAtualizados = new Pokemon();
            dadosAtualizados.Id = dadosAntigos.Id;

            dadosAtualizados.Name = (pokemon.Name != null) ? pokemon.Name : dadosAntigos.Name;
            dadosAtualizados.Type = (pokemon.Type != null) ? pokemon.Type : dadosAntigos.Type;
            dadosAtualizados.Gender = (pokemon.Gender != null) ? pokemon.Gender : dadosAntigos.Gender;

            _repository.Update(dadosAtualizados);
            _repository.SaveChanges();
        }

        public void Deletar(int id)
        {
            var dadosAntigos = _repository.Query(x => x.Id == id).FirstOrDefault();

            if (dadosAntigos == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public Pokemon BuscarPorId(int id)
        {
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Pokemon> BuscarLista()
        {
            return _repository.Query(x => 1 == 1).ToList();
        }
    }
}
