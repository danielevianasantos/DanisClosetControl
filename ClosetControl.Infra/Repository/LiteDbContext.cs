using ClosetControl.Domain.Interfaces;
using LiteDB;
using Microsoft.Extensions.Options;

namespace ClosetControl.Infra.Repository
{
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; }

        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            Database = new LiteDatabase("Lite/LiteDbTest.db");
        }
    }
}