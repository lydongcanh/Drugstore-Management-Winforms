using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHSKFinal_QLBV
{
    public partial class Employee : BaseEntity
    {
        public override string EntityId => Id;

        public override void Update(BaseEntity entity)
        {
            var e = entity as Employee;
            FullName = e.FullName;
            PhoneNumber = e.PhoneNumber;
            Gender = e.Gender;
            BirthDate = e.BirthDate;
            Username = e.Username;
            Password = e.Password;
            Type = e.Type;
        }
    }
}
