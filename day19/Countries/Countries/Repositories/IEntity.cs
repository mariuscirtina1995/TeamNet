using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Repositories
{
    public interface IEntity
    {
        string Code { get; set; }
    }
}
