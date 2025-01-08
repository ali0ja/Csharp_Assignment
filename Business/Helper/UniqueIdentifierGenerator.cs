

namespace Business.Helper;

public class UniqueIdentifierGenerator
{
    public static string Genrate()
    {
        return Guid.NewGuid().ToString().Split('_')[0];
    }
}
