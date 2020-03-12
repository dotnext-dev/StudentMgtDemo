using System;
using System.Collections.Generic;
using System.Text;

namespace Sharada.StudentMgt.Core
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }
    }
}
