using RESTREST_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
namespace RESTREST_2.Services;

public class ProfileRepository{

    private readonly IMemoryCache _cache;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string CacheKey = "CasStore";
    public ProfileRepository(IHttpContextAccessor httpContextAccessor, IMemoryCache cache){
        _httpContextAccessor = httpContextAccessor;
        _cache = cache;
    }

    public Profile[] GetAllProfiles(){
        if (!_cache.TryGetValue(CacheKey, out Profile[]? profiles)){
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
            _cache.Set(CacheKey, profiles, TimeSpan.FromMinutes(30));
        }

        return profiles!;
    }

    public bool SaveProfile(Profile profile){
        if (_httpContextAccessor.HttpContext == null)
            throw new Exception("HttpContext");
        if (!_cache.TryGetValue(CacheKey, out Profile[]? profiles))
            return false;
        var currentData = profiles!.ToList();
        currentData.Add(profile);
        _cache.Set(CacheKey, currentData.ToArray(), TimeSpan.FromMinutes(30));
        return true;
        
    }
    
}