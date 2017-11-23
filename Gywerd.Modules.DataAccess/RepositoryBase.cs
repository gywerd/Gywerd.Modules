using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gywerd.Modules.DataAccess
{
    public class RepositoryBase : Executor
    {
        #region Fields
        protected Executor executor = new Executor();
        #endregion
    }
}
