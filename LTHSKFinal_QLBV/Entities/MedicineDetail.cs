﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTHSKFinal_QLBV
{
    public partial class MedicineDetail : BaseEntity
    {
        public override string EntityId => Id;

        public override void Update(BaseEntity entity)
        {
            var md = entity as MedicineDetail;
            Quantity = md.Quantity;
            UnitPrice = md.UnitPrice;
            AddedDate = md.AddedDate;
            ExpirationDate = md.ExpirationDate;
        }
    }
}
