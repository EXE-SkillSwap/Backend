namespace SkillSwap.DAL.Contract;

public interface IUnitOfWork
{
    public Task<int> SaveChangeAsync();
}