#include <stdio.h>

int recursivo(int x,int y){
    if(x>=y && x%y==0){
        return y;
    }
    else if(x<y){
        return recursivo(y,x);
    }
    else{
        return recursivo(y,x%y);
    }
}

int main()
{
    int a=5;
    int i=recursivo(192,270);
    printf("%d",i);
    return 0;
}
