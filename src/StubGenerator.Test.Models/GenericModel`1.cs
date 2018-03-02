namespace StubGenerator.Test.Models
{
    public class GenericModel<T> where T : class
    {
        public int Status { get; set; }

        public T Data { get; set; }
    }
}
