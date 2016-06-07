using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Go.Infrastructure.Core.Modules
{
    class Module : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry=null;

        public Module(IRegionViewRegistry regionViewRegistry)
		{
			_regionViewRegistry=regionViewRegistry;
		}

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
