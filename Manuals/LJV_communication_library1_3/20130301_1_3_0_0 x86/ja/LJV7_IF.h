//Copyright(c) 2012, KEYENCE CORPORATION. All rights reserved.
/** @file
@brief	LJV7_IF�̃w�b�_
*/

#pragma once
#pragma managed(push, off)

#ifdef LJV7_IF_EXPORT
#define LJV7_IF_API __declspec(dllexport)
#else
#define LJV7_IF_API __declspec(dllimport)
#endif

/// �ݒ�l�i�[�K�w�̎w��
typedef enum {
	LJV7IF_SETTING_DEPTH_WRITE		= 0x00,		// �ύX�p
	LJV7IF_SETTING_DEPTH_RUNNING	= 0x01,		// ���쒆
	LJV7IF_SETTING_DEPTH_SAVE		= 0x02,		// �s����������
} LJV7IF_SETTING_DEPTH;

/// �ݒ�t�@�C����ʂ̎w��
typedef enum {
	LJV7IF_INIT_SETTING_TARGET_PRG0 	= 0x00, 	// �v���O����0
	LJV7IF_INIT_SETTING_TARGET_PRG1 	= 0x01, 	// �v���O����1
	LJV7IF_INIT_SETTING_TARGET_PRG2 	= 0x02, 	// �v���O����2
	LJV7IF_INIT_SETTING_TARGET_PRG3 	= 0x03, 	// �v���O����3
	LJV7IF_INIT_SETTING_TARGET_PRG4 	= 0x04, 	// �v���O����4
	LJV7IF_INIT_SETTING_TARGET_PRG5 	= 0x05, 	// �v���O����5
	LJV7IF_INIT_SETTING_TARGET_PRG6 	= 0x06, 	// �v���O����6
	LJV7IF_INIT_SETTING_TARGET_PRG7		= 0x07, 	// �v���O����7
	LJV7IF_INIT_SETTING_TARGET_PRG8		= 0x08, 	// �v���O����8
	LJV7IF_INIT_SETTING_TARGET_PRG9		= 0x09, 	// �v���O����9
	LJV7IF_INIT_SETTING_TARGET_PRG10	= 0x0A, 	// �v���O����10
	LJV7IF_INIT_SETTING_TARGET_PRG11	= 0x0B, 	// �v���O����11
	LJV7IF_INIT_SETTING_TARGET_PRG12	= 0x0C, 	// �v���O����12
	LJV7IF_INIT_SETTING_TARGET_PRG13	= 0x0D, 	// �v���O����13
	LJV7IF_INIT_SETTING_TARGET_PRG14	= 0x0E, 	// �v���O����14
	LJV7IF_INIT_SETTING_TARGET_PRG15	= 0x0F, 	// �v���O����15
} LJV7IF_INIT_SETTING_TARGET;

/// ����l�̗L��������������`
typedef enum {
	LJV7IF_MEASURE_DATA_INFO_VALID	= 0x00,		// �L��
	LJV7IF_MEASURE_DATA_INFO_ALARM	= 0x01,		// �A���[���l
	LJV7IF_MEASURE_DATA_INFO_WAIT	= 0x02,		// ����ҋ@�l
} LJV7IF_MEASURE_DATA_INFO;

/// ����l�̔��茋�ʂ�������`
typedef enum {
	LJV7IF_JUDGE_RESULT_HI	= 0x01,		// HI
	LJV7IF_JUDGE_RESULT_GO	= 0x02,		// GO
	LJV7IF_JUDGE_RESULT_LO	= 0x04,		// LO
} LJV7IF_JUDGE_RESULT;

/// �v���t�@�C���擾�Ώۃo�b�t�@�̎w��
typedef enum {
	LJV7IF_PROFILE_BANK_ACTIVE		= 0x00,		// �A�N�e�B�u��
	LJV7IF_PROFILE_BANK_INACTIVE	= 0x01,		// ��A�N�e�B�u��
} LJV7IF_PROFILE_BANK;

/// �v���t�@�C���擾�ʒu�w����@�̎w��
typedef enum {
	LJV7IF_PROFILE_POS_CURRENT	= 0x00,		// �ŐV����
	LJV7IF_PROFILE_POS_OLDEST	= 0x01,		// �ŌÂ���
	LJV7IF_PROFILE_POS_SPEC		= 0x02,		// �ʒu���w��
} LJV7IF_PROFILE_POS;

