using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quizmaster.Entities.Contracts;

namespace Quizmaster.Entities
{
    public abstract class Entity<T> : IEntity<T>
        where T : struct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T ID { get; set; }

        object IEntity.ID
        {
            get { return this.ID; }
            set { this.ID = (T)Convert.ChangeType(value, typeof(T)); }
        }

        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
