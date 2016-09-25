namespace WebApplication1.Interface
{
    public interface IConfigurationManager
    {
        string RdssqlServerConnection { get; }
        string SqlQueryPath { get; }
        string GetAcronyms { get; }
        string GetHistoryLogbyName { get; }
        string GetHistoryList { get; }
        string InsertHistoryLog { get; }
        string UpdateHistoryLog { get; }
        string GetLinkbyId { get; }
        string GetRelatedById { get; }
    } 
}