/// �o�b�`�v���t�@�C���擾�ʒu�w����@�̎w��
typedef enum {
	LJV7IF_BATCH_POS_CURRENT		= 0x00,		// �ŐV����
	LJV7IF_BATCH_POS_SPEC			= 0x02,		// �ʒu���w��
	LJV7IF_BATCH_POS_COMMITED		= 0x03,		// �m���̍ŐV����
	LJV7IF_BATCH_POS_CURRENT_ONLY	= 0x04,		// �ŐV�̂�
} LJV7IF_BATCH_POS;

/// OUT�ݒ�̐�
const static LONG LJV7IF_OUT_COUNT = 16;

/// �ʐM�o�H�̍ő吔
const static LONG LJV7IF_DEVICE_COUNT = 6;

/// �d���������������ݒ�\����
typedef struct {
	BYTE	abyIpAddress[4];	// �ڑ�����R���g���[����IP�A�h���X
	WORD	wPortNo;			// �ڑ�����R���g���[���̃|�[�g�ԍ�
	BYTE	reserve[2];			// �\��
} LJV7IF_ETHERNET_CONFIG;

/// �����\����
typedef struct {
	BYTE byYear;		// �N(�O�`�X�X�͈̔͂ŁA�Q�O�O�O�`�Q�O�X�X�N���Ӗ�����)
	BYTE byMonth;		// ��(�P�`�P�Q)
	BYTE byDay;			// ��(�P�`�R�P)
	BYTE byHour;		// ��(�O�`�Q�R)
	BYTE byMinute;		// ��(�O�`�T�X)
	BYTE bySecond;		// �b(�O�`�T�X)
	BYTE reserve[2];	// �\��
} LJV7IF_TIME;

/// �ݒ荀�ڎw��\����
typedef struct {
	BYTE	byType;			// �ݒ���
	BYTE	byCategory;		// �ݒ�J�e�S��
	BYTE	byItem;			// �ݒ荀��
	BYTE	reserve;		// �\��
	BYTE	byTarget1;		// �ݒ�ΏۂP
	BYTE	byTarget2;		// �ݒ�ΏۂQ
	BYTE	byTarget3;		// �ݒ�ΏۂR
	BYTE	byTarget4;		// �ݒ�ΏۂS
} LJV7IF_TARGET_SETTING;

/// ���茋�ʍ\����
typedef struct {
	BYTE byDataInfo;		// ����l���L���l��
	BYTE byJudge;			// �������茋��
	BYTE reserve[2];		// �\��
	FLOAT fValue;			// ����l
} LJV7IF_MEASURE_DATA;

/// �v���t�@�C�����\����
typedef struct {
	BYTE	byProfileCnt;	// �v���t�@�C���f�[�^�������i�[����Ă��邩
	BYTE	byEnvelope;		// �v���t�@�C�����k�i���Ԏ��j���n�m���ǂ���
	BYTE 	reserve[2];		// �\��
	WORD	wProfDataCnt;	// �v���t�@�C���̃f�[�^��
	BYTE 	reserve2[2];	// �\��
	LONG	lXStart;		// �P�_�ڂ̇]���W
	LONG	lXPitch;		// �v���t�@�C���f�[�^�̇]�����Ԋu
} LJV7IF_PROFILE_INFO;

/// �v���t�@�C���w�b�_���\����
typedef struct {
	DWORD	reserve;		// �\��
	DWORD	dwTriggerCnt;	// ����J�n���牽��ڂ̃g���K�̃v���t�@�C����
	DWORD	dwEncoderCnt;	// ����J�n���牽��ڂ̃G���R�[�_�g���K�̃v���t�@�C����
	DWORD	reserve2[3];	// �\��
} LJV7IF_PROFILE_HEADER;

/// �v���t�@�C���t�b�^���\����
typedef struct {
	DWORD	reserve;		// �\��
} LJV7IF_PROFILE_FOOTER;

/// �������[�h�v���t�@�C���擾�v���\���́i�o�b�`����F�n�e�e�j
typedef struct {
	BYTE 	byTargetBank;	// �Ώۖ�
	BYTE 	byPosMode;		// �ʒu�w����@
	BYTE 	reserve[2];		// �\��
	DWORD	dwGetProfNo;	// �擾�Ώۂ̃v���t�@�C���ԍ�
	BYTE	byGetProfCnt;	// �ǂݏo���v���t�@�C���̐�
	BYTE 	byErase;		// �ǂݏo�����v���t�@�C�����R���g���[������������邩
	BYTE 	reserve2[2];	// �\��
} LJV7IF_GET_PROFILE_REQ;

