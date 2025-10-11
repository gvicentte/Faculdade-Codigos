#include <stdio.h>

int recursivo(int *vetor,int n){
    n=n-1;
    if(n==0){
        return vetor[0];
    }
    else{
        return vetor[n]+recursivo(vetor,n);
    }
}

int main()
{
    int a[10]={5,10,50,20,30,40,80,10,1,30};
    printf("%d",recursivo(a,10));
    return 0;
}
