namespace UserService.HttpMessageSender
{
    public interface IHttpMessageSender <T> where T:class
    {
        Task<T> Get();
        Task<T> Put();
        Task<T> Post();
        Task<T> Delete();

    }
}
