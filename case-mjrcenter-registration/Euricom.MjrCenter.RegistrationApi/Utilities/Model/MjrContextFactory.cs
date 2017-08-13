using Euricom.MjrCenter.RegistrationApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Euricom.MjrCenter.RegistrationApi.Utilities.Model
{
    public class MjrContextFactory : IDbContextFactory<MjrContext>
    {
        private readonly string _connectionString;

        public MjrContextFactory()
        {
            var configuration = Program.Configuration;
            _connectionString = configuration.GetConnectionString(Constants.MjrConnectionString);
        }

        public MjrContext Create(DbContextFactoryOptions options)
        {
            var ctxOptions = new DbContextOptionsBuilder();
            ctxOptions.UseSqlite(_connectionString);
            return new MjrContext(ctxOptions.Options);

        }
    }
}
