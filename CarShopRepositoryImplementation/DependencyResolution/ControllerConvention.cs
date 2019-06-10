using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using StructureMap;
using StructureMap.Graph.Scanning;

using System.Web.Mvc;

using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.Pipeline;
using StructureMap.TypeRules;

namespace CarShopRepositoryImplementation.DependencyResolution
{
    public class ControllerConvention : IRegistrationConvention
    {
        #region Public Methods and Operators.
        public void Process(Type type, Registry registry)
        {
            if (type.CanBeCastTo<Controller>() && !type.IsAbstract)
            {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }

        #endregion

        public void ScanTypes(TypeSet types, Registry registry)
        {

        }
    }
}