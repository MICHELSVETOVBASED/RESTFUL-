using RESTREST_2.Models;
using Microsoft.AspNetCore.Http;
namespace RESTREST_2.Services;

public class ProfileRepository{
    private const string CacheKey = "CasStore";
     

    public ProfileRepository(IHttpContextAccessor httpContextAccessor)
        => public readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    public Profile[] GetAllProfiles(){
        return[
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
                Name = "Kiosaki Yamatokka"//
            }

        ];
    }
}