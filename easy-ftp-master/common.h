/****************************
* title: ��������Ĺ���������
* description: ѧϰftpЭ����c++ͨ��ƪ��һ��ѧϰ��Ŀ�����������Ѿ��Լ������Ѿ�̽����ϣ������Ŀ�����ѧϰ��Ҫ�����ѣ�ϣ���ܰ�����һ������
* datetime: 2020��6��15��16:11:19
* author: Sindsun
* from: http://www.sindsun.com
****************************/
#ifndef COMMON_H
#define COMMON_H

#include <iostream>
#include <string>
#include <windows.h>
#include <locale.h>
#include <codecvt>
#include <locale>

using namespace std;

class Common{
public:
    Common();
    ~Common();

    //��utf8ת��ΪGBK,windows����windows.h
    string utf8ToGbk(const char *src_str);
    //��gbk�����ַ�ת��Ϊutf8
    string gbkToUtf8(const char *src_str);
};

#endif // COMMON_H
