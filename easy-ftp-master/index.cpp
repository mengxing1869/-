#include "index.h"

//���캯��
Index::Index()
{
    this->pCommon = new Common;

    if(!this->initSocketLib()){
        this->error(this->errorMsg);
        exit(-1);
    }
}
//��������
Index::~Index()
{
    closesocket(this->ctrlSock);
    closesocket(this->dataConnSock);
    closesocket(this->dataTransSock);
    WSACleanup();
}
//����ʼ
void Index::appStart()
{
    cout << endl << "��ӭʹ��sindftp! (���������www.sindsun.com)" <<endl << endl;

    if(!this->login()){
        this->error(this->errorMsg);
        cout << "error code is " << replyCode << endl;
        Sleep(3000);
        system("cls");
        this->appStart();
    }
    this->menuList();
}
//��¼
bool Index::login()
{
    cout << endl << setw(12) << "������ַ: "  ;
    cin >> this->hostName;

    cout << endl << setw(12) << "�˿ں�: ";
    cin >> this->portNum;

    cout << endl << setw(12) << "�˺�: ";
    cin >> this->userName;

    cout << endl << setw(12) << "����: ";
    cin >> this->userPwd;
    cout << endl << endl;

    this->ctrlSock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if(this->ctrlSock == static_cast<unsigned>(SOCKET_ERROR)){
        this->error("����socketʧ��");
        exit(-1);
    }

    sockaddr_in addr;
    addr.sin_family = AF_INET;
    addr.sin_port = htons(static_cast<unsigned short>(this->portNum));
    addr.sin_addr.s_addr = inet_addr(this->hostName.c_str());
    int connStatus = connect(this->ctrlSock, reinterpret_cast<sockaddr *>(&addr), sizeof (addr));
    if(connStatus == -1){
        this->errorMsg = "���ӷ�����ʧ��";
        return false;
    }
    if(!this->recvFromRemote() || this->replyCode != 220){
        this->errorMsg = "���ӷ���������";
        return false;
    }

    //�����¼
    this->requestString = "USER " + this->userName;
    if(!sendToRemote(true) || this->replyCode != 331){
        this->errorMsg = "�û�������";
        return false;
    }
    this->requestString = "PASS " + this->userPwd;
    if(!sendToRemote(true) || this->replyCode != 230){
        this->errorMsg = "�û������������";
        return false;
    }

    return true;
}
//�˵��б�
void Index::menuList()
{
    cout << "----------- sindftp ------------" << endl << endl;
    cout << "--------------------------------" << endl << endl;
    cout << "��ʾ�˵�\t menu" << endl << endl;
    cout << "�л�Ŀ¼\t cwd dirname" << endl << endl;
    cout << "�ļ��б�\t list dirname" << endl << endl;
    //cout << "�ļ�������\t rename filename" << endl << endl;
    cout << "�ϴ��ļ�\t upload filename" << endl << endl;
    cout << "�����ļ�\t download filename" << endl << endl;
    cout << "ɾ���ļ�\t del filename" << endl << endl;
    cout << "������Ϣ\t help" << endl << endl;
    cout << "�����Ļ\t clear" << endl << endl;
    cout << "�˳�ƽ̨\t quit" << endl << endl;
    cout << "--------------------------------" << endl;
    cout << endl;

    localInput();
}
//�����������봦��
void Index::localInput()
{
    requestString = "";
    responseString = "";
    errorMsg = "";

    string userInputCmd = "";
    cout << endl;
    cout << "input cmd ### " ;
    cin.sync();
    getline(cin, userInputCmd);

    if(userInputCmd.length() < 1){
        errorMsg = "��������ȷ�����";
        localInput();
        return;
    }
    //�ָ����������
    string cmd = "";
    string param = "";
    bool cmdOver = false;
    for(char ch:userInputCmd){
        if(ch == ' '){
            cmdOver = true;
            continue;
        }

        if(cmdOver){
            param += ch;
        }else{
            cmd += ch;
        }
    }
    //��������
    if(cmd == "help"){  //����
        requestString = "HELP";
        sendToRemote(true);
    }else if(cmd == "menu"){  //�˵�
        menuList();
    }else if(cmd == "cwd"){  //�ı�Ŀ¼
        //�ı�����Ŀ¼
        requestString = "CWD "+param;
        sendToRemote(true);
    }else if(cmd == "list"){  //�б�
        getList(param);
    }else if(cmd == "rename"){  // ������

    }else if(cmd == "upload"){  //�ϴ�
        uploadFile(param);
    }else if(cmd == "download"){  //����
        downloadFile(param);
    }else if(cmd == "del"){  //ɾ��
        deleteFile(param);
    }else if(cmd == "clear"){  //�����Ļ
        system("cls");
        menuList();
    }else if(cmd == "quit"){  //�˳�
        cout << "Bye bye!" <<endl;
        exit(-1);
    }else{
        //errorMsg = "��������ȷ�����";
        //error(errorMsg);
        requestString = userInputCmd;
        sendToRemote(true);
    }

    localInput();
}
//Զ�������
bool Index::sendToRemote(bool returnReplyCode)
{
    if(this->requestString.length() < 1){
        this->errorMsg = "ftp�����Ϊ��";
        return false;
    }
    cout << endl << setw(10) << "��������: " << setw(10) << requestString << endl;

    requestString += "\r\n";
    requestString = this->pCommon->gbkToUtf8(requestString.c_str());
    unsigned int cmdLength = requestString.length();
    char *tmpCmdStr = new char[cmdLength];
    memset(tmpCmdStr, 0, cmdLength);
    memcpy(tmpCmdStr, requestString.c_str(), cmdLength);

    int sendStatus = send(this->ctrlSock, tmpCmdStr, static_cast<int>(cmdLength), 0);
    delete [] tmpCmdStr;
    if(sendStatus == -1){
        this->errorMsg = "����ʧ��";
        return false;
    }
    if(returnReplyCode){
        return recvFromRemote();
    }
    return true;
}
//����Զ����Ӧ
bool Index::recvFromRemote()
{
    if(this->ctrlSock == INVALID_SOCKET){
        this->errorMsg = "�����ѶϿ� ";
        return false;
    }
    char buf[MAX_MSG_SIZE];
    int recvStatus = -1;
    responseString = "";

    while(true){
        memset(buf, 0, MAX_MSG_SIZE);
        Sleep(500);
        recvStatus = recv(this->ctrlSock, buf, MAX_MSG_SIZE, MSG_PARTIAL);
        //cout << "######### " << buf << endl;
        if(recvStatus > 0){
            responseString = buf;
            break;
        }
    }
    if(responseString.length() == 0){
        this->errorMsg = "��������ʧ��";
        return false;
    }
    this->success(responseString);

    return this->getReplyCode();
}
//����Զ����Ӧ��������Ӧ��
bool Index::getReplyCode()
{
    string tmpMsg = "";
    tmpMsg = responseString.substr(0, 3);
    char charCode[3] = {};

    memcpy(charCode, tmpMsg.c_str(), tmpMsg.length());
    this->replyCode = static_cast<unsigned int>(atoi(charCode));
    if( !(this->replyCode >= 1 && this->replyCode <= 1000)){
        this->errorMsg = "�޷���ȡ����Ӧ��";
        return false;
    }

    return true;
}
//д��־�ļ�
bool Index::writeLogs(string msg)
{
    if(msg.length() == 0){
        return false;
    }
    SYSTEMTIME sTime;
    GetLocalTime(&sTime);
    char fullTime[20];
    memset(fullTime, 0, 20);
    sprintf(fullTime, "%4d-%02d-%02d %02d:%02d:%02d", sTime.wYear, sTime.wMonth, sTime.wDay,
            sTime.wHour, sTime.wMinute, sTime.wSecond);
    msg = "\r\n" + msg;
    msg = fullTime + msg;

    fstream fs;
    fs.open("d:/test/datasock_recv_logs.log", ios::app);

    fs << msg << endl;

    fs.close();

    return true;
}
//��ʾ����
void Index::error(string errorStr)
{
    if(errorStr.length() > 0){
        cout << endl;
        cout << "Error: " << errorStr;
        cout << endl;
    }
}
//��ʾ�ɹ�
void Index::success(string sucStr)
{
    if(sucStr.length() > 0){
        cout << endl;
        cout << "������Ӧ:" << endl;
        cout << sucStr;
        cout << endl;
    }
}
//��ֵѡ�����ݴ���ģʽ
bool Index::transModelSelect()
{
    if(transModeVal == TransMode::PORT){
        return portMode();
    }else if(transModeVal == TransMode::PASV){
        return pasvMode();
    }else{
        return (pasvMode() || portMode());
    }
}
//PORT��������ģʽ
bool Index::portMode()
{
    dataConnSock = socket(AF_INET, SOCK_STREAM, 0);
    if(dataConnSock == static_cast<unsigned>(SOCKET_ERROR)){
        errorMsg = "��ʼ������socketʧ��";
        return false;
    }

    portDataConnCount += 1;

    sockaddr_in addr;
    int addrLength = sizeof (addr);
    int getsocknameStatus = getsockname(ctrlSock, reinterpret_cast<sockaddr *>(&addr), &addrLength);
    if(getsocknameStatus == -1){
        errorMsg = "��ȡsocket��Ϣʧ��";
        return false;
    }
    int localPort = ntohs(addr.sin_port) + portDataConnCount;   //��ȡ��������˿�+1

    addr.sin_family = AF_INET;
    addr.sin_port = htons(static_cast<u_short>(localPort));
    //addr.sin_addr.s_addr = htonl(INADDR_ANY);

    int countBind = 0;
    int bindStatus = -1;
    while(bindStatus != 0){
        bindStatus = bind(dataConnSock, reinterpret_cast<sockaddr *>(&addr), sizeof (addr));
        countBind ++;
        if(countBind >= 10){
            break;
        }
    }
    if(bindStatus == -1){
        errorMsg = "��ʧ��";
        return false;
    }

    //����ģʽ�µļ���һ��Ҫ�ŵ�������������������֮��
    int listenStatus = listen(dataConnSock, 64);
    if(listenStatus == -1){
        errorMsg = "����ʧ��";
        return false;
    }

    char *ipAddr = new char[32];
    memset(ipAddr, 0, 32);
    ipAddr = inet_ntoa(addr.sin_addr);

    //����˿ں�
    char charPortNum1[5];
    char *portNum1 = itoa(localPort/256, charPortNum1, 10);
    char charPortNum2[5];
    char *portNum2 = itoa(localPort%256, charPortNum2, 10);

    string portModelStr = ipAddr;
    portModelStr += ",";
    portModelStr += portNum1;
    portModelStr += ",";
    portModelStr += portNum2;
    //�滻����������ַ�
    for(char &c:portModelStr){
        if(c == '.'){
            c = ',';
        }
    }
    requestString = "PORT " + portModelStr;
    if(!sendToRemote(true)){
        errorMsg = "����port����ʧ��";
        return false;
    }

    transModeVal = TransMode::PORT;

    success("PORTģʽ�����ɹ�");

    return true;
}
//����Զ�����ӱ���
bool Index::allowAccept()
{
    if(transModeVal != TransMode::PORT){
        return true;
    }
    sockaddr_in acceptAddr;
    int acceptAddrLength = sizeof (acceptAddr);
    dataTransSock = accept(dataConnSock, reinterpret_cast<sockaddr *>(&acceptAddr), &acceptAddrLength);
    if(dataTransSock == static_cast<u_short>(INVALID_SOCKET)){
        errorMsg = "��������ʧ��";
        return false;
    }
    return true;
}
//PASV����ģʽ
bool Index::pasvMode()
{
    dataTransSock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if(dataTransSock == static_cast<u_short>(SOCKET_ERROR)){
        errorMsg = "PASV socket��ʼ��ʧ��";
        return false;
    }
    requestString = "PASV";
    if(!sendToRemote(true) || replyCode != 227){
        errorMsg = "PASV����ʧ��";
        return false;
    }
    //�����ַ���
    char *newChar = strrchr(responseString.c_str(), '(') + 1;
    string tmpStr = newChar + 1;
    int spCount = 0;
    string p1 = "";
    string p2 = "";
    for(char ch:tmpStr){
        if(ch == ')'){
            break;
        }
        if(ch == ','){
            spCount ++;
            continue;
        }
        if(spCount > 3){
            if(spCount == 4){
                p1 += ch;
            }else{
                p2 += ch;
            }
        }
    }
    int dataPort = atoi(p1.c_str()) * 256 + atoi(p2.c_str());
    cout << "p1 " << p1 << endl;
    cout << "p2 " << p2 << endl;
    cout << "port " << dataPort << endl;
    sockaddr_in addr;
    addr.sin_family = AF_INET;
    addr.sin_port = htons(static_cast<u_short>(dataPort));
    addr.sin_addr.s_addr = inet_addr(hostName.c_str());
    int ret = connect(dataTransSock, reinterpret_cast<sockaddr *>(&addr), sizeof (addr));
    if(ret == -1){
        errorMsg = "PASV���ӷ�����ʧ��";
        error(errorMsg);
        closesocket(dataTransSock);
        return false;
    }

    transModeVal = TransMode::PASV;

    success("PASVģʽ�����ɹ�");

    return true;
}
//��ȡ�ļ��б�
bool Index::getList(string dirPath)
{
    if(!transModelSelect()){
        error(errorMsg);
        return false;
    }
    requestString = "LIST "+dirPath;
    if(!sendToRemote(true) || replyCode != 150 ){
        error(errorMsg);
        return false;
    }

    if(!allowAccept()){
        error(errorMsg);
        return false;
    }

    char *recvData = new char[MAX_MSG_SIZE];
    memset(recvData, 0 , MAX_MSG_SIZE);
    //�����150,��Ҫ�ٽ���һ�����ݷ��ͽ�����֪ͨ
    int recvStatus = recv(dataTransSock, recvData, MAX_MSG_SIZE, 0);
    if(recvStatus == -1){
        error("��������ʧ��");
        return false;
    }

    success(pCommon->utf8ToGbk(recvData));
    writeLogs(recvData);
    success("д����־�ļ��ɹ�");
    delete [] recvData;


    return true;
}
//�ϴ��ļ�
bool Index::uploadFile(string filePath)
{
    if(!transModelSelect()){
        return false;
    }
    char *fileName = strrchr(filePath.c_str(), '/');
    requestString = "STOR ";
    requestString += fileName +1;
    if(!sendToRemote(true)){
        errorMsg = "�����ʧ��";
        return false;
    }
    if(!allowAccept()){
        return false;
    }

    fstream fs;
    fs.open(filePath, ios::in);
    char buf[MAX_MSG_SIZE];
    memset(buf, 0, MAX_MSG_SIZE);
    bool status = true;
    while(!fs.eof()){
        fs.read(buf, MAX_MSG_SIZE);
        int storStatus = send(dataTransSock, buf, sizeof (buf), 0);
        if(storStatus == -1){
            errorMsg = "�ϴ��ļ��쳣";
            status = false;
            break;
        }
    }
    closesocket(dataTransSock);
    if(!status){
        return false;
    }

    return true;
}
//�����ļ�
bool Index::downloadFile(string fileName)
{
    //�Ȼ�ȡ�ļ���С
    requestString = "SIZE ";
    requestString += fileName;
    if(!sendToRemote(true)){
        errorMsg = "�����ʧ��";
        return false;
    }
    int fileSize = atoi(responseString.substr(4).c_str());

    if(!transModelSelect()){
        return false;
    }
    requestString = "RETR " + fileName;
    if(!sendToRemote(true)){
        errorMsg = "�����ʧ��";
        return false;
    }
    if(!allowAccept()){
        errorMsg = "����ʧ��";
        return false;
    }
    //��ʼ�������ض���
    string localPath = "d:/test/d_" + fileName;
    fstream fs;
    fs.open(localPath, ios::app);
    int countFileSize = 0;
    char *buf = new char[MAX_MSG_SIZE];
    while (countFileSize < fileSize) {
        memset(buf, 0, MAX_MSG_SIZE);
        recv(dataTransSock, buf, MAX_MSG_SIZE, 0);
        if(strlen(buf) < 1){
            break;
        }
        fs << buf ;
        countFileSize += strlen(buf);
    }
    fs.close();

    return true;
}
//ɾ���ļ�
bool Index::deleteFile(string fileName)
{
    if(!transModelSelect()){
        return false;
    }
    requestString = "DELE " + fileName;
    if(!sendToRemote(true)){
        errorMsg = "�����ʧ��";
        return false;
    }


    return true;
}
//���������ʼ��
bool Index::initSocketLib()
{
    WSADATA wsa;
    WORD vCode = MAKEWORD(2, 2);
    int wsaStartupStatus = WSAStartup(vCode, &wsa);
    if(wsaStartupStatus == -1){
        this->errorMsg = "��ʼ���׽��ֿ�ʧ�ܣ�������";
        return false;
    }
   //����׽��ְ汾��
   if(LOBYTE(wsa.wVersion) != 2 || HIBYTE(wsa.wHighVersion) != 2){
       WSACleanup();
       this->errorMsg = "�׽��ְ汾�Ų����ϣ�����������";
       return false;
   }
   return true;
}
