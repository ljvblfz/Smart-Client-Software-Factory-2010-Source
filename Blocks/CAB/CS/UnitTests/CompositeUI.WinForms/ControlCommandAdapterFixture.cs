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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.Commands;

namespace Microsoft.Practices.CompositeUI.WinForms.Tests
{
	[TestClass]
	public class ControlCommandAdapterFixture
	{
		[TestMethod]
		public void DisabledCommandDisablesButShowsItem()
		{
			Command command = new Command();
			MockInvoker item = new MockInvoker();
			ControlCommandAdapter adapter = new ControlCommandAdapter(item, "Event");
			command.AddCommandAdapter(adapter);
			
			command.Status = CommandStatus.Disabled;

			Assert.IsFalse(item.Enabled);
			Assert.IsTrue(item.Visible);
		}

		[TestMethod]
		public void EnabledCommandEnablesAndShowsItem()
		{
			Command command = new Command();
			MockInvoker item = new MockInvoker();
			ControlCommandAdapter adapter = new ControlCommandAdapter(item, "Event");
			command.AddCommandAdapter(adapter);
			command.Status = CommandStatus.Disabled;

			command.Status = CommandStatus.Enabled;

			Assert.IsTrue(item.Enabled);
			Assert.IsTrue(item.Visible);
		}

		[TestMethod]
		public void UnavailableCommandDisablesAndHidesItem()
		{
			Command command = new Command();
			MockInvoker item = new MockInvoker();
			ControlCommandAdapter adapter = new ControlCommandAdapter(item, "Event");
			command.AddCommandAdapter(adapter);

			command.Status = CommandStatus.Unavailable;

			Assert.IsFalse(item.Enabled);
			Assert.IsFalse(item.Visible);
		}

		class MockInvoker : Control
		{
			public event EventHandler Event;

			public void DoInvoke()
			{
				if (Event != null)
				{
					Event(this, EventArgs.Empty);
				}
			}
		}
	}
}
