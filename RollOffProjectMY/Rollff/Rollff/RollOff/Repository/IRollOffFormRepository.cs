using System.Collections.Generic;
using System.Threading.Tasks;
using RollOff.Models.Domain;

namespace RollOff.Repository
{
    public interface IRollOffFormRepository
    {
        Task<bool> SaveRollOffForm(RollOffTransaction rollOffTransaction, int roleType);
        Task<RollOffTransaction> GetRollOffFormByEmpId(int employeeId);
        Task<List<PSPTransaction>> GetRollOffFormList();
        Task<bool> SaveTransfered(TransferedFrom transferedFrom);
        Task<bool> UpdateTransfered(TransferedFrom transferedFrom);
        Task<List<TransferedFrom>> GetTransfered();
    }
}
