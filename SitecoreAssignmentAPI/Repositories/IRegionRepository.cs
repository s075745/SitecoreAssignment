using Microsoft.Identity.Client;
using SitecoreAssignmentAPI.Models.Domain;
using System.Runtime.InteropServices;

namespace SitecoreAssignmentAPI.Repositories
{
    public interface IRegionRepository
    {
       Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id, Region region);

        Task<Region?> DeleteAsync(Guid id);



    }
}
