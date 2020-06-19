using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHSKFinal_QLBV
{
    public partial class MedicineSupplier : BaseEntity
    {
        public override string EntityId => Id;

        public override void Update(BaseEntity entity)
        {
            var ms = entity as MedicineSupplier;
            Name = ms.Name;
            PhoneNumber = ms.PhoneNumber;
        }
    }
}
