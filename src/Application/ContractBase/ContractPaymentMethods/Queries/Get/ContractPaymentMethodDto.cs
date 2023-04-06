using ContractMng.Domain.Entities;
using ContractMng.Application.Common.Mappings;



namespace ContractMng.Application.ContractBase.ContractPaymentMethods.Queries.Get;

public class ContractPaymentMethodDto : IMapFrom<ContractPaymentMethod>
{
    public int Id { get; set; }

    public string Method { get; set; }

}
