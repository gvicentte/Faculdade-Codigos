#include <stdio.h>

int recursivo(int m,int n){
    if(m==0){
        return n+1;
    }
    else if(m!=0 && n==0){
        return recursivo(m-1,1);
    }
    else{
        return recursivo(m-1,recursivo(m,n-1));
    }
}

int main()
{
    int a=5;
    int i=recursivo(1,3);
    printf("%d",i);
    return 0;
}
