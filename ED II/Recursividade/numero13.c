#include <stdio.h>

int recursivo(int n){
    if(n<=2){
        return 1;
    }
    /*else if(n==2){
        return 1;
    }*/
    else{
        return recursivo(n-2)+recursivo(n-3);
    }
}

int main()
{
    int n=0;
    printf("Digite o numero n: ");
    scanf("%d",&n);
    printf("O resultado e: %d",recursivo(n));
    return 0;
}
