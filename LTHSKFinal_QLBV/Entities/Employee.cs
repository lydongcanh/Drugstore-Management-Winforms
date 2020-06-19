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
    }
}
