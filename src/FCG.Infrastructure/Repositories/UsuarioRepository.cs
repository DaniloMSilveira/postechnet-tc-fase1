using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCG.Domain.Entities;
using FCG.Domain.Interfaces.Repositories;
using FCG.Infrastructure.Contexts;

namespace FCG.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(FCGContext context) : base(context)
        {
        }
    }
}