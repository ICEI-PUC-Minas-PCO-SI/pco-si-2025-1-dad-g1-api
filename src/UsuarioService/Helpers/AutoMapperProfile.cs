using AutoMapper;
using UsuarioService.DTOs;
using UsuarioService.Models;

namespace UsuarioService.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeamento de Usuario para LerUsuarioDto
            CreateMap<Usuario, LerUsuarioDto>();

            // Mapeamento de CriarUsuarioDto para Usuario
            CreateMap<CriarUsuarioDto, Usuario>();

            // Mapeamento de AtualizarUsuario para Usuario
            // Use ForMember para ignorar PasswordHash se não estiver sendo atualizado
            CreateMap<AtualizarUsuarioDto, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Senha)));
        }
    }
}