using Gyb.FrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Server.Entities.BusinessRules
{
    /// <summary>
    /// 添加购物车业务规则
    /// </summary>
    public class BasketBusinessRules
    {
        public static readonly BusinessRule DeliveryOptionRequired =
                    new BusinessRule("DeliveryOption",
                                        "An order must have a valid delivery option.");
        public static readonly BusinessRule ItemInvalid =
                    new BusinessRule("Item", "A basket cannot have any invalid items.");
    }
}
