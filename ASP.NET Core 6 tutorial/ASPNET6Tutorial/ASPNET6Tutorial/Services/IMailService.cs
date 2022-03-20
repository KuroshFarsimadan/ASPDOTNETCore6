namespace ASPNET6Tutorial.Services
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}