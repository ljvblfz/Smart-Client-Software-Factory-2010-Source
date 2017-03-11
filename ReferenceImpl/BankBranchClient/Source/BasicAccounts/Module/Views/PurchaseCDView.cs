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
// This file was generated by the "Add View" recipe.
//
// This class is the concrete implementation of a View in the Model-View-Presenter 
// pattern. Communication between the Presenter and this class is acheived through 
// an interface to facilitate separation and testability.
// Note that the Presenter generated by the same recipe, will automatically be created
// by CAB through [CreateNew] and bidirectional references will be added.
//
// For more information see:
// ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.scsf.2006jun/SCSF/html/03-030-Model%20View%20Presenter%20%20MVP%20.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using GlobalBank.BasicAccounts.Properties;
using GlobalBank.Infrastructure.Interface.BusinessEntities;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;

namespace GlobalBank.BasicAccounts.Module
{
	[SmartPart]
	public partial class PurchaseCDView : UserControl, IPurchaseCDView, ISmartPartInfoProvider
	{
		public PurchaseCDView()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Sets the presenter. The dependency injection system will automatically
		/// create a new presenter for you.
		/// </summary>
		[CreateNew]
		public PurchaseCDViewPresenter Presenter
		{
			set
			{
				_presenter = value;
				_presenter.View = this;
			}
			get { return _presenter; }
		}

		public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
		{
			return new SmartPartInfo(Resources.PurchaseCDLabelText, string.Empty);
		}

		protected override void OnLoad(EventArgs e)
		{
			_presenter.OnViewReady();
			UpdateControls();
		}

		public void Clear()
		{
			_messageLabel.Text = String.Empty;
			_approveLink.Visible = false;
			_amountTextBox.Text = "";
			_durationTextbox.Text = "";
			_rateTextBox.Text = "";
			_accountsComboBox.SelectedIndex = 0;
		}

		private void buttonExecute_Click(object sender, EventArgs e)
		{
			Account account = (Account) _accountBindingSource.Current;
			decimal amount = Decimal.Parse(_amountTextBox.Text, CultureInfo.CurrentUICulture);
			int duration = Int32.Parse(_durationTextbox.Text, CultureInfo.CurrentUICulture);
			_presenter.PurchaseCD(account, amount, duration);
		}

		private void _approveLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Account account = (Account) _accountBindingSource.Current;
			decimal amount = Decimal.Parse(_amountTextBox.Text, CultureInfo.CurrentUICulture);
			int duration = Int32.Parse(_durationTextbox.Text, CultureInfo.CurrentUICulture);
			_presenter.ApproveAndPurchaseCD(account, amount, duration);
		}

		private void _buttonGetRate_Click(object sender, EventArgs e)
		{
			decimal amount = Decimal.Parse(_amountTextBox.Text, CultureInfo.CurrentUICulture);
			int duration = Int32.Parse(_durationTextbox.Text, CultureInfo.CurrentUICulture);

			_presenter.CalculateInterestRate(amount, duration);
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			_presenter.OnCloseView();
		}


		public void ShowMessage(string message)
		{
			_messageLabel.Text = message;
		}

		public void ShowApproval(bool visible)
		{
			_approveLink.Visible = visible;
		}

		public void ShowCustomerAccounts(Account[] accounts)
		{
			_accountBindingSource.DataSource = accounts;
		}

		public void ShowRatesTable(Rate[] rates)
		{
			DataTable data = new DataTable();

			data.Columns.Add("Amounts");

			foreach (Rate rate in rates)
			{
				string colName = String.Format(CultureInfo.CurrentUICulture, "{0} - {1}", rate.Start, rate.End);
				if (data.Columns.Contains(colName) == false)
				{
					data.Columns.Add(colName, typeof (decimal));
				}
			}

			Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
			foreach (Rate rate in rates)
			{
				string rowName = String.Format(CultureInfo.CurrentUICulture, "${0} to ${1}", rate.MinimumAmount, rate.MaximumAmount);
				string colName = String.Format(CultureInfo.CurrentUICulture, "{0} - {1}", rate.Start, rate.End);
				DataRow row = null;
				if (rows.ContainsKey(rowName) == false)
				{
					row = data.NewRow();
					rows[rowName] = row;
					data.Rows.Add(row);
					row["Amounts"] = rowName;
				}
				else
				{
					row = rows[rowName];
				}
				row[colName] = rate.InterestRate;
			}

			_ratesGridView.DataSource = data;
		}

		public void ShowInterestRate(decimal rate)
		{
			_rateTextBox.Text = rate.ToString(CultureInfo.CurrentUICulture);
		}

		private void _durationTextbox_TextChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void _amountTextBox_TextChanged(object sender, EventArgs e)
		{
			UpdateControls();
		}

		private void UpdateControls()
		{
			int result = 0;
			ShowMessage(String.Empty);
			bool required = _amountTextBox.Text.Length > 0 && _durationTextbox.Text.Length > 0 &&
			                int.TryParse(_amountTextBox.Text, out result) && int.Parse(_amountTextBox.Text) > 0 && 
			                int.TryParse(_durationTextbox.Text, out result) && int.Parse(_durationTextbox.Text) > 0;
			buttonExecute.Enabled = required;
			_approveLink.Enabled = required;
			_buttonGetRate.Enabled = required;
		}
	}
}
