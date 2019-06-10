using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarShopRepositoryImplementation;
using CarShopRepositoryImplementation.Persistence;
using WebActivatorEx;

[assembly: System.Web.PreApplicationStartMethod(typeof(StructureMapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructureMapMvc), "End")]

namespace CarShopRepositoryImplementation
{
    using System.Web.Mvc;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using CarShopRepositoryImplementation.DependencyResolution;

    using StructureMap;

    public static class StructureMapMvc
    {
        #region Public Properties

        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

        #endregion

        #region Public Methods and Operators

        public static void End()
        {
            StructureMapDependencyScope.Dispose();
        }

        public static void Start()
        {
            IContainer container = IOC.Initialize();
            StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }

        #endregion
    }
}