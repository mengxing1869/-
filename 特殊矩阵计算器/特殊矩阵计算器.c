#include<stdio.h>
#include<stdlib.h>

typedef struct{
    float *sa;  //储存用的一维数组指针
    int n;    //矩阵的行列数
    int kind; //特殊数组类型
    int x;    //矩阵为对角矩阵时的对角数
	int num;  //一维数组的数据个数
}Matrix;

void Print_Mat(float **matrix,int a)
{
    int i,j;
	for(i=0;i<a;i++)
	{
		for(j=0;j<a;j++)
			printf("%.2f\t",matrix[i][j]);
		printf("\n\n");
	}
}

void Upper_Triangular(Matrix *mat)  //上下三角矩阵输入
{
    int i;
    printf("请输入该矩阵的行列数：");
    scanf("%d",&mat->n);
    mat->num=(mat->n+1)*mat->n/2+1;
    mat->sa=(float*)malloc(mat->num*sizeof(float));
    printf("请以行为主序依次输入%d个数据(最后一个数是下三角中的常数):\n",mat->num);
    for(i=0;i<mat->num;i++)
    {
        scanf("%f",&mat->sa[i]);
    }
}

void Lower_Triangular(Matrix *mat)  //下三角矩阵输入
{   
    int i;
    printf("请输入该矩阵的行列数：");
    scanf("%d",&mat->n);
    mat->num=(mat->n+1)*mat->n/2+1;
    mat->sa=(float*)malloc(mat->num*sizeof(float));
    printf("请以行为主序依次输入%d个数据(最后一个数是上三角中的常数):\n",mat->num);
    for(i=0;i<mat->num;i++)
    {
        scanf("%f",&mat->sa[i]);
    }
}

void Symmetric(Matrix *mat)  //对称矩阵输入
{
    int i;
    printf("请输入该矩阵的行列数：");
    scanf("%d",&mat->n);
    mat->num=(mat->n+1)*mat->n/2;
    mat->sa=(float*)malloc(mat->num*sizeof(float));
    printf("请以行为主序依次输入该矩阵上三角中%d个数据:\n",mat->num);
    for(i=0;i<mat->num;i++)
    {
        scanf("%f",&mat->sa[i]);
    }
}

void Diagonal(Matrix *mat)  //对角矩阵输入
{
    int i;
    printf("请输入该矩阵的行列数：");
    scanf("%d",&mat->n);
    printf("请输入该矩阵的对角数：(奇数且小于行列数)");
    scanf("%d",&mat->x);
	mat->num=mat->n*mat->x-(1+mat->x/2)*(mat->x/2);
	printf("请以行为主序依次输入%d个数据:\n",mat->num);
	mat->sa=(float*)malloc(mat->num*sizeof(float));
	for(i=0;i<mat->num;i++)
    {
        scanf("%f",&mat->sa[i]);
    }
}

void Unit(Matrix *mat)
{
    printf("请输入矩阵的行列数：");
    scanf("%d",&mat->n);
}

void Import_Mat(Matrix *mat,int i)  //矩阵输入
{
    printf("请选择矩阵%d的类型\n",i);
    printf("1：上三角矩阵\n");
    printf("2：下三角矩阵\n");
    printf("3：对称矩阵\n");
    printf("4：对角矩阵\n");
    printf("5：单位矩阵\n\n");
    scanf("%d",&mat->kind);
    switch(mat->kind){
    case 1:Upper_Triangular(mat);break;
    case 2:Lower_Triangular(mat);break;
    case 3:Symmetric(mat);break;
    case 4:Diagonal(mat);break;
    case 5:Unit(mat);break;
    default:printf("操作错误，请重新输入\n");Import_Mat(mat,i);return;
    }
	printf("矩阵%d录入完成!\n",i);
}

float** Uncompress(Matrix mat)   //压缩矩阵解压
{
	int a,i,j;
    float **matrix;
	matrix=(float**)malloc(mat.n*sizeof(float*));
	for(i=0;i<mat.n;i++)
		matrix[i]=(float*)malloc(mat.n*sizeof(float));
	a=0;
	switch(mat.kind){
	case 1:
		{
			for(i=0;i<mat.n;i++)
				for(j=0;j<mat.n;j++)
				{
					if(i<=j)
						matrix[i][j]=mat.sa[a++];
					else
						matrix[i][j]=mat.sa[mat.num-1];
				}
		}
		break;
	case 2:
		{
			for(i=0;i<mat.n;i++)
				for(j=0;j<mat.n;j++)
				{
					if(i>=j)
						matrix[i][j]=mat.sa[a++];
					else
						matrix[i][j]=mat.sa[mat.num-1];
				}
		}
		break;
	case 3:
		{
			for(i=0;i<mat.n;i++)
				for(j=i;j<mat.n;j++)
				{
					if(i==j)
					{
						matrix[i][j]=mat.sa[a++];
					}
					else
					{
						matrix[i][j]=matrix[j][i]=mat.sa[a++];
					}
				}
		}
		break;
	case 4:
		{
			for(i=0;i<mat.n;i++)
				for(j=0;j<mat.n;j++)
				{
					if(j<=(i+mat.x/2)&&j>=(i-mat.x/2))
					{
						matrix[i][j]=mat.sa[a++];
					}
					else
					{
						matrix[i][j]=0;
					}
				}
		}
		break;
	case 5:
		{
			for(i=0;i<mat.n;i++)
				for(j=0;j<mat.n;j++)
				{
					if(i==j)
						matrix[i][j]=1;
					else
						matrix[i][j]=0;
				}
		}
		break;
	}
	return matrix;
}



