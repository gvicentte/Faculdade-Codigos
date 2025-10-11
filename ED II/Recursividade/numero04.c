#include <stdio.h>

int recursividade(int n){
    if(n<=0){
        return 0;
    }
    else if(n==1){
        return 1;
    }
    else{
        return recursividade(n-1)+recursividade(n-2);
    }
}

int main()
{
    int n;
    printf("Digite um valor n: ");
    scanf("%d",&n);
    printf("Fribonacci de %d = %d",n,recursividade(n));
    return 0;
}
