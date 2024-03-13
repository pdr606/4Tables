namespace _4Tables.Domain.Base.Common
{
    public class BasicResultT<T> : BasicResult
    {
        public T? Data { get; set; }

        public void BindingData(T data)
        {
            Data = data;
        }
    }
}
