
using Microsoft.AspNetCore.Mvc;
using RESTREST_2.Models;
using RESTREST_2.Services;


namespace RESTREST_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController(IProfileRepository profileRepository) : ControllerBase
{
    //GET api/profile
    [HttpGet]
    public Profile[] Get()
    {
        return profileRepository.GetAllProfiles();
    }

    [HttpGet("{id}")]
    public  Profile GetById(int id){
        return profileRepository.GetProfileById(id);
    }
    //POST api/profile
    [HttpPost]
    public IActionResult Post([FromBody] Profile profile){
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        profileRepository.SaveProfile(profile);
        return StatusCode(StatusCodes.Status201Created, profile);

    }
}

