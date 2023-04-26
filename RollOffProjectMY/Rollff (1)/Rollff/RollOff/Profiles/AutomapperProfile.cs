using AutoMapper;
using RollOff.Models.Domain;
using RollOff.Models.DTO;

namespace RollOff_Test4API.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Employee, GetEmployee>()
               .ReverseMap();
            CreateMap<Employee, GetEmployeeByID>()
                .ReverseMap();
            CreateMap<TransferedFromDto, TransferedFrom>()
                .ReverseMap();
            CreateMap<UserDetailsDto, UserDetails>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
            CreateMap<RollOffTransactionDto, RollOffTransaction>()
                .AfterMap((src, dest) =>
                {
                    dest.RollOffForm = new RollOffForm
                    {
                        PrimarySkill = src.RollOffFormDto.PrimarySkill,
                        EndDate = src.RollOffFormDto.EndDate,
                        Reason = src.RollOffFormDto.Reason,
                        OtherReason = src.RollOffFormDto.OtherReason,
                        PerformanceIssue = src.RollOffFormDto.PerformanceIssue,
                        Resgined = src.RollOffFormDto.Resgined,
                        UnderProbation = src.RollOffFormDto.UnderProbation,
                        LongLeave = src.RollOffFormDto.LongLeave,
                        LeaveType = src.RollOffFormDto.LeaveType
                    };
                    dest.FeedbackForm = new FeedbackForm
                    {
                        TechnicalSkill= src.FeedbackFormDto.TechnicalSkill,
                        Communication = src.FeedbackFormDto.Communication,
                        RoleCompetance = src.FeedbackFormDto.RoleCompetance,
                        Remarks = src.FeedbackFormDto.Remarks,
                        RelevantExperience = src.FeedbackFormDto.RelevantExperience,
                    };
                    dest.AssignedFrom = new AssignedFrom
                    {
                        EmployeeId = src.AssignedFromDto.EmployeeId,
                        UserDetailsId = src.AssignedFromDto.UserDetailsId
                    };
                });
        }
    }
}
