using AutoMapper;
using TerminalPortal.Domain.Models;
using TerminalPortal.Models;

namespace TerminalPortal
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Toy, ToyViewModel>();
        }
    }
}
