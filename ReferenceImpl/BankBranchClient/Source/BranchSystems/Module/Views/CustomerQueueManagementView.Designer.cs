//----------------------------------------------------------------------------------------
// patterns & practices - Smart Client Software Factory - Guidance Package
//
// This file was generated by the "Add View" recipe.
//
// For more information see: 
// ms-help://MS.VSCC.v80/MS.VSIPCC.v80/ms.scsf.2006jun/SCSF/html/03-030-Model%20View%20Presenter%20%20MVP%20.htm
//
// Latest version of this Guidance Package: http://go.microsoft.com/fwlink/?LinkId=62182
//----------------------------------------------------------------------------------------

namespace GlobalBank.BranchSystems.Module.Views
{
	partial class CustomerQueueManagementView
	{
		/// <summary>
		/// The presenter used by this view.
		/// </summary>
		private GlobalBank.BranchSystems.Module.Views.CustomerQueueManagementViewPresenter _presenter = null;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_presenter != null)
					_presenter.Dispose();

				if (components != null)
					components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerQueueManagementView));
			this.label1 = new System.Windows.Forms.Label();
			this._queueEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this._updateQueueTimer = new System.Windows.Forms.Timer(this.components);
			this._linksPanel = new GlobalBank.Infrastructure.UI.LinkLabelPanel();
			this._visitorQueueListBox = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this._queueEntryBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			resources.ApplyResources(this.label1, "label1");
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Name = "label1";
			// 
			// _queueEntryBindingSource
			// 
			this._queueEntryBindingSource.DataSource = typeof(GlobalBank.Infrastructure.Interface.BusinessEntities.QueueEntry);
			// 
			// _updateQueueTimer
			// 
			this._updateQueueTimer.Interval = 10000;
			this._updateQueueTimer.Tick += new System.EventHandler(this._updateQueueTimer_Tick);
			// 
			// _linksPanel
			// 
			resources.ApplyResources(this._linksPanel, "_linksPanel");
			this._linksPanel.BackColor = System.Drawing.SystemColors.Window;
			this._linksPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._linksPanel.Name = "_linksPanel";
			// 
			// _visitorQueueListBox
			// 
			resources.ApplyResources(this._visitorQueueListBox, "_visitorQueueListBox");
			this._visitorQueueListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._visitorQueueListBox.DataSource = this._queueEntryBindingSource;
			this._visitorQueueListBox.DisplayMember = "VisitorName";
			this._visitorQueueListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this._visitorQueueListBox.FormattingEnabled = true;
			this._visitorQueueListBox.Name = "_visitorQueueListBox";
			this._visitorQueueListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this._visitorQueueListBox_DrawItem);
			this._visitorQueueListBox.SelectedIndexChanged += new System.EventHandler(this._visitorQueueListBox_SelectedIndexChanged);
			// 
			// CustomerQueueManagementView
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.Controls.Add(this._linksPanel);
			this.Controls.Add(this._visitorQueueListBox);
			this.Controls.Add(this.label1);
			this.Name = "CustomerQueueManagementView";
			((System.ComponentModel.ISupportInitialize)(this._queueEntryBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.BindingSource _queueEntryBindingSource;
		private System.Windows.Forms.Timer _updateQueueTimer;
		private GlobalBank.Infrastructure.UI.LinkLabelPanel _linksPanel;
		private System.Windows.Forms.ListBox _visitorQueueListBox;
	}
}

