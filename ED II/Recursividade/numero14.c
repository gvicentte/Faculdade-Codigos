#include <stdio.h>

int recursivo(int n,int k){
    if(n==1){
        return k;
    }
    else{
        return k+recursivo(n-1,k);
    }
}

int main()
{
    int n=0;
    int k=0;
    printf("Digite o numero n: ");
    scanf("%d",&n);
    printf("Digite o numero k: ");
    scanf("%d",&k);
    printf("O resultado de %d X %d e: %d",n,k,recursivo(n,k));
    return 0;
}
