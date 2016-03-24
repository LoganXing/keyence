//------------------------------------------------------------------------------ 
// <copyright file="NativeMethods.cs" company="KEYENCE">
//     Copyright (c) 2012 KEYENCE CORPORATION.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Sample
{
	#region �񋓌^
	/// <summary>
	/// �߂�l��`
	/// </summary>
	public enum Rc
	{
		/// <summary>����I��</summary>
		Ok = 0x0000,
		/// <summary>�f�o�C�X�̃I�[�v���Ɏ��s</summary>
		ErrOpenDevice = 0x1000,
		/// <summary>�f�o�C�X���I�[�v������Ă��Ȃ�</summary>
		ErrNoDevice,
		/// <summary>�R�}���h���M�G���[</summary>
		ErrSend,
		/// <summary>���X�|���X��M�G���[</summary>
		ErrReceive,
		/// <summary>�^�C���A�E�g</summary>
		ErrTimeout,
		/// <summary>�󂫃������Ȃ�</summary>
		ErrNomemory,
		/// <summary>�p�����[�^�G���[</summary>
		ErrParameter,
		/// <summary>��M�w�b�_�̃t�H�[�}�b�g�G���[</summary>
		ErrRecvFmt,
		
		/// <summary>��OPEN�G���[(�����ʐM�p)</summary>
		ErrHispeedNoDevice = 0x1009,	
		/// <summary>OPEN�ς݃G���[(�����ʐM�p)</summary>
		ErrHispeedOpenYet,
		/// <summary>���ɍ����ʐM���G���[(�����ʐM�p)</summary>
		ErrHispeedRecvYet,		
		/// <summary>�o�b�t�@�T�C�Y�s��</summary>
		ErrBufferShort,
	}

	/// �ݒ�l�i�[�K�w�̎w��
	public enum SettingDepth : byte
	{
		/// <summary>�ݒ菑�����ݗ̈�</summary>
		Write	= 0x00,
		/// <summary>���쒆�ݒ�̈�</summary>
		Running	= 0x01,
		/// <summary>�ۑ��p�̈�</summary>
		Save	= 0x02,	
	};

	/// ����l�̗L��������������`
	public enum MeasureDataInfo : byte
	{
		/// <summary>���萳��f�[�^</summary>
		Valid	= 0x00,
		/// <summary>����A���[���f�[�^</summary>
		Alarm	= 0x01,
		/// <summary>����ҋ@�l�f�[�^</summary>
		Wait	= 0x02,
	};

	/// ����l�̔��茋�ʂ�������`
	[Flags]
	public enum JudgeResult : byte
	{
		Hi	= 0x01,
		Go	= 0x02,
		Lo	= 0x04,
	};

	/// �v���t�@�C���擾�Ώۃo�b�t�@�̎w��
	public enum ProfileBank : byte
	{
		/// <summary>�A�N�e�B�u��</summary>
		Active		= 0x00,
		/// <summary>��A�N�e�B�u��</summary>		
		Inactive	= 0x01,
	};

	/// �v���t�@�C���擾�ʒu�w����@�̎w��
	public enum ProfilePos : byte
	{
		/// <summary>�ŐV����</summary>
		Current	= 0x00,
		/// <summary>�ŌÂ���</summary>
		Oldest	= 0x01,
		/// <summary>�ʒu���w��</summary>
		Spec	= 0x02,
	};

	/// �o�b�`�v���t�@�C���擾�ʒu�w����@�̎w��
	public enum BatchPos : byte
	{
		/// <summary>�ŐV����</summary>
		Current		= 0x00,
		/// <summary>�ʒu���w��</summary>
		Spec		= 0x02,
		/// <summary>�m���̍ŐV����</summary>
		Commited	= 0x03,
		/// <summary>�ŐV�̂�</summary>
		CurrentOnly	= 0x04,
	};

	#endregion

	#region �\����
	/// <summary>
	/// �d���������������ݒ�\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_ETHERNET_CONFIG
	{
		/// <summary>IP�A�h���X</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] abyIpAddress;
		/// <summary>�R�}���h�ʐM�p�|�[�g�ԍ�</summary>
		public ushort wPortNo;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] reserve;

	};

	/// <summary>
	/// �����\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_TIME
	{
		/// <summary>�N</summary>
		public byte byYear;
		/// <summary>��</summary>
		public byte byMonth;
		/// <summary>��</summary>
		public byte byDay;
		/// <summary>��</summary>
		public byte byHour;
		/// <summary>��</summary>
		public byte byMinute;
		/// <summary>�b</summary>
		public byte bySecond;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] reserve;
	};

	/// <summary>
	/// �ݒ荀�ڎw��\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_TARGET_SETTING
	{
		/// <summary>�ݒ���</summary>
		public byte byType;
		/// <summary>�ݒ�J�e�S��</summary>
		public byte byCategory;
		/// <summary>�ݒ荀��</summary>
		public byte byItem;
		public byte reserve;
		/// <summary>�ݒ�Ώ�1</summary>
		public byte byTarget1;
		/// <summary>�ݒ�Ώ�2</summary>
		public byte byTarget2;
		/// <summary>�ݒ�Ώ�3</summary>
		public byte byTarget3;
		/// <summary>�ݒ�Ώ�4</summary>
		public byte byTarget4;
	};

	/// <summary>
	/// ���茋�ʍ\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_MEASURE_DATA
	{
		/// <summary>����l���L���l��</summary>
		public MeasureDataInfo byDataInfo;
		/// <summary>�������茋��</summary>
		public JudgeResult byJudge;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] reserve;
		/// <summary>����l</summary>
		public float fValue;
	};

	/// <summary>
	/// �v���t�@�C�����\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_PROFILE_INFO
	{
		/// <summary>�v���t�@�C���f�[�^�������i�[����Ă��邩</summary>
		public byte byProfileCnt;
		/// <summary>�v���t�@�C�����k�i���Ԏ��j���n�m���ǂ���</summary>
		public byte byEnvelope;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] reserve;
		/// <summary>�v���t�@�C���̃f�[�^��</summary>
		public short wProfDataCnt;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] reserve2;
		/// <summary>1�_�ڂ�X���W</summary>
		public int lXStart;
		/// <summary>�v���t�@�C���f�[�^��X�����Ԋu</summary>
		public int lXPitch;
	};

	/// <summary>
	/// �v���t�@�C���w�b�_�[���\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_PROFILE_HEADER
	{
		public uint reserve;
		/// <summary>����J�n���牽��ڂ̃g���K�̃v���t�@�C����</summary>
		public uint dwTriggerCnt;
		/// <summary>����J�n���牽��ڂ̃G���R�[�_�g���K�̃v���t�@�C����</summary>
		public uint dwEncoderCnt;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public uint[] reserve2;
	};

	/// <summary>
	/// �v���t�@�C���t�b�^�[���\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_PROFILE_FOOTER
	{
		public uint reserve;
	};

	/// <summary>
	/// �������[�h�v���t�@�C���擾�v���\���́i�o�b�`����F�n�e�e�j
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_PROFILE_REQ
	{
		/// <summary>�Ώۖ�</summary>
		public ProfileBank byTargetBank;
		/// <summary>�v���t�@�C���ʒu�w����@</summary>
		public ProfilePos byPosMode;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] reserve;
		/// <summary>�擾�Ώۂ̃v���t�@�C���ԍ�</summary>
		public uint dwGetProfNo;
		/// <summary>�ǂݏo���v���t�@�C���̐�</summary>
		public byte byGetProfCnt;
		/// <summary>�ǂݏo�����v���t�@�C�����R���g���[������������邩</summary>
		public byte byErase;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] reserve2;
	};

	/// <summary>
	/// �������[�h�v���t�@�C���擾�v���\���́i�o�b�`����F�n�m�j
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_BATCH_PROFILE_REQ
	{
		/// <summary>�Ώۖ�</summary>
		public ProfileBank byTargetBank;
		/// <summary>�o�b�`�ʒu�w����@</summary>
		public BatchPos byPosMode;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] reserve;
		/// <summary>�擾�Ώۂ̃v���t�@�C���̃o�b�`�ԍ�</summary>
		public uint dwGetBatchNo;
		/// <summary>�w��o�b�`�ԍ����̎擾�J�n�v���t�@�C���ԍ�</summary>
		public uint dwGetProfNo;
		/// <summary>�ǂݏo���v���t�@�C���̐�</summary>
		public byte byGetProfCnt;
		/// <summary>�ǂݏo�����v���t�@�C�����R���g���[������������邩</summary>
		public byte byErase;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] reserve2;
	};

	/// <summary>
	/// ���@�\���[�h�v���t�@�C���擾�v���\���́i�o�b�`����F�n�m�j
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ
	{
		/// <summary>�o�b�`�ʒu�w����@</summary>
		public BatchPos byPosMode;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] reserve;
		/// <summary>�擾�Ώۂ̃v���t�@�C���̃o�b�`�ԍ�</summary>
		public uint dwGetBatchNo;
		/// <summary>�w��o�b�`�ԍ����̎擾�J�n�v���t�@�C���ԍ�</summary>
		public uint dwGetProfNo;
		/// <summary>�ǂݏo���v���t�@�C���̐�</summary>
		public byte byGetProfCnt;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] reserve2;
	};

	/// <summary>
	/// �������[�h�v���t�@�C���擾�ԐM�\���́i�o�b�`����F�n�e�e�j
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_PROFILE_RSP
	{
		/// <summary>�ŐV�v���t�@�C���ԍ�</summary>
		public uint dwCurrentProfNo;
		/// <summary>�R���g���[�����̍ŌÃv���t�@�C���ԍ�</summary>
		public uint dwOldestProfNo;
		/// <summary>�ǂݏo�����v���t�@�C���̐擪�ԍ�</summary>
		public uint dwGetTopProfNo;
		/// <summary>�ǂݏo�����v���t�@�C����</summary>
		public byte byGetProfCnt;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] reserve;
	};

	/// <summary>
	/// �������[�h�v���t�@�C���擾�ԐM�\���́i�o�b�`����F�n�m�j
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_BATCH_PROFILE_RSP
	{
		/// <summary>�ŐV�o�b�`�ԍ�</summary>
		public uint dwCurrentBatchNo;
		/// <summary>�ŐV�o�b�`���̃v���t�@�C���̐�</summary>
		public uint dwCurrentBatchProfCnt;
		/// <summary>�R���g���[�����ێ�����A�ł��Â��o�b�`�̃o�b�`�ԍ�</summary>
		public uint dwOldestBatchNo;
		/// <summary>�R���g���[�����ێ�����A�ł��Â��o�b�`���̃v���t�@�C���̐�</summary>
		public uint dwOldestBatchProfCnt;
		/// <summary>�ǂݏo�����o�b�`�ԍ�</summary>
		public uint dwGetBatchNo;
		/// <summary>�ǂݏo�����o�b�`���̃v���t�@�C���̐�</summary>
		public uint dwGetBatchProfCnt;
		/// <summary>�ǂݏo�������ŁA��ԌÂ��v���t�@�C�����o�b�`���̉��Ԗڂ̃v���t�@�C����</summary>
		public uint dwGetBatchTopProfNo;
		/// <summary>�ǂݏo�����v���t�@�C���̐�</summary>
		public byte byGetProfCnt;
		/// <summary>�ŐV�o�b�`No.�̃o�b�`���肪�������Ă��邩</summary>
		public byte byCurrentBatchCommited;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] reserve;
	};

	/// <summary>
	/// ���@�\���[�h�v���t�@�C���擾�ԐM�\���́i�o�b�`����F�n�m�j
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_BATCH_PROFILE_ADVANCE_RSP
	{
		/// <summary>�ǂݏo�����o�b�`�ԍ�</summary>
		public uint dwGetBatchNo;
		/// <summary>�ǂݏo�����o�b�`���̃v���t�@�C���̐�</summary>
		public uint dwGetBatchProfCnt;
		/// <summary>�ǂݏo�������ŁA��ԌÂ��v���t�@�C�����o�b�`���̉��Ԗڂ̃v���t�@�C����������</summary>
		public uint dwGetBatchTopProfNo;
		/// <summary>�ǂݏo�����v���t�@�C���̐�</summary>
		public byte byGetProfCnt;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] reserve;
	};

	/// <summary>
	/// �X�g���[�W��ԗv���\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_STRAGE_STATUS_REQ
	{
		/// <summary>�ǂݏo���Ώۖ�</summary>
		public uint dwRdArea;
	};

	/// <summary>
	/// �X�g���[�W��ԕԐM�\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_STRAGE_STATUS_RSP
	{
		/// <summary>�X�g���[�W�ʐ�</summary>
		public uint dwSurfaceCnt;
		/// <summary>�A�N�e�B�u�X�g���[�W��</summary>
		public uint dwActiveSurface;
	};

	/// <summary>
	/// �X�g���[�W���\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_STORAGE_INFO
	{
		/// <summary>�X�g���[�W���</summary>
		public byte byStatus;
		/// <summary>�Y���X�g���[�W�ʂ̃v���O����No</summary>
		public byte byProgramNo;
		/// <summary>�X�g���[�W�Ώ�</summary>
		public byte byTarget;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
		public byte[] reserve;
		/// <summary>�X�g���[�W�_��</summary>
		public uint dwStorageCnt;
	};

	/// <summary>
	/// �X�g���[�W�f�[�^�擾�v���\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_STORAGE_REQ
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] reserve;
		/// <summary>�ǂݏo���X�g���[�W��</summary>
		public uint dwSurface;
		/// <summary>�ǂݏo���J�n����X�g���[�W�ԍ�</summary>
		public uint dwStartNo;
		/// <summary>�ǂݏo���_��</summary>
		public uint dwDataCnt;
	};

	/// <summary>
	/// �o�b�`�v���t�@�C���X�g���[�W�擾�v���\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_BATCH_PROFILE_STORAGE_REQ
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] reserve;
		/// <summary>�ǂݏo���X�g���[�W��</summary>
		public uint dwSurface;
		/// <summary>�ǂݏo���o�b�`�ԍ�</summary>
		public uint dwGetBatchNo;
		/// <summary>�o�b�`���̓ǂݏo���J�n�v���t�@�C���ԍ�</summary>
		public uint dwGetBatchTopProfNo;
		/// <summary>�ǂݏo���v���t�@�C���_��</summary>
		public byte byGetProfCnt;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] reserved;
	};

	/// <summary>
	/// �X�g���[�W�f�[�^�擾�ԐM�\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_STORAGE_RSP
	{
		/// <summary>�ǂݏo���J�n����X�g���[�W�ԍ�</summary>
		public uint dwStartNo;
		/// <summary>�ǂݏo���_��</summary>
		public uint dwDataCnt;
		/// <summary>�����</summary>
		public LJV7IF_TIME stBaseTime;
	};
	/// <summary>
	/// �o�b�`�v���t�@�C���X�g���[�W�擾�ԐM�\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_GET_BATCH_PROFILE_STORAGE_RSP
	{
		/// <summary>�ǂݏo���o�b�`�ԍ�</summary>
		public uint dwGetBatchNo;
		/// <summary>�ǂݏo�o�b�`���̃v���t�@�C����</summary>
		public uint dwGetBatchProfCnt;
		/// <summary>�o�b�`���̓ǂݏo���J�n�v���t�@�C���ԍ�</summary>
		public uint dwGetBatchTopProfNo;
		/// <summary>�ǂݏo���v���t�@�C���_��</summary>
		public byte byGetProfCnt;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] reserve;
		/// <summary>�����</summary>
		public LJV7IF_TIME stBaseTime;
	};

	/// <summary>
	/// �����ʐM�J�n�����v���\����
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct LJV7IF_HIGH_SPEED_PRE_START_REQ
	{
		/// <summary>���M�J�n�ʒu</summary>
		public byte bySendPos;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] reserve;
	};

	#endregion

	/// <summary>
	/// �����ʐM�p�R�[���o�b�N�֐�
	/// </summary>
	/// <param name="buffer">��M�v���t�@�C���f�[�^�̃|�C���^</param>
	/// <param name="size">1�v���t�@�C����BYTE�P�ʂ̃T�C�Y</param>
	/// <param name="count">�v���t�@�C����</param>
	/// <param name="notify">�I������</param>
	/// <param name="user">�X���b�hID</param>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void HightSpeedDataCallBack(IntPtr buffer, uint size, uint count, uint notify, uint user);

	/// <summary>
	/// DLL�֐��Ăяo���p�N���X
	/// </summary>	
	internal static class NativeMethods
	{
		/// <summary>
		/// ���茋�ʐ��̌Œ�l
		/// </summary>
		internal static int MesurementDataCount
		{
			get { return 16; }
		}

		/// <summary>
		/// DLL������
		/// </summary>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_Initialize();

		/// <summary>
		/// DLL�I������
		/// </summary>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_Finalize();

		/// <summary>
		/// DLL�o�[�W�����擾
		/// </summary>
		/// <returns>DLL�o�[�W����</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern uint LJV7IF_GetVersion();

		/// <summary>
		/// USB�ʐM�ڑ�
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_UsbOpen(int lDeviceId);

		/// <summary>
		/// Ethernet�ʐM�ڑ�
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="ethernetConfig">Ethernet�ݒ�</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_EthernetOpen(int lDeviceId, ref LJV7IF_ETHERNET_CONFIG ethernetConfig);

		/// <summary>
		/// �ʐM�o�H�ؒf
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_CommClose(int lDeviceId);

		/// <summary>
		/// �R���g���[���ċN��
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_RebootController(int lDeviceId);

		/// <summary>
		/// �H��o�׏�Ԃ֖߂�
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_RetrunToFactorySetting(int lDeviceId);

		/// <summary>
		/// �V�X�e���G���[���擾
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="byRcvMax">�V�X�e���G���[�����ő剽�܂Ŏ󂯎�邩</param>
		/// <param name="pbyErrCnt">�V�X�e���G���[���̐����󂯎�邽�߂̃o�b�t�@</param>
		/// <param name="pwErrCode">�V�X�e���G���[���̊i�[��</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetError(int lDeviceId, byte byRcvMax, ref byte pbyErrCnt, IntPtr pwErrCode);

		/// <summary>
		/// �V�X�e���G���[����
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="wErrCode">��������G���[�R�[�h</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_ClearError(int lDeviceId, short wErrCode);

		/// <summary>
		/// �g���K���s
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_Trigger(int lDeviceId);

		/// <summary>
		/// �o�b�`����J�n
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_StartMeasure(int lDeviceId);

		/// <summary>
		/// �o�b�`����I��
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_StopMeasure(int lDeviceId);

		/// <summary>
		/// �I�[�g�[��
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="byOnOff">ON/OFF�v��(0�FOFF/0�ȊO�FON)</param>
		/// <param name="dwOut">�����ΏۂƂ���n�t�s���r�b�g�Ŏw�肷��</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_AutoZero(int lDeviceId, byte byOnOff, uint dwOut);

		/// <summary>
		/// �^�C�~���O
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="byOnOff">ON/OFF�v��(0�FOFF/0�ȊO�FON)</param>
		/// <param name="dwOut">�����ΏۂƂ���n�t�s���r�b�g�Ŏw�肷��</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_Timing(int lDeviceId, byte byOnOff, uint dwOut);

		/// <summary>
		/// ���Z�b�g
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="dwOut">�����ΏۂƂ���n�t�s���r�b�g�Ŏw�肷��</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_Reset(int lDeviceId, uint dwOut);

		/// <summary>
		/// �������N���A
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_ClearMemory(int lDeviceId);

		/// <summary>
		/// �ݒ著�M
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="byDepth">�ݒ�l���A�ǂ̊K�w�܂Ŕ��f�����邩</param>
		/// <param name="TargetSetting">���M�ΏۂƂ��鍀��</param>
		/// <param name="pData">���M����ݒ�f�[�^</param>
		/// <param name="dwDataSize">pData��BYTE�P�ʂł̃T�C�Y</param>
		/// <param name="pdwError">�ݒ�ڍ׃G���[</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_SetSetting(int lDeviceId, SettingDepth byDepth, LJV7IF_TARGET_SETTING TargetSetting,
			IntPtr pData, uint dwDataSize, ref uint pdwError);

		/// <summary>
		/// �ݒ�擾
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="byDepth">�ǂݏo���K�w</param>
		/// <param name="TargetSetting">�ǂݏo���ݒ荀��</param>
		/// <param name="pData">�ǂݏo�����ݒ�̊i�[��</param>
		/// <param name="dwDataSize">pData��BYTE�P�ʂł̃T�C�Y</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetSetting(int lDeviceId, SettingDepth byDepth, LJV7IF_TARGET_SETTING TargetSetting, 
			IntPtr pData, uint dwDataSize);

		/// <summary>
		/// ^�ݒ菉����
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="byDepth">����������ݒ�̊K�w</param>
		/// <param name="byTarget">����������ݒ�</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_InitializeSetting(int lDeviceId, byte byDepth, byte byTarget);

		/// <summary>
		/// �ύX�p�ݒ�̔��f�v��
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="byDepth">���f��K�w</param>
		/// <param name="pdwError">�ݒ�ڍ׃G���[</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_ReflectSetting(int lDeviceId, byte byDepth, ref uint pdwError);

		/// <summary>
		/// �ύX�p�ݒ�̍X�V
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="byDepth">���f���ݒ�</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_RewriteTemporarySetting(int lDeviceId, byte byDepth);

		/// <summary>
		/// �ۑ��p�̈�ւ̕ۑ������󋵊m�F
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pbyBusy">�ۑ�������(0�ȊO:�s�����������փA�N�Z�X���A0:�A�N�Z�X���ł͂Ȃ�)</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_CheckMemoryAccess(int lDeviceId, ref byte pbyBusy);

		/// <summary>
		/// �����ݒ�
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="time">�ݒ肷�����</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_SetTime(int lDeviceId, ref LJV7IF_TIME time);

		/// <summary>
		/// �����擾
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="time">�擾����</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetTime(int lDeviceId, ref LJV7IF_TIME time);

		/// <summary>
		/// �v���O�����؂芷��
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="byProgNo">�؂�ւ���v���O����No</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_ChangeActiveProgram(int lDeviceId, byte byProgNo);

		/// <summary>
		/// �A�N�e�B�u�v���O�����m���D�擾
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pbyProgNo">�A�N�e�B�u�v���O����No</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetActiveProgram(int lDeviceId, ref byte pbyProgNo);

		/// <summary>
		/// ���茋�ʎ擾
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pMeasureData">���茋��</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetMeasurementValue(int lDeviceId, [Out]LJV7IF_MEASURE_DATA[] pMeasureData);

		/// <summary>
		/// �v���t�@�C���擾�i���샂�[�h"�����i�v���t�@�C���̂݁j"�j
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pReq">�擾�v���t�@�C�����</param>
		/// <param name="pRsp">�v���t�@�C���擾����</param>
		/// <param name="pProfileInfo">�v���t�@�C�����</param>
		/// <param name="pdwProfileData">�v���t�@�C���f�[�^</param>
		/// <param name="dwDataSize">pdwProfileData��BYTE�P�ʂ̃T�C�Y</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetProfile(int lDeviceId, ref LJV7IF_GET_PROFILE_REQ pReq,
			ref LJV7IF_GET_PROFILE_RSP pRsp, ref LJV7IF_PROFILE_INFO pProfileInfo, IntPtr pdwProfileData, uint dwDataSize);

		/// <summary>
		/// �o�b�`�v���t�@�C���擾�i���샂�[�h"�����i�v���t�@�C���̂݁j"�j
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pReq">�擾�v���t�@�C���w����</param>
		/// <param name="pRsp">�o�b�`�v���t�@�C���擾����</param>
		/// <param name="pProfileInfo">�v���t�@�C�����</param>
		/// <param name="pdwBatchData">�v���t�@�C���f�[�^</param>
		/// <param name="dwDataSize">pdwBatchData��BYTE�P�ʂ̃T�C�Y</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetBatchProfile(int lDeviceId, ref LJV7IF_GET_BATCH_PROFILE_REQ pReq,
			ref LJV7IF_GET_BATCH_PROFILE_RSP pRsp, ref LJV7IF_PROFILE_INFO pProfileInfo,
			IntPtr pdwBatchData, uint dwDataSize);
		
		/// <summary>
		/// �v���t�@�C���擾�i���샂�[�h"���@�\�i�n�t�s���肠��j"�j
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pProfileInfo">�v���t�@�C�����</param>
		/// <param name="pdwProfileData">�v���t�@�C���f�[�^</param>
		/// <param name="dwDataSize">pdwProfileData��BYTE�T�C�Y</param>
		/// <param name="pMeasureData">���茋��</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetProfileAdvance(int lDeviceId, ref LJV7IF_PROFILE_INFO pProfileInfo,
			IntPtr pdwProfileData, uint dwDataSize, [Out]LJV7IF_MEASURE_DATA[] pMeasureData);

		/// <summary>
		/// �o�b�`�v���t�@�C���擾�i���샂�[�h"���@�\�i�n�t�s���肠��j"�j
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pReq">�擾�v���t�@�C���w����</param>
		/// <param name="pRsp">�v���t�@�C���擾����</param>
		/// <param name="pProfileInfo">�v���t�@�C�����</param>
		/// <param name="pdwBatchData">�o�b�`�v���t�@�C���f�[�^</param>
		/// <param name="dwDataSize">pdwBatchData��BYTE�T�C�Y</param>
		/// <param name="pBatchMeasureData">���茋��</param>
		/// <param name="pMeasureData">���茋��</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetBatchProfileAdvance(int lDeviceId, ref LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ pReq,
			ref LJV7IF_GET_BATCH_PROFILE_ADVANCE_RSP pRsp, ref LJV7IF_PROFILE_INFO pProfileInfo,
			IntPtr pdwBatchData, uint dwDataSize, [Out]LJV7IF_MEASURE_DATA[] pBatchMeasureData, [Out]LJV7IF_MEASURE_DATA[] pMeasureData);

		/// <summary>
		/// ^�X�g���[�W�J�n
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_StartStorage(int lDeviceId);

		/// <summary>
		/// �X�g���[�W��~
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_StopStorage(int lDeviceId);

		/// <summary>
		/// �X�g���[�W��Ԏ擾
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pReq">�擾�X�g���[�W�w����</param>
		/// <param name="pRsp">�擾�X�g���[�W</param>
		/// <param name="pStorageInfo">�X�g���[�W���</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetStorageStatus(int lDeviceId, ref LJV7IF_GET_STRAGE_STATUS_REQ pReq,
			ref LJV7IF_GET_STRAGE_STATUS_RSP pRsp, ref LJV7IF_STORAGE_INFO pStorageInfo);
				
		/// <summary>
		/// �f�[�^�X�g���[�W�f�[�^�擾
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pReq">�擾�f�[�^�w����</param>
		/// <param name="pStorageInfo">�X�g���[�W���</param>
		/// <param name="pRsp">�擾�f�[�^���</param>
		/// <param name="pdwData">�擾�f�[�^</param>
		/// <param name="dwDataSize">pdwData��BYTE�T�C�Y</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetStorageData(int lDeviceId, ref LJV7IF_GET_STORAGE_REQ pReq,
			ref LJV7IF_STORAGE_INFO pStorageInfo, ref LJV7IF_GET_STORAGE_RSP pRsp, IntPtr pdwData, uint dwDataSize);

		/// <summary>
		/// �v���t�@�C���X�g���[�W�f�[�^�擾
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pReq">�擾�v���t�@�C���w����</param>
		/// <param name="pStorageInfo">�X�g���[�W���</param>
		/// <param name="pRes">�v���t�@�C���擾����</param>
		/// <param name="pProfileInfo">�v���t�@�C�����</param>
		/// <param name="pdwData">�v���t�@�C���f�[�^</param>
		/// <param name="dwDataSize">pdwData��BYTE�T�C�Y</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetStorageProfile(int lDeviceId, ref LJV7IF_GET_STORAGE_REQ pReq, 
			ref LJV7IF_STORAGE_INFO pStorageInfo, ref LJV7IF_GET_STORAGE_RSP pRes,
			ref LJV7IF_PROFILE_INFO pProfileInfo, IntPtr pdwData, uint dwDataSize);

		/// <summary>
		/// �o�b�`�v���t�@�C���X�g���[�W�f�[�^�擾
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pReq">�擾�o�b�`�v���t�@�C���w����</param>
		/// <param name="pStorageInfo">�X�g���[�W���</param>
		/// <param name="pRes">�o�b�`�v���t�@�C���擾����</param>
		/// <param name="pProfileInfo">�v���t�@�C�����</param>
		/// <param name="pdwData">�v���t�@�C���f�[�^</param>
		/// <param name="dwDataSize">pdwData��BYTE�T�C�Y</param>
		/// <param name="pTimeOffset">����������ms�P�ʂ̌o�ߎ���</param>
		/// <param name="pMeasureData">���茋��</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_GetStorageBatchProfile(int lDeviceId, 
			ref LJV7IF_GET_BATCH_PROFILE_STORAGE_REQ pReq, ref LJV7IF_STORAGE_INFO pStorageInfo,
			ref LJV7IF_GET_BATCH_PROFILE_STORAGE_RSP pRes, ref LJV7IF_PROFILE_INFO pProfileInfo,
			IntPtr pdwData, uint dwDataSize, ref uint pTimeOffset, [Out]LJV7IF_MEASURE_DATA[] pMeasureData);

		/// <summary>
		/// �����f�[�^�ʐM������(USB)
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pCallBack">��M�����s�֐�</param>
		/// <param name="dwProfileCnt">pCallBack�Ăяo���p�x</param>
		/// <param name="dwThreadId">�X���b�hID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_HighSpeedDataUsbCommunicationInitalize(int lDeviceId, 
			HightSpeedDataCallBack pCallBack, uint dwProfileCnt, uint dwThreadId);

		/// <summary>
		/// �����f�[�^�ʐM������(Ethernet)
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pEthernetConfig">Ethernet�ݒ�</param>
		/// <param name="wHighSpeedPortNo">�����f�[�^�ʐM�|�[�g</param>
		/// <param name="pCallBack">��M�����s�֐�</param>
		/// <param name="dwProfileCnt">pCallBack�Ăяo���p�x</param>
		/// <param name="dwThreadId">�X���b�hID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_HighSpeedDataEthernetCommunicationInitalize(
			int lDeviceId, ref LJV7IF_ETHERNET_CONFIG pEthernetConfig, ushort wHighSpeedPortNo,
			HightSpeedDataCallBack pCallBack, uint dwProfileCnt, uint dwThreadId);

		/// <summary>
		/// �����f�[�^�ʐM�J�n����
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <param name="pReq">���M�f�[�^���</param>
		/// <param name="pProfileInfo">�v���t�@�C�����</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_PreStartHighSpeedDataCommunication(
			int lDeviceId, ref LJV7IF_HIGH_SPEED_PRE_START_REQ pReq,
			ref LJV7IF_PROFILE_INFO pProfileInfo);

		/// <summary>
		/// �����f�[�^�ʐM�J�n
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_StartHighSpeedDataCommunication(int lDeviceId);

		/// <summary>
		/// �����f�[�^�ʐM��~
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_StopHighSpeedDataCommunication(int lDeviceId);

		/// <summary>
		/// �����f�[�^�ʐM�I��
		/// </summary>
		/// <param name="lDeviceId">�f�o�C�XID</param>
		/// <returns>���^�[���R�[�h</returns>
		[DllImport("LJV7_IF.dll")]
		internal static extern int LJV7IF_HighSpeedDataCommunicationFinalize(int lDeviceId);
	}
};
