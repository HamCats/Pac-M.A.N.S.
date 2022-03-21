using System;
using System.Collections.Generic;
using System.Text;

namespace Pac_M.A.N.S
{
    public class CollisionEventArgs : EventArgs
    {
        public CollisionEventArgs (CollisionType type)
        {
            this.Type = type;
        }

        public CollisionEventArgs (CollisionType type, uint points) : this(type)
        {
            this.Points = points;
        }

        public CollisionType Type { get; private set; }

        public uint Points { get; private set; }
    }
}
