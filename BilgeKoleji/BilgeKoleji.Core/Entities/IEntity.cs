﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.Core.Entities
{
    public interface IEntity<T> where T : struct
    {
        T Id { get; set; }

    }
}
