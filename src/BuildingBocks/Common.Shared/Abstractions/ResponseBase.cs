using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared.Abstractions
{
    public abstract class ResponseBase<TId> 
        where TId : struct
    {
        protected ResponseBase()
        {            
        }
        protected ResponseBase(EntityBase<TId> entity) 
        {            
        }
    }
}
