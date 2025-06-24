using RESTREST_2.Models;
using Microsoft.Extensions.Caching.Memory;
namespace RESTREST_2.Services;

public class ProfileRepository(IHttpContextAccessor httpContextAccessor, IMemoryCache cache): IProfileRepository{
    private const string CacheKey = "CasStore";

    

    public Profile[] GetAllProfiles(){
        if (cache.TryGetValue(CacheKey, out Profile[]? profiles)) return profiles!;
        profiles = [
                new Profile{
                    Id = 1,
                    Name = "Glenn Cock"
                },
                new Profile{
                    Id = 2,
                    Name = "Klem Belmond"
                },
                new Profile{
                    Id = 3,
                    Name = "Rober Polann"
                },
                new Profile{
                    Id = 4,
                    Name = "Kiosaki Yamatokka" 
                }
        ];
            cache.Set(CacheKey, profiles, TimeSpan.FromMinutes(30));

            return profiles; 
    }

    public Profile GetProfileById(int id){
        return GetAllProfiles().FirstOrDefault(p => p.Id == id)!;
    }

    public bool SaveProfile(Profile profile){
        if (httpContextAccessor.HttpContext == null)
            throw new Exception("HttpContext");
        if (!cache.TryGetValue(CacheKey, out Profile[]? profiles))
            return false;
        var currentData = profiles!.ToList();
        currentData.Add(profile);
        cache.Set(CacheKey, currentData.ToArray(), TimeSpan.FromMinutes(30));
        return true;
        
    }
    
}