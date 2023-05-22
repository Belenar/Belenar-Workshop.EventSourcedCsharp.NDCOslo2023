using BeerSender.Domain.Box.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerSender.Domain.Box
{
    internal class Box : Aggregate
    {
        public Box_size Box_size { get; private set; }
        public bool Is_closed { get; private set; }

        public void Apply(object @event)
        {
            throw new NotImplementedException();
        }

        public void Apply(Box_created @event)
        {
            Box_size = @event.Size;
        }
    }
}
