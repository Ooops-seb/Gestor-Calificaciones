using escolastico.Models;

namespace escolastico.Services.Contract
{
    public interface ICampusService
    {
        Task<List<Campus>> GetCampusList();
        Task<string> GenerateNextId();
        Task<Campus> NewRegister(Campus newRegister);
    }
}
