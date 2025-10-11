#include <stdio.h>

int recursividade(int n){
    if(n==1){
        return 1;
    }
    else if(n==2){
        return 2;
    }
    else{
        return 2*recursividade(n-1)+3*recursividade(n-2);
    }
}

int main()
{
    int n;
    printf("Digite um valor n: ");
    scanf("%d",&n);
    printf("Gerador de Sequencia de %d = %d",n,recursividade(n));
    return 0;
}
