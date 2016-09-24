namespace WebApplication1.Interface
{
    public  interface IFactory
    {
        IConfigurationManager WebConfig { get; }
        IFileReader Files { get; }
        IDapper Dapper { get; }
    }
}
