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
using Microsoft.Practices.RecipeFramework.Library;
using Microsoft.Practices.RecipeFramework.Extensions;

namespace Microsoft.Practices.SmartClientFactory.CustomWizardPages
{
    public class CreateEventPublicationPagePresenter
    {
        private ICreateEventPublicationPageModel _model;
        private ICreateEventPublicationPage _view;

        public CreateEventPublicationPagePresenter(ICreateEventPublicationPage view, ICreateEventPublicationPageModel model, IServiceProvider serviceProvider)
        {
            Guard.ArgumentNotNull(view, "view");
            Guard.ArgumentNotNull(view, "model");

            _view = view;
            _model = model;

            _view.RequestingValidation += new EventHandler<EventArgs<bool>>(OnValidating);
            _view.EventTopicChanged += new EventHandler<EventArgs>(OnEventTopicChanged);
            _view.PublicationScopeChanged += new EventHandler<EventArgs>(OnPublicationScopeChanged);
            _view.EventArgsChanged += new EventHandler<EventArgs>(OnEventArgsChanged);
            _view.ShowDocumentationChanged += new EventHandler<EventArgs>(OnShowDocumentationChanged);
        }

        void OnShowDocumentationChanged(object sender, EventArgs e)
        {
            _model.ShowDocumentation = _view.ShowDocumentation;
        }

        void OnEventTopicChanged(object sender, EventArgs e)
        {
            _model.EventTopic = _view.EventTopic;
        }

        void OnPublicationScopeChanged(object sender, EventArgs e)
        {
            _model.PublicationScope = _view.PublicationScope;
        }

        void OnEventArgsChanged(object sender, EventArgs e)
        {
            _model.EventArgs = _view.EventArgs;
        }

        public void OnViewReady()
        {
            _view.ShowShowDocumentation(_model.ShowDocumentation);
            _view.ShowEventArgs(_model.EventArgs);
            _view.ShowPublicationScope(_model.PublicationScopes, _model.PublicationScope);
        }

        void OnValidating(object sender, EventArgs<bool> e)
        {
            e.Data = _model.IsValid;
        }
    }    
}
