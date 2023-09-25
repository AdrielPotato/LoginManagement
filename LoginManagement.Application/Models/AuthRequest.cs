using LoginManagement.Core.Entities;
using MediatR;

namespace LoginManagement.Application.Models
{
    public abstract class AuthRequest<T> : IRequest<Result<T>>
    {
        public User User { get; set; }
    }
}
