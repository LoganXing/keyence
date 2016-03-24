//------------------------------------------------------------------------------ 
// <copyright file="MainForm.cs" company="KEYENCE">
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
using Sample.Data;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace Sample
{
	public partial class MainForm : Form
	{

		#region �萔
		/// <summary>1�v���t�@�C���̃f�[�^����MAX�l</summary>
		private const int MAX_PROFILE_COUNT = 3200;

		/// <summary>�f�o�C�XID(0�Œ�)</summary>
		private const int DEVICE_ID = 0;

		#endregion	

		#region �t�B�[���h
		/// <summary>�����ʐM�p�R�[���o�b�N�֐�</summary>
		private HightSpeedDataCallBack _callback;

		/// <summary>�C�[�T�l�b�g�ʐM�ݒ�</summary>
		private LJV7IF_ETHERNET_CONFIG _ethernetConfig;

		#endregion

		#region ���\�b�h
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			_ethernetConfig = new LJV7IF_ETHERNET_CONFIG();
			_callback = new HightSpeedDataCallBack(ReceiveData);
		}

		/// <summary>
		/// ���^�[���R�[�h�̃`�F�b�N
		/// </summary>
		/// <param name="rc">���^�[���R�[�h</param>
		/// <returns>OK���ǂ���</returns>
		/// <remarks>OK�łȂ��ꍇ�A���b�Z�[�W�\���������false��Ԃ�</remarks>
		private bool CheckReturnCode(Rc rc)
		{
			if (rc == Rc.Ok) return true;
			MessageBox.Show(this, string.Format("Error: 0x{0,8:x}", rc), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return false;
		}

		/// <summary>
		/// �v���t�@�C���f�[�^���t�@�C���ɏo��
		/// </summary>
		/// <param name="profileDatas">�o�͂���v���t�@�C���f�[�^</param>
		/// <param name="savePath">�ۑ���t�@�C���̃t���p�X</param>
		/// <remarks>TSV�`���ŏo��</remarks>
		private static void SaveProfile(List<ProfileData> profileDatas, string savePath)
		{
			try
			{
				// �v���t�@�C����ۑ�
				using (StreamWriter sw = new StreamWriter(savePath, false, Encoding.GetEncoding("utf-16")))
				{
					// X���̏o��
					sw.WriteLine(ProfileData.GetXPosString(profileDatas[0].ProfInfo));

					// �e�v���t�@�C���f�[�^���o��
					foreach (ProfileData profile in profileDatas)
					{
						sw.WriteLine(profile.ToString());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// �����ʐM�̃R�[���o�b�N����
		/// </summary>
		/// <param name="buffer">��M�f�[�^�̐擪�|�C���^</param>
		/// <param name="size">��M�f�[�^��1�v���t�@�C���������BYTE�T�C�Y</param>
		/// <param name="count">�v���t�@�C����</param>
		/// <param name="notify">�I���������ǂ���</param>
		/// <param name="user">�����f�[�^�ʐM���������ɓn�������(�X���b�hID)</param>
		private static void ReceiveData(IntPtr buffer, uint size, uint count, uint notify, uint user)
		{
			// ��M��BYTE�P�ʂȂ̂�INT�P�ʂ̂܂Ƃ܂�ɐݒ�
			uint profileSize = size / sizeof(int);
			List<int[]> reciveBuffer = new List<int[]>();
			int[] bufferArray = new int[profileSize * count];
			Marshal.Copy(buffer, bufferArray, 0, (int)(profileSize * count));
			// �v���t�@�C���f�[�^�ێ�
			for (int i = 0; i < count; i++)
			{
				int[] oneProfile = new int[profileSize];
				Array.Copy(bufferArray, i * profileSize, oneProfile, 0, profileSize);
				reciveBuffer.Add(oneProfile);
			}

			ThreadSafeBuffer.Add(reciveBuffer, notify);
		}

		#endregion

		#region �C�x���g�n���h��
		/// <summary>
		/// �u�������v�{�^������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _btnInitialize_Click(object sender, EventArgs e)
		{
			Rc rc = Rc.Ok;
			// DLL��������
			rc = (Rc)NativeMethods.LJV7IF_Initialize();
			if (!CheckReturnCode(rc)) return;

			// �ʐM�o�H���I�[�v��
			if (_rdUsb.Checked)
			{
				rc = (Rc)NativeMethods.LJV7IF_UsbOpen(DEVICE_ID);
			}
			else
			{
				// Ethernet�ʐM�p�ݒ�𐶐�
				try
				{
					_ethernetConfig.abyIpAddress = new byte[] {
						Convert.ToByte(_txtIpFirstSegment.Text),
						Convert.ToByte(_txtIpSecondSegment.Text),
						Convert.ToByte(_txtIpThirdSegment.Text),
						Convert.ToByte(_txtIpFourthSegment.Text)
					};
					_ethernetConfig.wPortNo = Convert.ToUInt16(_txtCommandPort.Text);
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message);
					return;
				}

				rc = (Rc)NativeMethods.LJV7IF_EthernetOpen(DEVICE_ID, ref _ethernetConfig);
			}
			if (!CheckReturnCode(rc)) return;
		}

		/// <summary>
		/// �u�I���v�{�^������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _btnFinalize_Click(object sender, EventArgs e)
		{
			Rc rc = Rc.Ok;
			// �ʐM���N���[�Y
			rc = (Rc)NativeMethods.LJV7IF_CommClose(DEVICE_ID);
			if (!CheckReturnCode(rc)) return;

			// DLL�̏I������
			rc = (Rc)NativeMethods.LJV7IF_Finalize();
			if (!CheckReturnCode(rc)) return;
		}

		/// <summary>
		/// �u�ŐV�v���l�擾�v�{�^������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _btnGetMeasureData_Click(object sender, EventArgs e)
		{
			LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MesurementDataCount];
			Rc rc = (Rc)NativeMethods.LJV7IF_GetMeasurementValue(DEVICE_ID, measureData);
			if (!CheckReturnCode(rc)) return;
			MeasureData data = new MeasureData(measureData);

			_txtMeasureData.Text = data.ToString();
		}

		/// <summary>
		/// �u...�v�{�^������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _btnReferenceSavePath_Click(object sender, EventArgs e)
		{
			if (_saveFileDialog.ShowDialog() != DialogResult.OK) return;
			_txtSavePath.Text = _saveFileDialog.FileName;
		}

		/// <summary>
		/// �u�������[�h�v���t�@�C���擾�v�{�^������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _btnGetProfile_Click(object sender, EventArgs e)
		{			
			LJV7IF_GET_PROFILE_REQ req = new LJV7IF_GET_PROFILE_REQ();
			req.byTargetBank = ProfileBank.Active;
			req.byPosMode = ProfilePos.Current;
			req.dwGetProfNo = 0;
			req.byGetProfCnt = 10;
			req.byErase = 0;

			LJV7IF_GET_PROFILE_RSP rsp = new LJV7IF_GET_PROFILE_RSP();
			LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();

			int profileDataSize = MAX_PROFILE_COUNT + 
				(Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / sizeof(int);
			int[] receiveBuffer = new int[profileDataSize * req.byGetProfCnt];

			using (ProgressForm progressForm = new ProgressForm())
			{
				Cursor.Current = Cursors.WaitCursor;

				progressForm.Status = Status.Communicating;
				progressForm.Show(this);
				progressForm.Refresh();

				// �v���t�@�C�����擾
				using (PinnedObject pin = new PinnedObject(receiveBuffer))
				{
					Rc rc = (Rc)NativeMethods.LJV7IF_GetProfile(DEVICE_ID, ref req, ref rsp, ref profileInfo, pin.Pointer, 
						(uint)(receiveBuffer.Length * sizeof(int)));
					if (!CheckReturnCode(rc)) return;
				}

				// �e�v���t�@�C���f�[�^���o��
				List<ProfileData> profileDatas = new List<ProfileData>();
				int unitSize = ProfileData.CalculateDataSize(profileInfo);
				for (int i = 0; i < rsp.byGetProfCnt; i++)
				{
					profileDatas.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
				}

				progressForm.Status = Status.Saving;
				progressForm.Refresh();

				// �t�@�C���ۑ�
				SaveProfile(profileDatas, _txtSavePath.Text);
			}
		}

		/// <summary>
		/// �u�������[�h�o�b�`�v���t�@�C���擾�v�{�^������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _btnGetBatchProfile_Click(object sender, EventArgs e)
		{
			// �擾�Ώۃo�b�`���w��
			LJV7IF_GET_BATCH_PROFILE_REQ req = new LJV7IF_GET_BATCH_PROFILE_REQ();
			req.byTargetBank = ProfileBank.Active;
			req.byPosMode = BatchPos.Commited;
			req.dwGetBatchNo = 0;
			req.dwGetProfNo = 0;
			req.byGetProfCnt = byte.MaxValue;
			req.byErase = 0;

			LJV7IF_GET_BATCH_PROFILE_RSP rsp = new LJV7IF_GET_BATCH_PROFILE_RSP();
			LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();

			int profileDataSize = MAX_PROFILE_COUNT + 
				(Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / sizeof(int);
			int[] receiveBuffer = new int[profileDataSize * req.byGetProfCnt];

			using (ProgressForm progressForm = new ProgressForm())
			{
				Cursor.Current = Cursors.WaitCursor;

				progressForm.Status = Status.Communicating;
				progressForm.Show(this);
				progressForm.Refresh();

				List<ProfileData> profileDatas = new List<ProfileData>();
				// �v���t�@�C�����擾
				using (PinnedObject pin = new PinnedObject(receiveBuffer))
				{
					Rc rc = (Rc)NativeMethods.LJV7IF_GetBatchProfile(DEVICE_ID, ref req, ref rsp, ref profileInfo, pin.Pointer, 
						(uint)(receiveBuffer.Length * sizeof(int)));
					if (!CheckReturnCode(rc)) return;

					// �e�v���t�@�C���f�[�^���o��
					int unitSize = ProfileData.CalculateDataSize(profileInfo);
					for (int i = 0; i < rsp.byGetProfCnt; i++)
					{
						profileDatas.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
					}

					// �o�b�`���̃v���t�@�C�������ׂĎ擾
					req.byPosMode = BatchPos.Spec;
					req.dwGetBatchNo = rsp.dwGetBatchNo;
					do
					{
						// �擾�v���t�@�C���ʒu���X�V
						req.dwGetProfNo = rsp.dwGetBatchTopProfNo + rsp.byGetProfCnt;
						req.byGetProfCnt = (byte)Math.Min((uint)(byte.MaxValue), (rsp.dwCurrentBatchProfCnt - req.dwGetProfNo));

						rc = (Rc)NativeMethods.LJV7IF_GetBatchProfile(DEVICE_ID, ref req, ref rsp, ref profileInfo, pin.Pointer,
							(uint)(receiveBuffer.Length * sizeof(int)));
						if (!CheckReturnCode(rc)) return;
						for (int i = 0; i < rsp.byGetProfCnt; i++)
						{
							profileDatas.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
						}
					} while (rsp.dwGetBatchProfCnt != (rsp.dwGetBatchTopProfNo + rsp.byGetProfCnt));
				}

				progressForm.Status = Status.Saving;
				progressForm.Refresh();
				// �t�@�C���ۑ�
				SaveProfile(profileDatas, _txtSavePath.Text);
				
			}
		}

		/// <summary>
		/// �u���@�\���[�h�v���t�@�C���擾�v�{�^������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _btnGetProfileAdvance_Click(object sender, EventArgs e)
		{
			LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
			LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MesurementDataCount];
			int profileDataSize = MAX_PROFILE_COUNT + 
				(Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / sizeof(int);
			int[] receiveBuffer = new int[profileDataSize];

			// �v���t�@�C�����擾
			using (PinnedObject pin = new PinnedObject(receiveBuffer))
			{
				Rc rc = (Rc)NativeMethods.LJV7IF_GetProfileAdvance(DEVICE_ID, ref profileInfo, pin.Pointer, 
					(uint)(receiveBuffer.Length * sizeof(int)), measureData);
				if (!CheckReturnCode(rc)) return;
			}

			List<ProfileData> profileDatas = new List<ProfileData>();
			// �e�v���t�@�C���f�[�^���o��
			profileDatas.Add(new ProfileData(receiveBuffer, 0, profileInfo));

			// �t�@�C���ۑ�
			SaveProfile(profileDatas, _txtSavePath.Text);
		}

		/// <summary>
		/// �u���@�\���[�h�o�b�`�v���t�@�C���擾�v�{�^������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _btnGetBatchProfileAdvance_Click(object sender, EventArgs e)
		{
			MessageBox.Show("���@�\���[�h�o�b�`�v���t�@�C���擾���J�n���܂��B\nLJ-Navigator 2 ���N�����Ă��Ȃ����Ƃ����m�F�̂����AOK�������Ă��������B");
			LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ req = new LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ();
			req.byPosMode = BatchPos.Commited;
			req.dwGetBatchNo = 0;
			req.dwGetProfNo = 0;
			req.byGetProfCnt = byte.MaxValue;

			LJV7IF_GET_BATCH_PROFILE_ADVANCE_RSP rsp = new LJV7IF_GET_BATCH_PROFILE_ADVANCE_RSP();
			LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
			LJV7IF_MEASURE_DATA[] batchMeasureData = new LJV7IF_MEASURE_DATA[NativeMethods.MesurementDataCount];
			LJV7IF_MEASURE_DATA[] measureData = new LJV7IF_MEASURE_DATA[NativeMethods.MesurementDataCount];

			int profileDataSize = MAX_PROFILE_COUNT + 
				(Marshal.SizeOf(typeof(LJV7IF_PROFILE_HEADER)) + Marshal.SizeOf(typeof(LJV7IF_PROFILE_FOOTER))) / sizeof(int);
			int measureDataSize = Marshal.SizeOf(typeof(LJV7IF_MEASURE_DATA)) * NativeMethods.MesurementDataCount / sizeof(int);
			int[] receiveBuffer = new int[(profileDataSize + measureDataSize) * req.byGetProfCnt];

			using (ProgressForm progressForm = new ProgressForm())
			{
				Cursor.Current = Cursors.WaitCursor;
				progressForm.Status = Status.Communicating;
				progressForm.Show(this);
				progressForm.Refresh();

				List<ProfileData> profileDatas = new List<ProfileData>();
				// �v���t�@�C�����擾
				using (PinnedObject pin = new PinnedObject(receiveBuffer))
				{
					Rc rc = (Rc)NativeMethods.LJV7IF_GetBatchProfileAdvance(DEVICE_ID, ref req, ref rsp, ref profileInfo, pin.Pointer,
						(uint)(receiveBuffer.Length * sizeof(int)), batchMeasureData, measureData);
					if (!CheckReturnCode(rc)) return;

					// �e�v���t�@�C���f�[�^���o��
					int unitSize = ProfileData.CalculateDataSize(profileInfo) + measureDataSize;
					for (int i = 0; i < rsp.byGetProfCnt; i++)
					{
						profileDatas.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
					}

					// �o�b�`���̃v���t�@�C�������ׂĎ擾
					req.byPosMode = BatchPos.Spec;
					req.dwGetBatchNo = rsp.dwGetBatchNo;
					do
					{
						// �擾�v���t�@�C���ʒu���X�V
						req.dwGetProfNo = rsp.dwGetBatchTopProfNo + rsp.byGetProfCnt;
						req.byGetProfCnt = (byte)Math.Min((uint)(byte.MaxValue), (rsp.dwGetBatchProfCnt - req.dwGetProfNo));

						rc = (Rc)NativeMethods.LJV7IF_GetBatchProfileAdvance(DEVICE_ID, ref req, ref rsp, ref profileInfo, pin.Pointer,
							(uint)(receiveBuffer.Length * sizeof(int)), batchMeasureData, measureData);
						if (!CheckReturnCode(rc)) return;
						for (int i = 0; i < rsp.byGetProfCnt; i++)
						{
							profileDatas.Add(new ProfileData(receiveBuffer, unitSize * i, profileInfo));
						}
					} while (rsp.dwGetBatchProfCnt != (rsp.dwGetBatchTopProfNo + rsp.byGetProfCnt));
				}

				progressForm.Status = Status.Saving;
				progressForm.Refresh();

				// �t�@�C���ۑ�
				SaveProfile(profileDatas, _txtSavePath.Text);
			}
		}

		/// <summary>
		/// �����f�[�^�ʐM�u�J�n�v�{�^������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _btnStartHighSpeed_Click(object sender, EventArgs e)
		{
			// �����f�[�^�ʐM��~�E�I��
			NativeMethods.LJV7IF_StopHighSpeedDataCommunication(DEVICE_ID);
			NativeMethods.LJV7IF_HighSpeedDataCommunicationFinalize(DEVICE_ID);
			
			// �f�[�^��������
			ThreadSafeBuffer.Clear();
			Rc rc = Rc.Ok;
						
			// �����ʐM�o�H��������
			// �����ʐM�J�n����
			LJV7IF_HIGH_SPEED_PRE_START_REQ req = new LJV7IF_HIGH_SPEED_PRE_START_REQ();
			try
			{
				uint frequency = Convert.ToUInt32(_txtCallbackFrequency.Text);
				uint threadId = (uint)DEVICE_ID;

				if (_rdUsb.Checked)
				{
					// USB�����f�[�^�ʐM������
					rc = (Rc)NativeMethods.LJV7IF_HighSpeedDataUsbCommunicationInitalize(DEVICE_ID, _callback, frequency, threadId);
				}
				else
				{
					// Ethernet�ʐM�p�ݒ�𐶐�
					ushort highSpeedPort = 0;
					_ethernetConfig.abyIpAddress = new byte[] {
						Convert.ToByte(_txtIpFirstSegment.Text),
						Convert.ToByte(_txtIpSecondSegment.Text),
						Convert.ToByte(_txtIpThirdSegment.Text),
						Convert.ToByte(_txtIpFourthSegment.Text)
					};
					_ethernetConfig.wPortNo = Convert.ToUInt16(_txtCommandPort.Text);
					highSpeedPort = Convert.ToUInt16(_txtHighSpeedPort.Text);

					// Ethernet�����f�[�^�ʐM������
					rc = (Rc)NativeMethods.LJV7IF_HighSpeedDataEthernetCommunicationInitalize(DEVICE_ID, ref _ethernetConfig,
						highSpeedPort, _callback, frequency, threadId);
				}
				if (!CheckReturnCode(rc)) return;
				req.bySendPos = Convert.ToByte(_txtStartProfileNo.Text);
			}
			catch (FormatException ex)
			{
				MessageBox.Show(this, ex.Message);
				return;
			}
			catch (OverflowException ex)
			{
				MessageBox.Show(this, ex.Message);
				return;
			}

			// �����f�[�^�ʐM�J�n����
			LJV7IF_PROFILE_INFO profileInfo = new LJV7IF_PROFILE_INFO();
			rc = (Rc)NativeMethods.LJV7IF_PreStartHighSpeedDataCommunication(DEVICE_ID, ref req, ref profileInfo);
			if (!CheckReturnCode(rc)) return;

			// �����f�[�^�ʐM�J�n
			rc = (Rc)NativeMethods.LJV7IF_StartHighSpeedDataCommunication(DEVICE_ID);
			if (!CheckReturnCode(rc)) return;

			_lblReceiveProfileCount.Text = "0";
			_timerHighSpeed.Start();
		}

		/// <summary>
		/// �����f�[�^�ʐM�u�I���v�{�^������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _btnEndHighSpeed_Click(object sender, EventArgs e)
		{
			// �����f�[�^�ʐM��~
			Rc rc = (Rc)NativeMethods.LJV7IF_StopHighSpeedDataCommunication(DEVICE_ID);
			if (CheckReturnCode(rc))
			{
				// �����f�[�^�ʐM�I��
				rc = (Rc)NativeMethods.LJV7IF_HighSpeedDataCommunicationFinalize(DEVICE_ID);
				CheckReturnCode(rc);
			}
		}

		/// <summary>
		/// �^�C�}�[�C�x���g�n���h��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _timerHighSpeed_Tick(object sender, EventArgs e)
		{
			uint notify = 0;
			List<int[]> data = ThreadSafeBuffer.Get(ref notify);

			uint count = 0;
			foreach (int[] profile in data)
			{
				// �����Ŏ�M�f�[�^�����H����
				count++;
			}
			_lblReceiveProfileCount.Text = (Convert.ToUInt32(_lblReceiveProfileCount.Text) + count).ToString();
			
			if ((notify & 0xFFFF) != 0)
			{
				// notify�̉���16bit��0�łȂ��ꍇ�A�����ʐM�����f���ꂽ�̂Ń^�C�}�[���Ƃ߂�B
				_timerHighSpeed.Stop();
				MessageBox.Show(string.Format("�ʐM�I�����܂����B0x{0:x8}", notify));
			}

			if ((notify & 0x10000) != 0)
			{
				// �o�b�`���芮�����̏������K�v�ł���΂����ɋL�q����B
			}
		}

		/// <summary>
		/// �ʐM��i�ύX�C�x���g�n���h��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _rdCommunication_CheckedChanged(object sender, EventArgs e)
		{
			_grpEthernetSetting.Enabled = _rdEthernet.Checked;
		}
		#endregion	
	}
}