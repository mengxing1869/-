/****************************
* title: ftp��������
* description: ѧϰftpЭ����c++ͨ��ƪ��һ��ѧϰ��Ŀ�����������Ѿ��Լ������Ѿ�̽����ϣ������Ŀ�����ѧϰ��Ҫ�����ѣ�ϣ���ܰ�����һ������
* datetime: 2020��6��15��16:11:19
* author: Sindsun
* from: http://www.sindsun.com
****************************/
#ifndef INDEX_H
#define INDEX_H

#include <iostream>
#include <string>
#include <winsock2.h>
#include <fstream>
#include <windows.h>
#include <iomanip>
#include <locale>

#include "common.h"

using namespace std;

#define MAX_MSG_SIZE 1024


class Index{
public:
    Index();
    ~Index();
    //����ʼ
    void appStart();
private:
    Common *pCommon;

    enum TransMode{
        AUTO, PORT, PASV
    };

    //������
    string hostName = "";
    //�˿ں�
    int portNum = 0;
    //�û���
    string userName = "";
    //����
    string userPwd = "";


    //��������socket
    SOCKET ctrlSock;
    //��������socket
    SOCKET dataConnSock;
    //���ݴ���socket
    SOCKET dataTransSock;


    //�����ַ���
    string requestString = "";
    //���յ���Ӧ�ַ���
    string responseString = "";
    //��Ӧ��
    unsigned int replyCode = 0;
    //����ģʽ�˿ںż���
    int portDataConnCount = 0;
    //������Ϣ
    string errorMsg = "";
    //ѡ�������ģʽ
    TransMode transModeVal = TransMode::AUTO;

    //���������ʼ��
    bool initSocketLib();
    //��¼
    bool login();
    //�˳���¼
    bool logout();
    //�˵��б�
    void menuList();
    //�����������봦��
    void localInput();
    //Զ�������
    bool sendToRemote(bool returnReplyCode=false);
    //����Զ����Ӧ
    bool recvFromRemote();
    //����Զ����Ӧ��������Ӧ��
    bool getReplyCode();
    //д��־�ļ�
    bool writeLogs(string msg);
    //��ʾ����
    void error(string errorStr);
    //��ʾ�ɹ�
    void success(string sucStr);
    //��ֵѡ�����ݴ���ģʽ
    bool transModelSelect();
    //PORT��������ģʽ
    bool portMode();
    //����Զ�����ӱ���
    bool allowAccept();
    //PASV����ģʽ
    bool pasvMode();
    //ftp������ʼ������
    bool initFtpParam();

    //��ȡ�ļ��б�
    bool getList(string dirPath);
    //�༭����
    bool setRename(string fileName);
    //�ϴ��ļ�
    bool uploadFile(string filePath);
    //�����ļ�
    bool downloadFile(string fileName);
    //ɾ���ļ�
    bool deleteFile(string fileName);

};

#endif // INDEX_H
