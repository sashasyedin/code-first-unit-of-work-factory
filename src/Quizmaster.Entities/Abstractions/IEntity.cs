using System;

namespace Quizmaster.Entities.Abstractions
{
    public interface IEntity : IModifiableEntity
    {
        object ID { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime? ModifiedDate { get; set; }

        string CreatedBy { get; set; }

        string ModifiedBy { get; set; }
    }

    public interface IEntity<T> : IEntity
        where T : struct
    {
        new T ID { get; set; }
    }
}