/// �������[�h�v���t�@�C���擾�v���\���́i�o�b�`����F�n�m�j
typedef struct {
	BYTE 	byTargetBank;	// �Ώۖ�
	BYTE 	byPosMode;		// �o�b�`�ʒu�w����@
	BYTE 	reserve[2];		// �\��
	DWORD	dwGetBatchNo;	// �擾�Ώۂ̃v���t�@�C���̃o�b�`�ԍ�
	DWORD	dwGetProfNo;	// �w��o�b�`�ԍ����̎擾�J�n�v���t�@�C���ԍ�
	BYTE	byGetProfCnt;	// �ǂݏo���v���t�@�C���̐�
	BYTE 	byErase;		// �ǂݏo�����v���t�@�C�����R���g���[������������邩
	BYTE 	reserve2[2];	// �\��
} LJV7IF_GET_BATCH_PROFILE_REQ;

/// ���@�\���[�h�v���t�@�C���擾�v���\���́i�o�b�`����F�n�m�j
typedef struct {
	BYTE byPosMode;		// �o�b�`�ʒu�w����@
	BYTE reserve[3];		// �\��
	DWORD dwGetBatchNo;		// �擾�Ώۂ̃v���t�@�C���̃o�b�`�ԍ�
	DWORD dwGetProfNo;		// �w��o�b�`�ԍ����̎擾�J�n�v���t�@�C���ԍ�
	BYTE byGetProfCnt;		// �ǂݏo���v���t�@�C���̐�
	BYTE reserve2[3];		// �\��
} LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ;

/// �������[�h�v���t�@�C���擾�ԐM�\���́i�o�b�`����F�n�e�e�j
typedef struct {
	DWORD	dwCurrentProfNo;	// �ŐV�v���t�@�C���ԍ�
	DWORD	dwOldestProfNo;		// �R���g���[�����̍ŌÃv���t�@�C���ԍ�
	DWORD	dwGetTopProfNo;		// �ǂݏo�����v���t�@�C���̐擪�ԍ�
	BYTE	byGetProfCnt;		// �ǂݏo�����v���t�@�C����	
	BYTE 	reserve[3];			// �\��
} LJV7IF_GET_PROFILE_RSP;

/// �������[�h�v���t�@�C���擾�ԐM�\���́i�o�b�`����F�n�m�j
typedef struct {
	DWORD	dwCurrentBatchNo;		// �����_�ł̍ŐV�o�b�`�ԍ��B
	DWORD	dwCurrentBatchProfCnt;	// �ŐV�o�b�`���̃v���t�@�C���̐��B
	DWORD	dwOldestBatchNo;		// �R���g���[�����ێ�����A�ł��Â��o�b�`�̃o�b�`�ԍ��B
	DWORD	dwOldestBatchProfCnt;	// �R���g���[�����ێ�����A�ł��Â��o�b�`���̃v���t�@�C���̐��B
	DWORD	dwGetBatchNo;			// �ǂݏo�����o�b�`�ԍ��B
	DWORD	dwGetBatchProfCnt;		// �ǂݏo�����o�b�`���̃v���t�@�C���̐��B
	DWORD	dwGetBatchTopProfNo;	// �ǂݏo�������ŁA��ԌÂ��v���t�@�C�����o�b�`���̉��Ԗڂ̃v���t�@�C�����������B
	BYTE	byGetProfCnt;			// �ǂݏo�����v���t�@�C���̐��B
	BYTE	byCurrentBatchCommited;	// �ŐV�o�b�`No.�̃o�b�`���肪�������Ă��邩�������B
	BYTE 	reserve[2];				// �\��
} LJV7IF_GET_BATCH_PROFILE_RSP;

