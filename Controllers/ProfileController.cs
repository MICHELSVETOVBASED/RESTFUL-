using System.Net;
using Microsoft.AspNetCore.Mvc;
using RESTREST_2.Models;
using RESTREST_2.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace RESTREST_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController(ProfileRepository profileRepository) : ControllerBase
{
    //GET api/profile
    [HttpGet]
    public Profile[] Get()
    {
        return profileRepository.GetAllProfiles();
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

