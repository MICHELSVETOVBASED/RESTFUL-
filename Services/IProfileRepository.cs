using RESTREST_2.Models;
namespace RESTREST_2.Services;

public interface IProfileRepository{
    public Profile[] GetAllProfiles();
    public bool SaveProfile(Profile profile);
    public Profile GetProfileById(int id);
}