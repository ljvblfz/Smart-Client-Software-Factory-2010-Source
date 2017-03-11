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
using System.Collections.Generic;
using GlobalBank.Infrastructure.Interface.Services;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Utility;

namespace GlobalBank.Infrastructure.Library.Services
{
    public class ActionCatalogService : IActionCatalogService
    {
        private Dictionary<string, List<IActionCondition>> _specificActionConditions = new Dictionary<string, List<IActionCondition>>();
        private List<IActionCondition> _generalActionConditions = new List<IActionCondition>();
        private Dictionary<string, ActionDelegate> _actionImplementations = new Dictionary<string, ActionDelegate>();

        public void RegisterSpecificCondition(string action, IActionCondition actionCondition)
        {
			Guard.ArgumentNotNullOrEmptyString(action, "action");
			Guard.ArgumentNotNull(actionCondition, "actionCondition");

            List<IActionCondition> conditions = null;

            if (_specificActionConditions.TryGetValue(action, out conditions))
            {
                IActionCondition registered = conditions.Find(delegate(IActionCondition test)
                {
                    return test.GetType() == actionCondition.GetType();
                });
                if (registered != null) throw new ActionCatalogException();
                conditions.Add(actionCondition);
            }
            else
            {
                _specificActionConditions.Add(action, new List<IActionCondition>());
                _specificActionConditions[action].Add(actionCondition);
            }
        }

        public void RegisterGeneralCondition(IActionCondition actionCondition)
        {
			Guard.ArgumentNotNull(actionCondition, "actionCondition");

            IActionCondition registered = _generalActionConditions.Find(delegate(IActionCondition test)
                {
                    return test.GetType() == actionCondition.GetType();
                });
            if (registered != null) throw new ActionCatalogException();
            _generalActionConditions.Add(actionCondition);
        }

        public bool CanExecute(string action)
        {
            return CanExecute(action, null, null, null);
        }

        public bool CanExecute(string action, WorkItem context, object caller, object target)
        {
			Guard.ArgumentNotNullOrEmptyString(action, "action");

            bool result = true;
            List<IActionCondition> conditions = BuildActionConditionPipeline(action);
            conditions.ForEach(delegate(IActionCondition condition)
            {
                result &= condition.CanExecute(action, context, caller, target);
            });
            return result;
        }

        public void RemoveSpecificCondition(string action, IActionCondition actionCondition)
        {
			Guard.ArgumentNotNullOrEmptyString(action, "action");
			Guard.ArgumentNotNull(actionCondition, "actionCondition");

            List<IActionCondition> conditions;
            if (_specificActionConditions.TryGetValue(action, out conditions))
            {
                conditions.Remove(actionCondition);
            }
        }

        public void RemoveGeneralCondition(IActionCondition actionCondition)
        {
			Guard.ArgumentNotNull(actionCondition, "actionCondition");

            _generalActionConditions.Remove(actionCondition);
        }

        public void RegisterActionImplementation(string action, ActionDelegate actionDelegate)
        {
			Guard.ArgumentNotNullOrEmptyString(action, "action");
			Guard.ArgumentNotNull(actionDelegate, "actionDelegate");

            _actionImplementations[action] = actionDelegate;
        }

        public void RemoveActionImplementation(string action)
        {
			Guard.ArgumentNotNullOrEmptyString(action, "action");

            _actionImplementations.Remove(action);
        }

        public void Execute(string action, WorkItem context, object caller, object target)
        {
			Guard.ArgumentNotNullOrEmptyString(action, "action");

            ActionDelegate actionDelegate = null;
            if (CanExecute(action, context, caller, target))
            {
                if (_actionImplementations.TryGetValue(action, out actionDelegate))
                {
                    actionDelegate(caller, target);
                }
            }
        }

		private List<IActionCondition> BuildActionConditionPipeline(string action)
		{
			List<IActionCondition> pipeline = new List<IActionCondition>(_generalActionConditions);
			List<IActionCondition> conditions;
			if (_specificActionConditions.TryGetValue(action, out conditions))
			{
				pipeline.AddRange(conditions);
			}
			return pipeline;
		}
    }
}