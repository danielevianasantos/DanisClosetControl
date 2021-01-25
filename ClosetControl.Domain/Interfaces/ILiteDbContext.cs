using LiteDB;

namespace ClosetControl.Domain.Interfaces
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
