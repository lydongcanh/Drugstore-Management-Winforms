using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHSKFinal_QLBV
{
    public partial class Patient : BaseEntity
    {
        public override string EntityId => Id;

        public override void Update(BaseEntity entity)
        {
            var p = entity as Patient;
            FullName = p.FullName;
            PhoneNumber = p.PhoneNumber;
            Gender = p.Gender;
            BirthDate = p.BirthDate;
        }
    }
}
