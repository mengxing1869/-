package zoo;

import java.util.ArrayList;
import java.util.Scanner;

public class zooSystem {
    ArrayList<Tender> tenderlist =new ArrayList<Tender>();
    ArrayList<Animail> animaillist=new ArrayList<Animail>();
    public static void main(String[] args) {
        zooSystem z = new zooSystem();
        Scanner sc = new Scanner(System.in);
        String user="zxy";
        String psw="123456";
        while (true) {
            int i;
            for (i = 3; i > 0; i--) {
                System.out.print("账户:");
                String user1 = sc.next();
                System.out.print("密码:");
                String psw1 = sc.next();
                if (user1.equals(user) && psw1.equals(psw)) {
                    System.out.println("登录成功");
                    break;
                } else {
                    System.out.println("账号或密码错误，请重新输入");
                }
            }
            if(i==0){
                System.out.println("输入机会已用完");
                break;
            }
            while(true){
                System.out.println("请选择：");
                System.out.println("1:动物管理界面");
                System.out.println("2:饲养员管理界面");
                System.out.println("3:退出登录");
                int a= sc.nextInt();
                if(a==1) {
                    z.animail();
                }else if(a==2){
                    z.tenderAdmin();
                }else if(a==3){
                    break;
                }else{
                    System.out.println("输入有误，请重新输入！");
                    sc.next();
                }
            }
        }
    }
    public void tenderAdmin(){
        Scanner sc = new Scanner(System.in);
        while(true) {
            System.out.println("请选择：");
            System.out.println("1:添加饲养员");
            System.out.println("2:修改饲养员工资");
            System.out.println("3:删除饲养员信息");
            System.out.println("4:查看饲养员信息");
            System.out.println("5:退出饲养员管理界面");
            int a = sc.nextInt();
            switch (a) {
                case 1:
                    addTender();
                    printTender();
                    break;
                case 2:
                    modTender();
                    break;
                case 3:
                    delTender();
                    break;
                case 4:
                    checkTender();
                    break;
                case 5:
                    return;
                default:
                    System.out.println("输入有误，请重新输入！");
                    break;
            }
        }
    }
    public void animail(){
        Scanner sc = new Scanner(System.in);
        while(true) {
            System.out.println("请选择：");
            System.out.println("1:添加动物信息");
            System.out.println("2:修改动物数量");
            System.out.println("3:删除动物信息");
            System.out.println("4:查看动物信息");
            System.out.println("5:修改动物饲养员");
            System.out.println("6:退出动物管理界面");
            int a = sc.nextInt();
            switch (a) {
                case 1:
                    addAnimail();
                    printAnimail();
                    break;
                case 2:
                    modAnimail();
                    break;
                case 3:
                    delAnimail();
                    break;
                case 4:
                    checkAnimail();
                    break;
                case 5:
                    tenderAnimail();
                    break;
                case 6:
                    return;
                default:
                    System.out.println("输入有误，请重新输入！");
                    break;
            }
        }
    }
    public void tenderAnimail(){
        Scanner sc=new Scanner(System.in);
        if(animaillist.isEmpty()){
            System.out.println("当前无动物信息！");
            return;
        }
        printAnimail();
        System.out.print("根据当前动物列表选择想要修改的动物编号:");
        String no =sc.next();
        for(int i=0;i<animaillist.size();i++){
            if(no.equals(animaillist.get(i).no)){
                printTender();
                System.out.println("根据当前饲养员列表选择更改后的饲养员编号:");
                String tno=sc.next();
                if(tno.equals(animaillist.get(i).tender.no)) {
                    System.out.println("输入编号与当前饲养员编号一致，修改无效!");
                    return;
                }
                //修改动物类中饲养员信息并在对应饲养员中添加该动物类的信息
                for(int l=0;l<tenderlist.size();l++){
                    if(tno.equals(tenderlist.get(l).no)){
                        //删除原本编号饲养员中饲养动物中该动物的信息
                        for(int j=0;j<tenderlist.size();j++){
                            if(animaillist.get(i).tender.no.equals(tenderlist.get(j).no)){
                                for(int k=0;k<tenderlist.get(j).animal.size();k++) {
                                    if(tenderlist.get(j).animal.get(k).no.equals(animaillist.get(i).no))
                                        tenderlist.get(j).animal.remove(k);
                                }
                            }
                        }
                        animaillist.get(i).tender=tenderlist.get(l);
                        tenderlist.get(l).animal.add(animaillist.get(i));
                        System.out.println("修改成功!");
                        return;
                    }
                }
                System.out.println("输入的饲养员编号编号不存在!");
                return;
            }
        }
        System.out.println("输入的动物编号不存在!");
    }
    public void addTender(){
        Scanner sc = new Scanner(System.in);
        System.out.print("编号:");
        String no=sc.next();
        System.out.print("姓名:");
        String name=sc.next();
        System.out.print("工资:");
        int wages=sc.nextInt();
        for(int i=0;i<tenderlist.size();i++){
            if(no.equals(tenderlist.get(i).no)){
                System.out.println("编号重复，录入失败");
                return;
            }
        }
        tenderlist.add(new Tender(no,name,wages));
    }
    public void addAnimail(){
        if(tenderlist.isEmpty()){
            System.out.println("动物需要饲养员，当前无饲养员，无法饲养动物");
            return;
        }
        Scanner sc = new Scanner(System.in);
        System.out.print("动物编号:");
        String no=sc.next();
        System.out.print("动物名称:");
        String name=sc.next();
        System.out.print("动物数量:");
        int num=sc.nextInt();
        for(int i=0;i<animaillist.size();i++){
            if(no.equals(animaillist.get(i).no)){
                System.out.println("动物编号重复，录入失败");
                return;
            }
        }
        printTender();
        System.out.println("请按照编号为当前动物选择一个饲养员:");
        String tno=sc.next();
        for(int i=0;i<tenderlist.size();i++){
            if(tno.equals(tenderlist.get(i).no)){
                tenderlist.get(i).animal.add(new Animail(no,name,num,tenderlist.get(i)));
                animaillist.add(new Animail(no,name,num,tenderlist.get(i)));
                System.out.println("录入成功!");
                return;
            }
        }
        System.out.println("该编号饲养员不存在！录入失败");
    }
    public void modTender(){
        if(tenderlist.isEmpty()){
            System.out.println("当前无饲养员信息！");
            return;
        }
        Scanner sc = new Scanner(System.in);
        printTender();
        System.out.println("请输入编号选择想要修改的饲养员信息");
        String no = sc.next();
        for(int i=0;i<tenderlist.size();i++){
            if(no.equals(tenderlist.get(i).no)){
                System.out.println("输入修改后的工资");
                tenderlist.set(i,new Tender(tenderlist.get(i).no,tenderlist.get(i).name,sc.nextInt()));
                System.out.println("修改成功");
                return;
            }
        }
        System.out.println("编号不存在！");
    }
    public void modAnimail(){
        if(animaillist.isEmpty()){
            System.out.println("当前无动物信息！");
            return;
        }
        Scanner sc = new Scanner(System.in);
        printAnimail();
        System.out.println("请输入编号选择想要修改的动物信息");
        String no = sc.next();
        for(int i=0;i<animaillist.size();i++){
            if(no.equals(animaillist.get(i).no)){
                System.out.println("输入修改后的数量");
                animaillist.set(i,new Animail(animaillist.get(i).no,animaillist.get(i).name,sc.nextInt(),animaillist.get(i).tender));
                System.out.println("修改成功");
                return;
            }
        }
        System.out.println("编号不存在！");
    }
    public void delTender(){
        Scanner sc = new Scanner(System.in);
        if(tenderlist.isEmpty()){
            System.out.println("当前无饲养员信息！");
            return;
        }
        if(tenderlist.size()==1&&!animaillist.isEmpty())
        {
            System.out.println("当前饲养员仅剩一名，删除后动物将无人饲养");
            return;
        }
        printTender();
        System.out.print("请输入编号选择想要删除的饲养员信息:");
        String no = sc.next();
        int x=tenderlist.get(0).animal.size();//x记录删除的饲养员饲养的动物种类数量
        int y=tenderlist.get(0).animal.size();//y记录即将转到的饲养员的动物种类数量
        int n=0,m=0;//n记录要删除的饲养员在集合中下标，m为动物即将转到的饲养员在集合中的下标
        boolean t=false;
        for(int i=0;i<tenderlist.size();i++){
            if(no.equals(tenderlist.get(i).no)){
                if(i==0){
                    y=tenderlist.get(1).animal.size();
                    m=1;
                }
                n=i;
                x=tenderlist.get(i).animal.size();
                t=true;
            } else if(y>tenderlist.get(i).animal.size()){
                m=i;
                y=tenderlist.get(i).animal.size();
            }
        }
        if(!t){
            System.out.println("编号不存在!");
            return;
        }
        for(int i=0;i<x;i++)
        {
            for(int j=0;j<animaillist.size();j++)
            {
                if(animaillist.get(j).no.equals(tenderlist.get(n).animal.get(i).no))
                {
                    animaillist.get(j).tender=tenderlist.get(m);
                    tenderlist.get(m).animal.add(animaillist.get(j));
                }
            }

        }
        tenderlist.remove(n);
        System.out.println("删除成功，当前饲养员饲养的动物已经默认转入当前饲养动物最少的饲养员");
    }
    public void delAnimail(){
        Scanner sc = new Scanner(System.in);
        if(animaillist.isEmpty()){
            System.out.println("当前无动物信息！");
            return;
        }
        printAnimail();
        System.out.println("请输入编号选择想要删除的动物信息");
        String no = sc.next();
        for(int i=0;i<animaillist.size();i++){
            if(no.equals(animaillist.get(i).no)){
                for(int j=0;j<tenderlist.size();j++){
                    if(animaillist.get(i).tender.no.equals(tenderlist.get(j).no)){
                        for(int k=0;k<tenderlist.get(j).animal.size();k++) {
                            if(tenderlist.get(j).animal.get(k).no.equals(animaillist.get(i).no))
                                tenderlist.get(j).animal.remove(k);
                        }
                    }
                }
                animaillist.remove(i);
                System.out.println("删除成功!");
                return;
            }
        }
        System.out.println("编号不存在!");
    }
    public void checkTender(){
        Scanner sc = new Scanner(System.in);
        if(tenderlist.isEmpty()){
            System.out.println("当前无饲养员信息！");
            return;
        }
        printTender();
        System.out.print("请输入编号选择想要查找的成员：");
        String no=sc.next();
        for(int i=0;i<tenderlist.size();i++){
            if(no.equals(tenderlist.get(i).no)){
                System.out.println("饲养员信息\n编号:"+tenderlist.get(i).no+"\n姓名:"+tenderlist.get(i).name+"\n工资:"+tenderlist.get(i).wages);
                System.out.println("饲养的动物列表:\n动物编号  动物名称");

                if(tenderlist.get(i).animal.isEmpty()){
                    System.out.println("该饲养员当前未饲养动物！");
                }
                else {
                    for (int j = 0; j < tenderlist.get(i).animal.size();j++){
                        System.out.println(tenderlist.get(i).animal.get(j).no+"       "+tenderlist.get(i).animal.get(j).name);
                    }
                }
                return;
            }
        }
        System.out.println("未查找到该编号成员!");
        return;
    }
    public void checkAnimail(){
        Scanner sc = new Scanner(System.in);
        if(animaillist.isEmpty()){
            System.out.println("当前无动物信息!");
            return;
        }
        printAnimail();
        System.out.print("请输入编号选择想要查找的动物：");
        String no=sc.next();
        for(int i=0;i<animaillist.size();i++){
            if(no.equals(animaillist.get(i).no)){
                System.out.println("动物信息\n编号:"+animaillist.get(i).no+"\n名称:"+animaillist.get(i).name+"\n数量:"+animaillist.get(i).num+"\n饲养员:"+animaillist.get(i).tender.name);
                return;
            }
        }
        System.out.println("未查找到该编号动物!");
        return;
    }
    public void printTender(){
        System.out.println("当前成员列表");
        System.out.println("编号  姓名");
        for(int i =0;i<tenderlist.size();i++){
            System.out.println(tenderlist.get(i).no+"   "+tenderlist.get(i).name);
        }
    }
    public void printAnimail(){
        System.out.println("当前动物列表");
        System.out.println("编号  名称");
        for(int i =0;i<animaillist.size();i++){
            System.out.println(animaillist.get(i).no+"   "+animaillist.get(i).name);
        }
    }

}
