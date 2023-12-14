using Infrastructure.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Share
{
    public abstract class CommandRequestBase<T> : CommandBase, IRequest<T>
    {
    }

    public abstract class CommandRequestBase : CommandBase , IRequest
    {

    }

    public abstract class CommandBase
    {
        public UserInfo CommandSender { get; set; }
        public abstract void Validate();
    }
}
