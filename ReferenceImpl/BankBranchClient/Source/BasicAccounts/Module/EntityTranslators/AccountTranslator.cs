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
using GlobalBank.BasicAccounts.ServiceProxies;
using GlobalBank.Infrastructure.Interface.BusinessEntities;
using GlobalBank.Infrastructure.Interface.Services;

namespace GlobalBank.BasicAccounts.Module.EntityTranslators
{
	public class AccountTranslator : EntityMapperTranslator<Account, accountType>
	{
		protected override accountType BusinessToService(IEntityTranslatorService service, Account value)
		{
			accountType result = new accountType();
			result.accountNumber = value.AccountNumber;
			result.accountType1	= new accountTypeType();
			result.accountType1.type = value.AccountType.ToString();
			result.balance = (decimal)value.Balance;
			result.customerId = value.CustomerId;
			result.dateOpened = value.DateOpened;
			result.interestRate = value.InterestRate;
			result.lastTransactionAt = value.LastTransactionDate;
			return result;
		}

		protected override Account ServiceToBusiness(IEntityTranslatorService service, accountType value)
		{
			Account result = new Account();
			result.AccountNumber = value.accountNumber;
			result.AccountType = (AccountType)Enum.Parse(typeof(AccountType), value.accountType1.type);
			result.Balance = (float)value.balance;
			result.CustomerId = value.customerId;
			result.DateOpened = value.dateOpened;
			result.InterestRate = value.interestRate;
			result.LastTransactionDate = value.lastTransactionAt;
			return result;
		}
	}

}
