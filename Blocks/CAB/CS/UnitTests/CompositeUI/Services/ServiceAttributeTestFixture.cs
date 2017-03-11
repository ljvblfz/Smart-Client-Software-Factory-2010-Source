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
//===============================================================================
// Microsoft patterns & practices
// CompositeUI Application Block
//===============================================================================
// Copyright � Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Microsoft.Practices.CompositeUI.Tests.Services
{
	[TestClass]
	public class ServiceAttributeTestFixture
	{
		[TestMethod]
		public void ServiceAttributeIsAvailable()
		{
			ServiceAttribute attr = new ServiceAttribute();
			Assert.IsNotNull(attr);
			Assert.IsNull(attr.RegisterAs);
		}

		[TestMethod]
		public void TypeGetStored()
		{
			ServiceAttribute attr = new ServiceAttribute(typeof (ServiceAttributeTestFixture));
			Assert.AreEqual(typeof (ServiceAttributeTestFixture), attr.RegisterAs);
		}

		[TestMethod]
		public void HasCreateOnDemandProperty()
		{
			ServiceAttribute attr = new ServiceAttribute();
			Assert.IsFalse(attr.AddOnDemand);
		}
	}
}
