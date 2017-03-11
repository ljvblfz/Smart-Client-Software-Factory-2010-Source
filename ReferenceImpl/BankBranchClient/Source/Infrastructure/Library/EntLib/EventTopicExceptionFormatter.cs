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
using System.IO;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace GlobalBank.Infrastructure.Library.EntLib
{
    public class EventTopicExceptionFormatter : TextExceptionFormatter
    {
        public EventTopicExceptionFormatter(TextWriter writer, Exception exception)
            : base(writer, exception)
        {
        }

        protected override void WriteException(Exception exceptionToFormat, Exception outerException)
        {
            EventTopicException ete = exceptionToFormat as EventTopicException;
            if (ete != null)
            {
                foreach (Exception ex in ete.Exceptions)
                {
                    base.WriteException(ex, null);
                }
            }
        }
    }
}
