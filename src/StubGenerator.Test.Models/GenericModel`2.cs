namespace StubGenerator.Test.Models
{
    public class GenericModel<T1, T2>
        where T1 : class
        where T2 : class
    {
        public int Status { get; set; }

        public T1 GenericOne { get; set; }
        public T2 GenericTwo { get; set; }
    }
}
