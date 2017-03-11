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
	partial class OfficerPanelView
	{
		/// <summary>
		/// The presenter used by this view.
		/// </summary>
		private OfficerPanelViewPresenter _presenter = null;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfficerPanelView));
			this._officerQueueListBox = new System.Windows.Forms.ListBox();
			this._queueBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this._updateQueueTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this._queueBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// _officerQueueListBox
			// 
			resources.ApplyResources(this._officerQueueListBox, "_officerQueueListBox");
			this._officerQueueListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._officerQueueListBox.DataSource = this._queueBindingSource;
			this._officerQueueListBox.DisplayMember = "VisitorName";
			this._officerQueueListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this._officerQueueListBox.FormattingEnabled = true;
			this._officerQueueListBox.Name = "_officerQueueListBox";
			this._officerQueueListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this._officerQueueListBox_DrawItem);
			this._officerQueueListBox.DoubleClick += new System.EventHandler(this._officerQueueListBox_DoubleClick);
			this._officerQueueListBox.SelectedIndexChanged += new System.EventHandler(this._officerQueueListBox_SelectedIndexChanged);
			// 
			// _queueBindingSource
			// 
			this._queueBindingSource.DataSource = typeof(GlobalBank.Infrastructure.Interface.BusinessEntities.QueueEntry);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			resources.ApplyResources(this.label1, "label1");
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Name = "label1";
			// 
			// _updateQueueTimer
			// 
			this._updateQueueTimer.Enabled = true;
			this._updateQueueTimer.Interval = 5000;
			this._updateQueueTimer.Tick += new System.EventHandler(this._updateQueueTimer_Tick);
			// 
			// OfficerPanelView
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._officerQueueListBox);
			this.Controls.Add(this.label1);
			this.Name = "OfficerPanelView";
			((System.ComponentModel.ISupportInitialize)(this._queueBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox _officerQueueListBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.BindingSource _queueBindingSource;
		private System.Windows.Forms.Timer _updateQueueTimer;

	}
}

