using System.Threading.Tasks;
using BBT.Prism.Data.Seeding;

namespace BBT.MyProjectName.EntityFrameworkCore;

public class MyProjectNameTestDataSeedContributor: IDataSeedContributor
{
    public Task SeedAsync(DataSeedContext context)
    {
        /* Seed additional test data... */

        return Task.CompletedTask;
    }
}