float Mat(Matrix mat,int a,int b)   //返回压缩矩阵mat在a行b列的数据，没有返回0
{
	int x=0;     //x为压缩矩阵存储的a行之前的数据个数
	switch(mat.kind){
	case 1:
		{
			if(a<=b)
			{
				x=(2*mat.n-a+1)*a/2;
				return mat.sa[x+b-a];
			}
            else
			    return mat.sa[mat.num-1];
		}
		break;
	case 2:
		{
			if(a>=b)
			{
				x=(a+1)*a/2;
				return mat.sa[x+b];
			}
            else
			    return mat.sa[mat.num-1];
		}
		break;
	case 3:
		{
			if(a<=b)
			{
				x=(2*mat.n-a+1)*a/2;
				return mat.sa[x+b-a];
			}
			else
			{
				x=(2*mat.n-b+1)*b/2;
				return mat.sa[x+a-b];
			}
		}
		break;
	case 4:
		{
			if(b<=a+mat.x/2&&b>=a-mat.x/2)
			{
			    if(a<mat.x/2)
				{
			        x=(a-1+2*(mat.x/2+1))*a/2;
					return mat.sa[x+b];
				}
			    else if(a<(mat.n-mat.x/2))
				{
				    x=a*mat.x-(mat.x/2+1)*(mat.x/2)/2;
					return mat.sa[x+b-a+mat.x/2];
				}
				else 
				{
					x=a*mat.x-(mat.x/2+1)*(mat.x/2)/2-(a+mat.x/2-mat.n+1)*(a+mat.x/2-mat.n)/2;
				    return mat.sa[x+b-a+mat.x/2];
				}
			}
			else
			    return 0;
		}
		break;
	case 5:
		{
			if(a==b)
				return 1;
			else return 0;
		}
		break;
	}
	return 0;
}

void Matrix_Add(Matrix mat1,Matrix mat2)   //矩阵加法
{
	int i,j;
	if(mat1.n!=mat2.n)
		printf("运算不可行！\n\n");
	else
	{
        printf("相加后为:\n\n");
		for(i=0;i<mat1.n;i++)
		{
			for(j=0;j<mat1.n;j++)
			{
				printf("%.2f\t",Mat(mat1,i,j)+Mat(mat2,i,j));
			}
			printf("\n\n");
		}
	}

}

void Matrix_Minus(Matrix mat1,Matrix mat2)  //矩阵减法
{
	int i,j;
	if(mat1.n!=mat2.n)
		printf("运算不可行！\n\n");
	else
	{
		printf("相减后为:\n\n");
		for(i=0;i<mat1.n;i++)
		{
			for(j=0;j<mat1.n;j++)
			{
				printf("%.2f\t",Mat(mat1,i,j)-Mat(mat2,i,j));
			}
			printf("\n\n");
		}
	}
}

void Matrix_Ride(Matrix mat1,Matrix mat2)  //矩阵乘法
{
	int i,j,k;
	float a;
	if(mat1.n!=mat2.n)
		printf("运算不可行！\n\n");
	else
	{
		printf("相乘后为:\n\n");
		for(i=0;i<mat1.n;i++)
		{
			for(j=0;j<mat1.n;j++)
			{
				a=0;
				for(k=0;k<mat1.n;k++)
				{
					a=a+Mat(mat1,i,k)*Mat(mat2,k,j);
				}
				printf("%.2f\t",a);
			}
			printf("\n\n");
		}
	}
}

void Matrix_Transpose(Matrix mat)   //矩阵转置
{
	int i,j;
	printf("转置后为:\n\n");
	for(i=0;i<mat.n;i++)
	{
		for(j=0;j<mat.n;j++)
			printf("%.2f\t",Mat(mat,j,i));
		printf("\n\n");
	}

}

