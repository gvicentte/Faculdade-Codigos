#include <stdio.h>

int recursivo(int k,int n){
    if(n==0){
        return 1;
    }
    else{
        return k*recursivo(k,n-1);
    }
}

int main()
{
    int k=0;
    int n=0;
    printf("Digite o numero k: ");
    scanf("%d",&k);
    printf("Digite o numero n: ");
    scanf("%d",&n);
    printf("O resultado e: %d",recursivo(k,n));
    return 0;
}
