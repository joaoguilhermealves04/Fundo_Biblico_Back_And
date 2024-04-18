using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Aplication.Models;
using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;

namespace FundoBiblico.Aplication.Servicos
{
    public class IgrejaServicos : IIgrejaServicos
    {
        private readonly IIgrejaRepository _igrejaRepository;
        public IgrejaServicos(IIgrejaRepository igrejaRepository)
        {
            _igrejaRepository = igrejaRepository;
        }

        public async Task Atualizar(IgrejaAddEditarModel igrejaModel)
        {
            try
            {
                var igreja = await _igrejaRepository.ObterPorId(igrejaModel.Id);

                if (igreja is null)
                    throw new Exception("Igreja não encontrada");

                igreja.AtualizarEntidadeIgreja(igrejaModel.Nome, igrejaModel.UF, igrejaModel.Setor);

                _igrejaRepository.Atualizar(igreja);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar os dados da igreja", ex);
            }
        }

        public async Task CadastroIgreja(IgrejaAddEditarModel igreja)
        {
            try
            {
                var igrejaValidar =  _igrejaRepository.ObterPorId(igreja.Id);
                if (igreja != null)
                    throw new Exception("Essa Igreja já existe na base de Dados");


                var InserirIgreja = new Igreja(igreja.Nome, igreja.UF, igreja.Setor);

                await _igrejaRepository.Adicionar(InserirIgreja);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Cadastar Igreja", ex);
            }
        }

        public async Task<IEnumerable<IgrejaModel>> ObterIgrejas()
        {
            try
            {
                var todosIgrejas = await _igrejaRepository.ObterTodos();

                var resultado = new List<IgrejaModel>();
                foreach (var i in todosIgrejas)
                {
                    var igrejaModel = new IgrejaModel
                    {
                        Id = i.Id,
                        Nome = i.Nome,
                        UF = i.UF,
                        Setor = i.Setor,
                        DataCadastro = i.DataCadastro
                    };
                    resultado.Add(igrejaModel);
                }
                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar as igrejas no banco.", ex);
            }

        }

        public async Task<IgrejaModel> ObterIgreja(Guid? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    throw new Exception("O Id não pode ser nullo");
                }
                var igreja = await _igrejaRepository.ObterPorId(id.Value);

                return new IgrejaModel
                {
                    Id = igreja.Id,
                    Nome = igreja.Nome,
                    UF = igreja.UF,
                    Setor = igreja.Setor,
                    DataCadastro = igreja.DataCadastro
                };

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar a igreja no banco.", ex);
            }
        }

        public async Task Remover(Guid id)
        {
            try
            {
                var igreja = await _igrejaRepository.ObterPorId(id);
               await _igrejaRepository.Remover(igreja);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover a igreja.", ex);
            }
        }

        public async Task<IgrejaModel> ObterIgrejaPorNome(string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome))
                {
                    throw new Exception("O Nome da Igreja não pode ser nulo, Por favor digite um nome.");

                }

                var igreja = await _igrejaRepository.ObterPorNome(nome);

                if( igreja == null)
                {
                    throw new Exception("Igreja não existe na base de Dados!");
                }

                return new IgrejaModel
                {
                    Id = igreja.Id,
                    Nome = igreja.Nome,
                    UF = igreja.UF,
                    Setor = igreja.Setor,
                    DataCadastro = igreja.DataCadastro
                };

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao consulta igreja pelo nome {nome}",ex);
            }
        }
    }
}
