using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RollOff.Models;
using RollOff.Models.Domain;
using RollOff.Models.DTO;
using RollOff.Models.Response;
using RollOff.Repository;

namespace RollOff.Services
{
    public class RolloffFormService : IRolloffFormService
    {
        private IRollOffFormRepository _rollOffFormRepository;
        private readonly IMapper _mapper;
        public RolloffFormService(IRollOffFormRepository rollOffFormRepository, IMapper mapper)
        {
            _rollOffFormRepository = rollOffFormRepository;
            _mapper = mapper;
        }

        public async Task<bool> SaveRollOffForm(RollOffTransactionDto rollOffTransactionDto)
        {
            var rollOffTransaction = _mapper.Map<RollOffTransaction>(rollOffTransactionDto);
            return await _rollOffFormRepository.SaveRollOffForm(rollOffTransaction, rollOffTransactionDto.AssignedFromDto.RoleType).ConfigureAwait(false);
        }
        public async Task<RollOffTransaction> GetRollOffFormByEmpId(int employeeId) 
        {
            return await _rollOffFormRepository.GetRollOffFormByEmpId(employeeId);
        }

        public async Task<List<PSPTransaction>> GetRollOffFormList()
        {
            var tranferedList = await _rollOffFormRepository.GetTransfered();
            var result = await _rollOffFormRepository.GetRollOffFormList();

            if (tranferedList != null)
            {
                foreach (var item in tranferedList)
                {
                    var data = result.FirstOrDefault(m => m.Employee.GlobalGroupID == item.EmployeeId);
                    data.isActivated = item.IsAactivate;
                    data.isTransfered = item.IsTransfered;
                }
            }

            return result;
        }

        public async Task<bool> SaveTransfered(TransferedFromDto transferedFromDto)
        {
            var transferedFrom = _mapper.Map<TransferedFrom>(transferedFromDto);
            return await _rollOffFormRepository.SaveTransfered(transferedFrom);
        }

        public async Task<bool> UpdateTransfered(TransferedFromDto transferedFromDto)
        {
            var transferedFrom = _mapper.Map<TransferedFrom>(transferedFromDto);
            return await _rollOffFormRepository.UpdateTransfered(transferedFrom);
        }

        public async Task<List<PSPTransaction>> GetTransferedList()
        {
            var result = await _rollOffFormRepository.GetRollOffFormList();
            var tranferedList = await _rollOffFormRepository.GetTransfered();

            var isAvtivatedList = result.Where(m => m.isActivated == true).ToList();
            var notAvtivatedList = result.Where(m => m.isActivated == false).ToList();
            
            if (tranferedList != null)
            {
                foreach (var item in tranferedList)
                {
                    var data = notAvtivatedList.FirstOrDefault(m => m.Employee.GlobalGroupID == item.EmployeeId);
                    data.isActivated = item.IsAactivate;
                    data.isTransfered = item.IsTransfered;
                    isAvtivatedList.Add(data);
                }
            }

            return isAvtivatedList;
        }
    }
}
