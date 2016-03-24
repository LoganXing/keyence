//Copyright(c) 2012, KEYENCE CORPORATION. All rights reserved.
/** @file
@brief	LJV7_ErrorCode�̃w�b�_
*/

#define LJV7IF_RC_OK						0x0000	// ����I��
#define LJV7IF_RC_ERR_OPEN					0x1000	// �ʐM�o�H�̃I�[�v���Ɏ��s���܂����B
#define LJV7IF_RC_ERR_NOT_OPEN				0x1001	// �ʐM�o�H���m������Ă��܂���B
#define LJV7IF_RC_ERR_SEND					0x1002	// �R�}���h�̑��M�Ɏ��s���܂����B
#define LJV7IF_RC_ERR_RECEIVE				0x1003	// ���X�|���X�̎�M�Ɏ��s���܂����B
#define LJV7IF_RC_ERR_TIMEOUT				0x1004	// ���X�|���X�̎�M�ŁA�^�C���A�E�g���������܂����B
#define LJV7IF_RC_ERR_NOMEMORY				0x1005	// �������̊m�ۂɎ��s���܂����B
#define LJV7IF_RC_ERR_PARAMETER			0x1006	// �s���ȃp�����[�^���n����܂����B
#define LJV7IF_RC_ERR_RECV_FMT				0x1007	// ��M�������X�|���X�f�[�^���s���ł��B

#define LJV7IF_RC_ERR_HISPEED_NO_DEVICE	0x1009 // ��OPEN�G���[(�����ʐM�p)
#define LJV7IF_RC_ERR_HISPEED_OPEN_YET		0x100A // OPEN�ς݃G���[(�����ʐM�p)
#define LJV7IF_RC_ERR_HISPEED_RECV_YET		0x100B // ���ɍ����ʐM���G���[(�����ʐM�p)
#define LJV7IF_RC_ERR_BUFFER_SHORT			0x100C	// �����œn���ꂽ�o�b�t�@�T�C�Y������܂���B