float** Algebraic_Complement(float **matrix,int x,int y,int n)  //求矩阵matrix在x行y列的代数余子阵
{
    float **mat;
	int a,b,i,j;
	mat=(float**)malloc((n-1)*sizeof(float*));
	for(i=0;i<n-1;i++)
		mat[i]=(float*)malloc((n-1)*sizeof(float));   //定义新矩阵mat，使其行列数为n-1
	a=0;
	for(i=0;i<n;i++)   //使矩阵mat等于矩阵元素matirx[x][y]的余子阵
	{
		if(i!=x)
		{
		    b=0;
		    for(j=0;j<n;j++)
			{
			    if(j!=y)
				{
		           mat[a][b++]=matrix[i][j];
				}
			}
			a++;
		}
	}
	return mat;
}

float Matrix_Det(float **matrix,int n)   //矩阵行列式
{ 
	float **mat;
	int k;
	float x;       //矩阵的行列式值
	if(n==2)                                                           
		return matrix[0][0]*matrix[1][1]-matrix[0][1]*matrix[1][0];  //矩阵行列数为2时直接返回行列式值
	if(n==1)
		return matrix[0][0];
	x=0;
	for(k=0;k<n;k++)
	{
		mat=Algebraic_Complement(matrix,0,k,n);      //使mat为矩阵在0行k列的代数余子阵
		if(k%2==0)                                   //每次循环使x加上或减去当前矩阵元素与其代数余子式的积
		    x=x+matrix[0][k]*Matrix_Det(mat,n-1);    //循环结束x即为当前矩阵的行列式值
		else
			x=x-matrix[0][k]*Matrix_Det(mat,n-1);
	}
	for(k=0;k<n-1;k++)
	    free(mat[k]);
	free(mat);
	return x;   //返回当次执行程序后求得的行列式值
}

void Matrix_Inverse(float **matrix,int n)   //矩阵的逆
{
	float **mat;
	int i,j,k;
	float a,b;
	a=Matrix_Det(matrix,n);            //求矩阵matrix的行列式
	if(a==0)
	{
		printf("该矩阵没有逆!\n\n");
		return;
	}
	printf("逆矩阵为：\n");
    for(i=0;i<n;i++)
	{
		for(j=0;j<n;j++)
		{
			mat=Algebraic_Complement(matrix,j,i,n);   //求矩阵在j行i列的余子式
			b=Matrix_Det(mat,n-1);                    //
			if((i+j)%2==1)
				b=0-b;
			printf("%f\t",b/a);  //输出矩阵matrix的逆矩阵mat
			for(k=0;k<n-1;k++)
	            free(mat[k]);
	        free(mat);
		}
		printf("\n\n");
	}
}

void Matrix_Calculation(float **matrix1,float **matrix2,Matrix mat1,Matrix mat2)
{
	int a;
	while(1)
	{
        printf("请选择想要执行的操作\n");
        printf("1：矩阵相加\n");
        printf("2：矩阵相减\n");
        printf("3：矩阵相乘\n");
        printf("4：矩阵1的逆\n");
        printf("5：矩阵2的逆\n");
	    printf("6：矩阵1的转置\n");
        printf("7：矩阵2的转置\n");
        printf("8：矩阵1的行列式\n");
        printf("9：矩阵2的行列式\n");
	    printf("10：退出运算\n\n");
	    scanf("%d",&a);
		if(a==10) break;
	    switch(a){
	    case 1:Matrix_Add(mat1,mat2);break;
	    case 2:Matrix_Minus(mat1,mat2);break;
	    case 3:Matrix_Ride(mat1,mat2);break;
	    case 4:Matrix_Inverse(matrix1,mat1.n);break;
	    case 5:Matrix_Inverse(matrix2,mat2.n);break;
 	    case 6:Matrix_Transpose(mat1);break;
	    case 7:Matrix_Transpose(mat2);break;
	    case 8:printf("结果为%.2f\n\n",Matrix_Det(matrix1,mat1.n));break;
	    case 9:printf("结果为%.2f\n\n",Matrix_Det(matrix2,mat2.n));break;
	    default:printf("操作错误，请重新输入\n");Matrix_Calculation(matrix1,matrix2,mat1,mat2);return;
		}
	}
}

int main()
{
	float **matrix1,**matrix2;   //存储矩阵的二维数组指针
    Matrix mat1,mat2;          //压缩矩阵1和2
    Import_Mat(&mat1,1);
	printf("矩阵1为:\n");
	matrix1=Uncompress(mat1);
	Print_Mat(matrix1,mat1.n);
    Import_Mat(&mat2,2);
	printf("矩阵2为:\n");
	matrix2=Uncompress(mat2);
	Print_Mat(matrix2,mat2.n);
    Matrix_Calculation(matrix1,matrix2,mat1,mat2);
}
