using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHSKFinal_QLBV
{
    public partial class SellReceiptDetail : BaseEntity
    {
        public override string EntityId => SellReceiptId + MedicineId;

        public override void Update(BaseEntity entity)
        {
            var srd = entity as SellReceiptDetail;
            Quantity = srd.Quantity;
        }
    }
}
