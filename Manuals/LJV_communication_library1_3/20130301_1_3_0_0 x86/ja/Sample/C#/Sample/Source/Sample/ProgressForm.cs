//------------------------------------------------------------------------------ 
// <copyright file="ProgressForm.cs" company="KEYENCE">
//     Copyright (c) 2012 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sample
{
	/// <summary>
	/// �������
	/// </summary>
	public enum Status
	{
		Communicating = 0,
		Saving,
	};

	public partial class ProgressForm : Form
	{
		/// <summary>
		/// �������
		/// </summary>
		private Status _status;

		/// <summary>
		/// �������
		/// </summary>
		public Status Status
		{
			set 
			{
				_status = value;
				switch (_status)
				{
				case Status.Communicating:
					_lblStatus.Text = "�ʐM��";
					break;
				case Status.Saving:
					_lblStatus.Text = "�t�@�C���ۑ���";
					break;
				default:
					return;
				}
			}
			get { return _status; }
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public ProgressForm()
		{
			InitializeComponent();
			_status = Status.Communicating;
		}
	}
}