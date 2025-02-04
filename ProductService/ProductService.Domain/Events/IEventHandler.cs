using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Events
{
    public interface IEventHandler<TEvent>
    {
        void Handle(TEvent @event);
    }

}
