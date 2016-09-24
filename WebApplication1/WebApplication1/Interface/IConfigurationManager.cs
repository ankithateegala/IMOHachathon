namespace WebApplication1.Interface
{
    public interface IConfigurationManager
    {
        string RdssqlServerConnection { get; }
        string SqlQueryPath { get; }
        string GetAcronyms { get; }
    }
}
