﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    public  interface IObjectState
    {
        //[NotMapped]
        ObjectState ObjectState { get; set; }
    }
}