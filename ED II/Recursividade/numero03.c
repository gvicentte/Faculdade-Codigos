#include <stdio.h>

int recursivo(int n){
    if(n==1){
        return 1;
    }
    else{
        return n*recursivo(n-1);
    }
}

int main()
{
    int a=5;
    int i=recursivo(a);
    printf("%d",i);
    return 0;
}
