namespace TradeTracker.Application.Interfaces
{
    public interface ILoggedInUserService
    {
        string AccessKey { get; }
        string UserId { get; }
    }
}
