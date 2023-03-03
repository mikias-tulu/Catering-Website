using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace adminautentication.Models
{
    [CollectionName("Admin")]
    public class ApplicationUser: MongoIdentityUser<Guid>
    {
    }
}
