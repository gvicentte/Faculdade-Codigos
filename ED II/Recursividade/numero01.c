#include <stdio.h>

void recursivo(int n){
    if(n==0){
        printf("%d ",n);
    }
    else{
        recursivo(n-1);
        printf("%d ",n);
    }
}

int main()
{
    int a=10;
    recursivo(a);
    return 0;
}
