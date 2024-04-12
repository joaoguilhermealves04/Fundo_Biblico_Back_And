using FundoBiblico.Aplication.Helper;
using FundoBiblico.Aplication.IServicos;
using FundoBiblico.Dominio.Entity;
using FundoBiblico.Dominio.Interfaces;
using FundoBiblico.Dominio.Models;

namespace FundoBiblico.Aplication.Servicos
{
    public class IgrejaServicos : IIgrejaServicos
    {
        private readonly IIgrejaRepository _igrejaRepository;
        private readonly ValidacaoDosDadosHelper _validarDados;
        public IgrejaServicos(IIgrejaRepository igrejaRepository, ValidacaoDosDadosHelper validacao)
        {
            _igrejaRepository = igrejaRepository;
            _validarDados = validacao;
        }

        public async Task Atualizar(IgrejaAddEditarModel igrejaModel)
        {
            try
            {
                var igreja = _igrejaRepository.ObterPorId(igrejaModel.Id);

                if (igreja is null)
                    throw new Exception("Igreja não encontrada");

                igreja.Result.AtualizarEntidadeIgreja(igrejaModel.Nome, igrejaModel.UF, igrejaModel.Setor);

                _igrejaRepository.Atualizar(igreja.Result);
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
                if (_validarDados.IgrejaExiste(igreja.Nome))
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

                var resultado = new IgrejaModel
                {
                    Id = igreja.Id,
                    Nome = igreja.Nome,
                    UF = igreja.UF,
                    Setor = igreja.Setor,
                    DataCadastro = igreja.DataCadastro
                };

                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar a igreja no banco.", ex);
            }
        }

        public Task Remover(Guid? id)
        {
            try
            {
                var igrejaParaRemver = _igrejaRepository.ObterPorId(id);
                _igrejaRepository.Remover(igrejaParaRemver.Result);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover a igreja.", ex);
            }
        }
    }
}
