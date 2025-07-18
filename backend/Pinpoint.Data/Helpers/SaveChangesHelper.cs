namespace Pinpoint.Data.Helpers;

public class SaveChangesHelper : ISaveChangesHelper
{
    private readonly Context _context;
    
    public SaveChangesHelper(Context context)
    {
        _context = context;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}