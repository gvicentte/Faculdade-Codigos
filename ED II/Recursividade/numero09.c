#include <stdio.h>

void recursivo(int x){
    if(x%10!=0){
        printf("%d",x%10);
        recursivo(x/10);
    }
}

int main()
{
    int a=5;
    recursivo(192);
    return 0;
}
