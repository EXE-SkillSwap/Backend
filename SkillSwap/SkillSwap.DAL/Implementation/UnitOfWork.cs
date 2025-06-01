
using SkillSwap.DAL.Contract;
using SkillSwap.DAL.Data;

namespace SkillSwap.DAL.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private SwapSkillDBContext _context;

    public UnitOfWork(SwapSkillDBContext context)
    {
        _context = context;
    }


    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();
    }
}