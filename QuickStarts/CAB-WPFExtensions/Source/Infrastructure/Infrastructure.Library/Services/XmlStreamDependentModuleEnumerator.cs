//===============================================================================
// Microsoft patterns & practices
// Smart Client Software Factory 2010
//===============================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===============================================================================
//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by this guidance package as part of the solution template
//
// The XmlStreamDependentModuleEnumerator class provides an implementation of IModuleEnumerator
// that is used to retrieve an array of IModuleInfo. This service depends on the IModuleInfoStore service
// that provides the storage of the profile catalog
// 
// For more information see: 
// ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.scsf.2006jun/SCSF/html/03-210-Creating%20a%20Smart%20Client%20Solution.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;
using System.Xml;
using Microsoft.Practices.QuickStarts.WPFIntegration.Infrastructure.Library.Properties;
using Microsoft.Practices.QuickStarts.WPFIntegration.Infrastructure.Library.Services;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Configuration;
using Microsoft.Practices.CompositeUI.Services;

namespace Microsoft.Practices.QuickStarts.WPFIntegration.Infrastructure.Library.Services
{
    /// <summary>
    /// This implementation of IModuleEnumerator processes the assemblies specified
    /// in a solution profile.
    /// </summary>
    public class XmlStreamDependentModuleEnumerator : IModuleEnumerator
    {
        private IModuleInfoStore _moduleInfoStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmlStreamDependentModuleEnumerator"/> class.
        /// </summary>
        public XmlStreamDependentModuleEnumerator()
        {
        }

        [ServiceDependency]
        public IModuleInfoStore ModuleInfoStore
        {
            get { return _moduleInfoStore; }
            set { _moduleInfoStore = value; }
        }

        /// <summary>
        /// Gets an array of <see cref="T:Microsoft.Practices.CompositeUI.Configuration.IModuleInfo"/>
        /// enumerated from the source the enumerator is processing.
        /// </summary>
        /// <returns>
        /// An array of <see cref="T:Microsoft.Practices.CompositeUI.Configuration.IModuleInfo"/> instances.
        /// </returns>
        public IModuleInfo[] EnumerateModules()
        {
            string xml = _moduleInfoStore.GetModuleListXml();

            if (String.IsNullOrEmpty(xml))
                return new DependentModuleInfo[0];

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            switch (doc.FirstChild.NamespaceURI)
            {
                case SolutionProfileV1Parser.Namespace:
                    return new SolutionProfileV1Parser().Parse(xml);

                case SolutionProfileV2Parser.Namespace:
                    return new SolutionProfileV2Parser().Parse(xml);

                default:
                    throw new InvalidOperationException(Resources.InvalidSolutionProfileSchema);
            }
        }
    }
}
