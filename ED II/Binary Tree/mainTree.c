#include "Tree.h"
#include "Queue.h"

void imprimirTela(){
    printf("\n");
    printf("##################################################\n");
    printf("##                                              ##\n");
    printf("##        [Selecione uma opercao]               ##\n");
    printf("##                                              ##\n");
    printf("##     1 - Insert Node                          ##\n");
    printf("##     2 - Breadth Search (Busca em largura)    ##\n");
    printf("##     3 - Verify Item                          ##\n");
    printf("##     4 - Get MIN / MAX                        ##\n");
    printf("##     5 - Exit                                 ##\n");
    printf("##                                              ##\n");
    printf("##                                              ##\n");
    printf("##################################################\n");
    printf("\n");
}

int main()
{
    int op=0,t;
    Tree *a=(Tree *) malloc(sizeof(Tree));
    constructorTree(a);
    while(op!=5){
        imprimirTela();
        scanf("%d", &op);
        switch (op)
        {
        case 1:
            printf("Type the value to insert: ");
            scanf("%d", &t);
            insertNode(a, t);
            break;
        case 2:
            printf("Breadth Search: ");
            breadthSearch(a);
            printf("\n");
            break;
        case 3:
            printf("Type the value to verify: ");
            scanf("%d", &t);
            if(verifyItem(a->raiz, t)){
                printf("Item %d is in the tree\n", t);
            }
            else{
                printf("Item %d is not in the tree\n", t);
            }
            break;
        case 4:
            if(a->raiz==NULL){
                printf("Tree is empty\n");
            }
            else{
                printf("Min: %d\n", getMin(a->raiz));
                printf("Max: %d\n", getMax(a->raiz));
            }
            break;
        case 5:
            printf("Exiting...\n");
            break;
        default:
            printf("Invalid option. Please try again.\n");
            break;
        }
    }
    free(a);
    return 0;
}