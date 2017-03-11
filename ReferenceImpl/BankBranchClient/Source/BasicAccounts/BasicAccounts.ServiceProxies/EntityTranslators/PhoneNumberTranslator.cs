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
using System;
using GlobalBank.Infrastructure.Interface.Services;
using GlobalBank.Infrastructure.Library.EntityTranslators;

namespace GlobalBank.BasicAccounts.ServiceProxies.EntityTranslators
{
	public class PhoneNumberTranslator :
		EntityMapperTranslator<Infrastructure.Interface.BusinessEntities.PhoneNumber, PhoneNumber>
	{
		protected override PhoneNumber BusinessToService(IEntityTranslatorService service,
		                                                 Infrastructure.Interface.BusinessEntities.PhoneNumber value)
		{
			PhoneNumber result = new PhoneNumber();
			result.PhoneNumber1 = value.Number;
			result.PhoneType = value.PhoneType.ToString();
			return result;
		}

		protected override Infrastructure.Interface.BusinessEntities.PhoneNumber ServiceToBusiness(
			IEntityTranslatorService service, PhoneNumber value)
		{
			Infrastructure.Interface.BusinessEntities.PhoneNumber result =
				new Infrastructure.Interface.BusinessEntities.PhoneNumber();
			result.Number = value.PhoneNumber1;
			if (value.PhoneType != null)
				result.PhoneType =
					(Infrastructure.Interface.BusinessEntities.PhoneType)
					Enum.Parse(typeof (Infrastructure.Interface.BusinessEntities.PhoneType), value.PhoneType);
			return result;
		}
	}
}