/// ���@�\���[�h�v���t�@�C���擾�ԐM�\���́i�o�b�`����F�n�m�j
typedef struct {
	DWORD	dwGetBatchNo;			// �ǂݏo�����o�b�`�ԍ��B
	DWORD	dwGetBatchProfCnt;		// �ǂݏo�����o�b�`���̃v���t�@�C���̐��B
	DWORD	dwGetBatchTopProfNo;	// �ǂݏo�������ŁA��ԌÂ��v���t�@�C�����o�b�`���̉��Ԗڂ̃v���t�@�C�����������B
	BYTE	byGetProfCnt;			// �ǂݏo�����v���t�@�C���̐��B
	BYTE 	reserve[3];				// �\��
} LJV7IF_GET_BATCH_PROFILE_ADVANCE_RSP;

/// �X�g���[�W��ԗv���\����
typedef struct {
	DWORD	dwRdArea;				// �ǂݏo���Ώۖ� 
} LJV7IF_GET_STRAGE_STATUS_REQ;

/// �X�g���[�W��ԕԐM�\����
typedef struct {
	DWORD	dwSurfaceCnt;			// �X�g���[�W�ʐ�
	DWORD	dwActiveSurface;		// �A�N�e�B�u�X�g���[�W��
} LJV7IF_GET_STRAGE_STATUS_RSP;

/// �X�g���[�W���\����
typedef struct {
	BYTE	byStatus;				// �X�g���[�W���
	BYTE	byProgramNo;			// �Y���X�g���[�W�ʂ̃v���O����No
	BYTE	byTarget;				// �X�g���[�W�Ώ�
	BYTE	reserve[5];				// �\��
	DWORD	dwStorageCnt;			// �X�g���[�W�_��
} LJV7IF_STORAGE_INFO;

/// �X�g���[�W�f�[�^�擾�v���\����
typedef struct {
	BYTE 	reserve[4];				// �\��
	DWORD	dwSurface;				// �ǂݏo���X�g���[�W��
	DWORD	dwStartNo;				// �ǂݏo���J�n����X�g���[�W�ԍ�
	DWORD	dwDataCnt;				// �ǂݏo���_��
} LJV7IF_GET_STORAGE_REQ;

/// �o�b�`�v���t�@�C���X�g���[�W�擾�v���\����
typedef struct {
	BYTE 	reserve[4];				// �\��
	DWORD	dwSurface;				// �ǂݏo���X�g���[�W��
	DWORD	dwGetBatchNo;			// �ǂݏo�o�b�`�ԍ�
	DWORD	dwGetBatchTopProfNo;	// �o�b�`���̓ǂݏo���J�n�v���t�@�C���ԍ�
	BYTE	byGetProfCnt;			// �ǂݏo���v���t�@�C���_��
	BYTE	reserved[3];			// �\��
} LJV7IF_GET_BATCH_PROFILE_STORAGE_REQ;

/// �X�g���[�W�f�[�^�擾�ԐM�\����
typedef struct {
	DWORD	dwStartNo;				// �ǂݏo���J�n����X�g���[�W�ԍ�
	DWORD	dwDataCnt;				// �ǂݏo���_��
	LJV7IF_TIME	stBaseTime;			// �����
} LJV7IF_GET_STORAGE_RSP;

/// �o�b�`�v���t�@�C���X�g���[�W�擾�ԐM�\����
typedef struct {
	DWORD	dwGetBatchNo;			// �ǂݏo�o�b�`�ԍ�
	DWORD	dwGetBatchProfCnt;		// �ǂݏo�o�b�`���̃v���t�@�C����
	DWORD	dwGetBatchTopProfNo;	// �o�b�`���̓ǂݏo���J�n�v���t�@�C���ԍ�
	BYTE	byGetProfCnt;			// �ǂݏo���v���t�@�C���_��
	BYTE 	reserve[3];				// �\��
	LJV7IF_TIME	stBaseTime;			// �����
} LJV7IF_GET_BATCH_PROFILE_STORAGE_RSP;

/// �����ʐM�J�n�v���\����
typedef struct {
	BYTE	bySendPos;				// ���M�J�n�ʒu 
	BYTE	reserve[3];				// �\��
} LJV7IF_HIGH_SPEED_PRE_START_REQ;

