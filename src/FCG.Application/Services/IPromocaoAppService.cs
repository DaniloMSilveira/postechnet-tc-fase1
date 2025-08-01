using FCG.Application.DTOs.Inputs.Promocoes;
using FCG.Application.DTOs.Outputs;
using FCG.Application.DTOs.Outputs.Promocoes;
using FCG.Application.DTOs.Queries.Promocoes;

namespace FCG.Application.Services
{
    public interface IPromocaoAppService
    {
        Task<PaginacaoOutput<PromocaoItemListaOutput>> PesquisarPromocoes(PesquisarPromocoesQuery query);
        Task<PromocaoOutput?> ObterPorId(Guid id);
        Task<BaseOutput<PromocaoOutput>> Criar(CriarPromocaoInput input);
        Task<BaseOutput<PromocaoOutput>> Alterar(AlterarPromocaoInput input);
        Task<BaseOutput<bool>> Ativar(Guid id);
        Task<BaseOutput<bool>> Inativar(Guid id);
        Task<BaseOutput<bool>> Remover(Guid id);
    }
}