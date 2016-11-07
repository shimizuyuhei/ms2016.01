//Windows VC++ �ł́@TCP/IP �T���v���v���O�����i��������T�[�o�[�j
//�N���C�A���g���瑗���Ă����������啶���ɕϊ����đ���Ԃ�
//�T�[�o�[�v���O���������s���Ă���N���C�A���g�v���O���������s���ĉ�����

#include <stdio.h>
#include <winsock2.h>
#include <ws2tcpip.h>

#define PORT 9876 //�N���C�A���g�v���O�����ƃ|�[�g�ԍ������킹�Ă�������

int main() {
	int i;
	// �|�[�g�ԍ��C�\�P�b�g
	int srcSocket;  // ����
	int dstSocket;  // ����

	// sockaddr_in �\����
	struct sockaddr_in srcAddr;
	struct sockaddr_in dstAddr;
	int dstAddrSize = sizeof(dstAddr);
	int status;
	// �e��p�����[�^
	int numrcv;
	char buffer[1024];

	// Windows �̏ꍇ
	WSADATA data;
	WSAStartup(MAKEWORD(2, 0), &data);
	// sockaddr_in �\���̂̃Z�b�g
	memset(&srcAddr, 0, sizeof(srcAddr));
	srcAddr.sin_port = htons(PORT);
	srcAddr.sin_family = AF_INET;
	srcAddr.sin_addr.s_addr = htonl(INADDR_ANY);

	// �\�P�b�g�̐����i�X�g���[���^�j
	srcSocket = socket(AF_INET, SOCK_STREAM, 0);
	// �\�P�b�g�̃o�C���h
	bind(srcSocket, (struct sockaddr *) &srcAddr, sizeof(srcAddr));
	// �ڑ��̋���
	listen(srcSocket, 1);

	while (1){ //���[�v�ŉ񂷂��Ƃɂ���ĉ��x�ł��N���C�A���g����Ȃ����Ƃ��ł���

		// �ڑ��̎�t��
		printf("�ڑ���҂��Ă��܂�\n�N���C�A���g�v���O�����𓮂����Ă�������\n");
		dstSocket = accept(srcSocket, (struct sockaddr *) &dstAddr, &dstAddrSize);
		printf("%s ����ڑ����󂯂܂���\n", inet_ntoa(dstAddr.sin_addr));

		while (1){
			//�p�P�b�g�̎�M
			numrcv = recv(dstSocket, buffer, sizeof(char) * 6, 0);
			if (numrcv == 0 || numrcv == -1){
				status = closesocket(dstSocket); break;
			}
			buffer[6] = '\0';
			printf("�ϊ��O %s", buffer);
			for (i = 0; i< numrcv; i++){ // buf�̒��̏�������啶���ɕϊ�
				//if(isalpha(buffer[i])) 
				buffer[i] = toupper(buffer[i]);
			}
			// �p�P�b�g�̑��M
			send(dstSocket, buffer, sizeof(char) * 6, 0);
			printf("�� �ϊ��� %s \n", buffer);
		}
	}
	// Windows �ł̏I���ݒ�
	WSACleanup();

	return(0);
}