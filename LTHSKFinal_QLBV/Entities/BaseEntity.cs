using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHSKFinal_QLBV
{
    public abstract class BaseEntity : IComparable<BaseEntity>
    {
        public abstract string EntityId { get; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return EntityId.Equals(((BaseEntity)obj).EntityId);
        }

        public override int GetHashCode()
        {
            return EntityId.GetHashCode();
        }

        public int CompareTo(BaseEntity other)
        {
            return EntityId.CompareTo(other.EntityId);
        }
    }
}
