using System.Collections.Generic;
using System.Threading.Tasks;
using RollOff.Models.Domain;
using RollOff.Models.DTO;

namespace RollOff.Services
{
    public interface IRolloffFormService
    {
        Task<bool> SaveRollOffForm(RollOffTransactionDto rollOffTransactionDto);
        Task<RollOffTransaction> GetRollOffFormByEmpId(int employeeId);
        Task<List<PSPTransaction>> GetRollOffFormList();
        Task<bool> SaveTransfered(TransferedFromDto transferedFromDto);
        Task<List<PSPTransaction>> GetTransferedList();
        Task<bool> UpdateTransfered(TransferedFromDto transferedFromDto);
    }
}
