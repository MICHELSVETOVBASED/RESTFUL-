using Microsoft.AspNetCore.Mvc;
using RESTREST_2.Models;
using RESTREST_2.Services;
using Microsoft.AspNetCore.Http;
namespace RESTREST_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase{
    
    private ProfileRepository profileRepository;
    

    public ProfileController(){
        profileRepository = new ProfileRepository();
    }
    
    
    //GET api/profile
    [HttpGet]
    public Profile[] Get(){
        return profileRepository.GetAllProfiles();
    }
}