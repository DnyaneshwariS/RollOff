using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RollOff.Data;
using RollOff.Models.Domain;
using RollOff.Models.Enum;

namespace RollOff.Repository
{
    public class RollOffFormRepository : IRollOffFormRepository
    {
        private IDbContextFactory<RollOffDBContext> _factory;

        public RollOffFormRepository(IDbContextFactory<RollOffDBContext> factory)
        {
            _factory = factory;
        }

        public async Task<bool> SaveRollOffForm(RollOffTransaction rollOffTransaction, int roleType)
        {
            using (var context = _factory.CreateDbContext())
            {
                bool result = false;
                context.RollOffForm.Add(rollOffTransaction.RollOffForm);
                result = await context.SaveChangesAsync().ConfigureAwait(false) > 0;

                if (result)
                {
                    context.FeedbackForm.Add(rollOffTransaction.FeedbackForm);
                    result = await context.SaveChangesAsync().ConfigureAwait(false) > 0;
                }

                if (result)
                {
                    var userDetails = await context.UserDetails.Where(u => u.Role == Enum.GetName(typeof(RoleEnum), roleType)).FirstOrDefaultAsync().ConfigureAwait(false);
                    rollOffTransaction.AssignedFrom.FeedbackFormId = rollOffTransaction.FeedbackForm.Id;
                    rollOffTransaction.AssignedFrom.RollOffFormId = rollOffTransaction.RollOffForm.Id;
                    rollOffTransaction.AssignedFrom.AssignedTo = userDetails.Id;
                    context.AssignedFrom.Add(rollOffTransaction.AssignedFrom);
                    result = await context.SaveChangesAsync().ConfigureAwait(false) > 0;
                }

                return result;
            }
        }

        public async Task<bool> SaveTransfered(TransferedFrom transferedFrom)
        {
            using (var context = _factory.CreateDbContext())
            {
                context.TransferedFrom.Add(transferedFrom);
                return await context.SaveChangesAsync().ConfigureAwait(false) > 0;
            }
        }

        public async Task<bool> UpdateTransfered(TransferedFrom transferedFrom)
        {
            using (var context = _factory.CreateDbContext())
            {
                var updateTransfered = await context.TransferedFrom.FirstOrDefaultAsync(m => m.EmployeeId == transferedFrom.EmployeeId);
                if (updateTransfered != null)
                {
                    updateTransfered.EmployeeId = transferedFrom.EmployeeId;
                    updateTransfered.AssignedFrom = transferedFrom.AssignedFrom;
                    updateTransfered.IsAactivate = transferedFrom.IsAactivate;
                    updateTransfered.IsTransfered = transferedFrom.IsTransfered;
                    context.TransferedFrom.Update(updateTransfered);
                    return await context.SaveChangesAsync().ConfigureAwait(false) > 0;
                }
                return false;
            }
        }

        public async Task<List<TransferedFrom>> GetTransfered()
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.TransferedFrom.ToListAsync();
            }
        }

        public async Task<RollOffTransaction> GetRollOffFormByEmpId(int employeeId)
        {
            var result = new RollOffTransaction();
            using (var context = _factory.CreateDbContext())
            {

                result = await (from assign in context.AssignedFrom
                                join emp in context.Employees on assign.EmployeeId equals emp.GlobalGroupID
                                join feed in context.FeedbackForm on assign.FeedbackFormId equals feed.Id
                                join roll in context.RollOffForm on assign.RollOffFormId equals roll.Id
                                where assign.EmployeeId == employeeId
                                select new RollOffTransaction()
                                {
                                    RollOffForm = roll,
                                    AssignedFrom = assign,
                                    FeedbackForm = feed,
                                }).FirstOrDefaultAsync();

                return result;
            }
        }


        public async Task<List<PSPTransaction>> GetRollOffFormList()
        {
            var result = new List<PSPTransaction>();
            using (var context = _factory.CreateDbContext())
            {
                result = await (from user in context.UserDetails
                                join assign in context.AssignedFrom on user.Id equals assign.UserDetailsId
                                join roll in context.RollOffForm on assign.RollOffFormId equals roll.Id
                                join emp in context.Employees on assign.EmployeeId equals emp.GlobalGroupID
                                //where user.Id == userId
                                select new PSPTransaction()
                                {
                                    Employee = emp,
                                    isTransfered = false,
                                    isActivated = (roll.EndDate - emp.JoiningDate.Value).Days > 30 ? true : false
                                }).ToListAsync();
                return result;
            }
        }
    }
}
