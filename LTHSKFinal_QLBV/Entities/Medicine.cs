using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHSKFinal_QLBV
{
    public partial class Medicine : BaseEntity
    {
        public override string EntityId => Id;

        public override void Update(BaseEntity entity)
        {
            var m = entity as Medicine;
            Name = m.Name;
            SellPrice = m.SellPrice;
        }
    }
}
