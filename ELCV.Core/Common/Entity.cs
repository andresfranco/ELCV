using ELCV.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ELCV.Core.Common
{
    public abstract class Entity : IEquatable<Entity>
    {
        public long Id { get; set; }
        public string CreatedByUser { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string ModifiedByUser { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetType()!=other.GetType())
                return false;
            if (Id == 0 || other.Id == 0)
                return false;
            return Id == other.Id;

        }
        public override bool Equals(object obj)
        {
            var other= obj as Entity;
            return Equals(other);
        }



    }
}
