namespace aljuvifoods_webapi.Services.Contracts
{
    public interface IMailService
    {
        Task Send(string subject, string body, List<string> recipien);
        
    }
}
