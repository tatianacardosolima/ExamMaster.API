﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; }
        DateTime CreatedAt { get; }
        DateTime? ModifiedAt { get; }
    }
}