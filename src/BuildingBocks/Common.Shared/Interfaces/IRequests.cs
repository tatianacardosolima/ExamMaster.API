using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared.Interfaces
{
    public interface IRequest
    {

    }
    public interface INewRequest: IRequest
    {

    }
    public interface IUpdRequest : IRequest
    {
        Guid Id { get; set; }

    }
}
