using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;

namespace CarShopRepositoryImplementation.DependencyResolution
{
    public static class IOC
    {
        
            public static IContainer Initialize()
            {

                return new Container(c => c.AddRegistry<DefaultRegistry>());
            }
        
    }
}