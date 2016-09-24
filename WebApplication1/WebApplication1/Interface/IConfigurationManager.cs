namespace WebApplication1.Interface
{
    public interface IConfigurationManager
    {
        string ConfluenceUrl { get; }
        string PageId { get; }
        string ConfluenceTestUsername { get; }
        string ConfluenceTestPassword { get; }
    }
}
