#include <stdio.h>


float recursividade(float n){
    if(n==0){
        return 0;
    }
    else{
        return recursividade(n-1)+1/n;
    }
}

int main()
{
    float n;
    printf("Digite um valor n: ");
    scanf("%f",&n);
    printf("Gerador de Sequencia de %.0f = %.3f",n,recursividade(n));
    return 0;
}
