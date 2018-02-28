using System;

namespace StubGenerator.Test.Models
{
    public abstract class EntityType<T> where T : IComparable
    {
        public T Id { get; set; }
    }

    public class ComplexModelChild : EntityType<Guid>
    {
        public string Email { get; set; }
    }

    public class ComplexModel : EntityType<Guid>
    {
        public string FirstName { get; set; }
        public ComplexModelChild ComplexModelChild { get; set; }
    }
}
