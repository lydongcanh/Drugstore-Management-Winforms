using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHSKFinal_QLBV
{
    public partial class PatientPrescription : BaseEntity
    {
        public override string EntityId => Id;

        public override void Update(BaseEntity entity)
        {
            var pp = entity as PatientPrescription;
            DiseaseName = pp.DiseaseName;
        }
    }
}