/**
�����ʐM�p�R�[���o�b�N�֐�IF
@param	pBuffer		�v���t�@�C���f�[�^���i�[����Ă���o�b�t�@�ւ̃|�C���^�B
@param	dwSize		�P�v���t�@�C��������̂a�x�s�d�P�ʂł̃T�C�Y�B(�w�b�_�y�уt�b�^�̃T�C�Y���܂ށB) 
@param	dwCount		pBuffer�Ɋi�[����Ă���v���t�@�C���̐��B
@param	dwNotify	�����f�[�^�ʐM�̒��f��o�b�`����̋�؂��ʒm����B
@param	dwUser		�����ʐM���������ɃZ�b�g�������[�U�Ǝ����B
*/
typedef void (_cdecl *LJV7IF_CALLBACK)(BYTE* pBuffer, DWORD dwSize, DWORD dwCount, DWORD dwNotify, DWORD dwUser);

extern "C"
{
	// �֐�
	// DLL�ɑ΂��鑀��

	/**
	�c�k�k������
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_Initialize(void);

	/**
	�c�k�k�I������
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_Finalize(void);
	/**
	�c�k�k�o�[�W�����擾
	@return	�o�[�W����
	@note	Ver.1.230�Ȃ�0x1230��Ԃ�
	*/
	LJV7_IF_API DWORD WINAPI LJV7IF_GetVersion(void);

	// �R���g���[���Ƃ̒ʐM�o�H�m��/�ؒf
	/**
	�t�r�a�ʐM�ڑ�
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_UsbOpen(LONG lDeviceId);
	/**
	�d���������������ʐM�ڑ�
	@param	lDeviceId	�f�o�C�XID
	@param	pEthernetConfig	�d���������������ݒ�
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_EthernetOpen(LONG lDeviceId, LJV7IF_ETHERNET_CONFIG* pEthernetConfig);
	/**
	�ʐM�o�H�ؒf
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_CommClose(LONG lDeviceId);

	// �V�X�e������
	/**
	�R���g���[���ċN��
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_RebootController(LONG lDeviceId);
	/**
	�H��o�׏�Ԃ֖߂�
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_RetrunToFactorySetting(LONG lDeviceId);

	/**
	�V�X�e���G���[���擾
	@param	lDeviceId	�f�o�C�XID
	@param	byRcvMax	�V�X�e���G���[�����ő剽�܂Ŏ󂯎�邩�B
	@param	pbyErrCnt	�V�X�e���G���[���̐����󂯎�邽�߂̃o�b�t�@�B
	@param	pwErrCode	�V�X�e���G���[���̊i�[��
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetError(LONG lDeviceId, BYTE byRcvMax, BYTE* pbyErrCnt, WORD* pwErrCode);

	/**
	�V�X�e���G���[����
	@param	lDeviceId	�f�o�C�XID
	@param	wErrCode	��������G���[�R�[�h
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_ClearError(LONG lDeviceId, WORD wErrCode);

	// ���萧��
	/**
	�g���K���s
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_Trigger(LONG lDeviceId);

	/**
	�o�b�`����J�n
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	@note	�o�b�`ON�̏ꍇ�̓o�b�`�J�n������s��
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_StartMeasure(LONG lDeviceId);

	/**
	�o�b�`����I��
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	@note	�o�b�`ON�̏ꍇ�̓o�b�`��~������s��
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_StopMeasure(LONG lDeviceId);

	/**
	�I�[�g�[��
	@param	lDeviceId	�f�o�C�XID
	@param	byOnOff	ON/OFF�v��(0�FOFF/0�ȊO�FON)
	@param	dwOut	�����ΏۂƂ���n�t�s���r�b�g�Ŏw�肷��B
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_AutoZero(LONG lDeviceId, BYTE byOnOff, DWORD dwOut);

	/**
	�^�C�~���O
	@param	lDeviceId	�f�o�C�XID
	@param	byOnOff	ON/OFF�v��(0�FOFF/0�ȊO�FON)
	@param	dwOut	�����ΏۂƂ���n�t�s���r�b�g�Ŏw�肷��B
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_Timing(LONG lDeviceId, BYTE byOnOff, DWORD dwOut);
	
	/** 
	���Z�b�g
	@param	lDeviceId	�f�o�C�XID
	@param	dwOut	�����ΏۂƂ���n�t�s���r�b�g�Ŏw�肷��B
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_Reset(LONG lDeviceId, DWORD dwOut);

	/**
	�������N���A
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_ClearMemory(LONG lDeviceId);

	//�ݒ�ύX/�ǂݏo���֘A
	/**
	�ݒ著�M
	@param	lDeviceId	�f�o�C�XID
	@param	byDepth	�ݒ�l���A�ǂ̊K�w�܂Ŕ��f�����邩
	@param	TargetSetting	���M�ΏۂƂ��鍀��
	@param	pData	���M����ݒ�f�[�^
	@param	dwDataSize	pData��BYTE�P�ʂł̃T�C�Y
	@param	pdwError	�ݒ�ڍ׃G���[
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_SetSetting(LONG lDeviceId, BYTE byDepth, LJV7IF_TARGET_SETTING TargetSetting, void* pData, DWORD dwDataSize, DWORD* pdwError);

	/**
	�ݒ�擾
	@param	lDeviceId	�f�o�C�XID
	@param	byDepth	�ǂݏo���K�w
	@param	TargetSetting	�ǂݏo���ݒ荀��
	@param	pData	�ǂݏo�����ݒ�̊i�[��
	@param	dwDataSize	pData��BYTE�P�ʂł̃T�C�Y
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetSetting(LONG lDeviceId, BYTE byDepth, LJV7IF_TARGET_SETTING TargetSetting, void* pData, DWORD dwDataSize);

	/**
	�ݒ菉����
	@param	lDeviceId	�f�o�C�XID
	@param	byDepth	����������ݒ�̊K�w
	@param	byTarget	����������v���O����No
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_InitializeSetting(LONG lDeviceId, BYTE byDepth, BYTE byTarget);

	/**
	�ύX�p�ݒ�̔��f�v��
	@param	lDeviceId	�f�o�C�XID
	@param	byDepth	���f��K�w
	@param	pdwError	�ݒ�ڍ׃G���[
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_ReflectSetting(LONG lDeviceId, BYTE byDepth, DWORD* pdwError);

	/**
	�ύX�p�ݒ�̍X�V
	@param	lDeviceId	�f�o�C�XID
	@param	byDepth	���f���ݒ�
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_RewriteTemporarySetting(LONG lDeviceId, BYTE byDepth);

	/**
	�s�����������ۑ������󋵊m�F
	@param	lDeviceId	�f�o�C�XID
	@param	pbyBusy	�ۑ�������(0�ȊO:�s�����������փA�N�Z�X���A0:�A�N�Z�X���ł͂Ȃ�)
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_CheckMemoryAccess(LONG lDeviceId, BYTE* pbyBusy);

	/**
	�����ݒ�
	@param	lDeviceId	�f�o�C�XID
	@param	pTime	�ݒ肷�����
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_SetTime(LONG lDeviceId, LJV7IF_TIME* pTime);

	/**
	�����擾
	@param	lDeviceId	�f�o�C�XID
	@param	pTime	�擾����
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetTime(LONG lDeviceId, LJV7IF_TIME* pTime);

	/**
	�v���O�����؂芷��
	@param	lDeviceId	�f�o�C�XID
	@param	byProgNo	�؂�ւ���v���O����No
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_ChangeActiveProgram(LONG lDeviceId, BYTE byProgNo);

	/**
	�A�N�e�B�u�v���O�����m���D�擾
	@param	lDeviceId	�f�o�C�XID
	@param	pbyProgNo	�A�N�e�B�u�v���O����No
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetActiveProgram(LONG lDeviceId, BYTE* pbyProgNo);

	// ���茋�ʂ̎擾
	/**
	���茋�ʎ擾
	@param	lDeviceId	�f�o�C�XID
	@param	pMeasureData	���茋��
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetMeasurementValue(LONG lDeviceId, LJV7IF_MEASURE_DATA* pMeasureData);
	
	/**
	�v���t�@�C���擾�i���샂�[�h"�����i�v���t�@�C���̂݁j"�j
	@param	lDeviceId	�f�o�C�XID
	@param	pReq	�擾�v���t�@�C�����
	@param	pRsp	�v���t�@�C���擾����
	@param	pProfileInfo	�v���t�@�C�����
	@param	pdwProfileData	�v���t�@�C���f�[�^
	@param	dwDataSize	pdwProfileData��BYTE�P�ʂ̃T�C�Y
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetProfile(LONG lDeviceId, LJV7IF_GET_PROFILE_REQ* pReq, LJV7IF_GET_PROFILE_RSP* pRsp, LJV7IF_PROFILE_INFO* pProfileInfo, DWORD* pdwProfileData, DWORD dwDataSize);

	/**
	�o�b�`�v���t�@�C���擾�i���샂�[�h"�����i�v���t�@�C���̂݁j"�j
	@param	lDeviceId	�f�o�C�XID
	@param	pReq	�擾�v���t�@�C���w����
	@param	pRsp	�o�b�`�v���t�@�C���擾����
	@param	pProfileInfo	�v���t�@�C�����
	@param	pdwBatchData	�v���t�@�C���f�[�^
	@param	dwDataSize	pdwBatchData��BYTE�P�ʂ̃T�C�Y
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetBatchProfile(LONG lDeviceId, LJV7IF_GET_BATCH_PROFILE_REQ* pReq, LJV7IF_GET_BATCH_PROFILE_RSP* pRsp, LJV7IF_PROFILE_INFO * pProfileInfo, DWORD* pdwBatchData, DWORD dwDataSize);

	/**
	�v���t�@�C���擾�i���샂�[�h"���@�\�i�n�t�s���肠��j"�j
	@param	lDeviceId	�f�o�C�XID
	@param	pProfileInfo	�v���t�@�C�����
	@param	pdwProfileData	�v���t�@�C���f�[�^
	@param	dwDataSize	pdwProfileData��BYTE�T�C�Y
	@param	pMeasureData	���茋��
	@return	���^�[���R�[�h
	@note	
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetProfileAdvance(LONG lDeviceId, LJV7IF_PROFILE_INFO* pProfileInfo, DWORD* pdwProfileData, DWORD dwDataSize, LJV7IF_MEASURE_DATA* pMeasureData);

	/**
	�o�b�`�v���t�@�C���擾�i���샂�[�h"���@�\�i�n�t�s���肠��j"�j
	@param	lDeviceId	�f�o�C�XID
	@param	pReq	�擾�v���t�@�C���w����
	@param	pRsp	�v���t�@�C���擾����
	@param	pProfileInfo	�v���t�@�C�����
	@param	pdwBatchData	�o�b�`�v���t�@�C���f�[�^
	@param	dwDataSize	pdwBatchData��BYTE�T�C�Y
	@param	pBatchMeasureData	�擾�Ώۂ̃o�b�`�f�[�^�ɑ΂��鑪�茋��
	@param	pMeasureData	�R�}���h�������_�ł̍ŐV���茋��
	@return	���^�[���R�[�h
	@note	
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetBatchProfileAdvance(LONG lDeviceId, LJV7IF_GET_BATCH_PROFILE_ADVANCE_REQ* pReq, 
		LJV7IF_GET_BATCH_PROFILE_ADVANCE_RSP* pRsp, LJV7IF_PROFILE_INFO* pProfileInfo, 
		DWORD* pdwBatchData, DWORD dwDataSize, LJV7IF_MEASURE_DATA* pBatchMeasureData, LJV7IF_MEASURE_DATA* pMeasureData);

	// �X�g���[�W�@�\�֘A
	/**
	�X�g���[�W�J�n
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_StartStorage(LONG lDeviceId);

	/**
	�X�g���[�W��~
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_StopStorage(LONG lDeviceId);

	/**
	�X�g���[�W��Ԏ擾
	@param	lDeviceId	�f�o�C�XID
	@param	pReq	�擾�X�g���[�W�w����
	@param	pRsp	�擾�X�g���[�W
	@param	pStorageInfo	�X�g���[�W���
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetStorageStatus(LONG lDeviceId, LJV7IF_GET_STRAGE_STATUS_REQ* pReq, LJV7IF_GET_STRAGE_STATUS_RSP* pRsp, LJV7IF_STORAGE_INFO* pStorageInfo);
	
	/**
	�f�[�^�X�g���[�W�f�[�^�擾
	@param	lDeviceId	�f�o�C�XID
	@param	pReq	�擾�f�[�^�w����
	@param	pStorageInfo	�X�g���[�W���
	@param	pRes	�擾�f�[�^���
	@param	pdwData	�擾�f�[�^
	@param	dwDataSize	pdwData��BYTE�T�C�Y
	@return	���^�[���R�[�h
	@note	
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetStorageData(LONG lDeviceId, LJV7IF_GET_STORAGE_REQ* pReq, LJV7IF_STORAGE_INFO* pStorageInfo, LJV7IF_GET_STORAGE_RSP* pRes, DWORD* pdwData, DWORD dwDataSize);
	
	/**
	�v���t�@�C���X�g���[�W�f�[�^�擾
	@param	lDeviceId	�f�o�C�XID
	@param	pReq	�擾�v���t�@�C���w����
	@param	pStorageInfo	�X�g���[�W���
	@param	pRes	�v���t�@�C���擾����
	@param	pProfileInfo	�v���t�@�C�����
	@param	pdwData	�v���t�@�C���f�[�^
	@param	dwDataSize	pdwData��BYTE�T�C�Y
	@return	���^�[���R�[�h
	@note	
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetStorageProfile(LONG lDeviceId, LJV7IF_GET_STORAGE_REQ* pReq, LJV7IF_STORAGE_INFO* pStorageInfo, LJV7IF_GET_STORAGE_RSP* pRes, LJV7IF_PROFILE_INFO* pProfileInfo, DWORD* pdwData, DWORD dwDataSize);

	/**
	�o�b�`�v���t�@�C���X�g���[�W�f�[�^�擾
	@param	lDeviceId	�f�o�C�XID
	@param	pReq	�擾�o�b�`�v���t�@�C���w����
	@param	pStorageInfo	�X�g���[�W���
	@param	pRes	�o�b�`�v���t�@�C���擾����
	@param	pProfileInfo	�v���t�@�C�����
	@param	pdwData	�v���t�@�C���f�[�^
	@param	dwDataSize	pdwData��BYTE�T�C�Y
	@param	pTimeOffset	����������ms�P�ʂ̌o�ߎ���
	@param	pMeasureData	���茋��
	@return	���^�[���R�[�h
	@note	
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_GetStorageBatchProfile(LONG lDeviceId, LJV7IF_GET_BATCH_PROFILE_STORAGE_REQ* pReq, LJV7IF_STORAGE_INFO* pStorageInfo, 
		LJV7IF_GET_BATCH_PROFILE_STORAGE_RSP* pRes, LJV7IF_PROFILE_INFO* pProfileInfo, DWORD* pdwData, DWORD dwDataSize, DWORD* pTimeOffset, LJV7IF_MEASURE_DATA* pMeasureData);

	// �����f�[�^�ʐM�֘A
	/**
	�����f�[�^�ʐM������(USB)
	@param	lDeviceId	�f�o�C�XID
	@param	pCallBack	��M�����s�֐�
	@param	dwProfileCnt	pCallBack�Ăяo���p�x
	@param	dwThreadId	�X���b�hID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_HighSpeedDataUsbCommunicationInitalize(LONG lDeviceId, LJV7IF_CALLBACK pCallBack, DWORD dwProfileCnt, DWORD dwThreadId);

	/**
	�����f�[�^�ʐM������(Ethernet)
	@param	lDeviceId	�f�o�C�XID
	@param	pEthernetConfig	Ethernet�ݒ�
	@param	wHighSpeedPortNo	�����f�[�^�ʐM�|�[�g
	@param	pCallBack	��M�����s�֐�
	@param	dwProfileCnt	pCallBack�Ăяo���p�x
	@param	dwThreadId	�X���b�hID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_HighSpeedDataEthernetCommunicationInitalize(LONG lDeviceId, LJV7IF_ETHERNET_CONFIG* pEthernetConfig, WORD wHighSpeedPortNo,
		LJV7IF_CALLBACK pCallBack, DWORD dwProfileCnt, DWORD dwThreadId);

	/**
	�����f�[�^�ʐM�J�n����
	@param	lDeviceId	�f�o�C�XID
	@param	pReq	���M�f�[�^���
	@param	pProfileInfo	�v���t�@�C�����
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_PreStartHighSpeedDataCommunication(LONG lDeviceId, LJV7IF_HIGH_SPEED_PRE_START_REQ* pReq, LJV7IF_PROFILE_INFO* pProfileInfo);

	/**
	�����f�[�^�ʐM�J�n
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_StartHighSpeedDataCommunication(LONG lDeviceId);

	/**
	�����f�[�^�ʐM��~
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_StopHighSpeedDataCommunication(LONG lDeviceId);

	/**
	�����f�[�^�ʐM�I��
	@param	lDeviceId	�f�o�C�XID
	@return	���^�[���R�[�h
	*/
	LJV7_IF_API LONG WINAPI LJV7IF_HighSpeedDataCommunicationFinalize(LONG lDeviceId);


};
#pragma managed(pop)