using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHSKFinal_QLBV
{
    public partial class PatientPrescriptionMedicine : BaseEntity
    {
        public override string EntityId => MedicineId + PatientPrescriptionId;

        public override void Update(BaseEntity entity)
        {
            var ppm = entity as PatientPrescriptionMedicine;
            OneDayQuantity = ppm.OneDayQuantity;
            Description = ppm.Description;
        }
    }
}
