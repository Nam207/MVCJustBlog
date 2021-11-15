using FA.JustBlog.Core.Models.Enums;

namespace FA.JustBlog.Core.Models.EntityBase
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        Status Status { get; set; }
    }
}