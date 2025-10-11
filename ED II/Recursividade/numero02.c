#include <stdio.h>

void recursivo(int n){
    if(n==0){
        printf("%d ",n);
    }
    else{
        printf("%d ",n);
        recursivo(n-1);
    }
}

int main()
{
    int a=10;
    recursivo(a);
    return 0;
}
