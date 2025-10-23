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
    printf("##     5 - Depth Search (In Order)              ##\n");
    printf("##     6 - Depth Search (Pre Order)             ##\n");
    printf("##     7 - Depth Search (Pos Order)             ##\n");
    printf("##     8 - Depth Search (Iterative In Order)    ##\n");
    printf("##     9 - Depth Search (Iterative Pre Order)   ##\n");
    printf("##     10 - Depth Search (Iterative Pos Order)  ##\n");
    printf("##     11 - Exit                                ##\n");
    printf("##################################################\n");
    printf("\n");
}

int main()
{
    int op=0,t;
    Tree *a=(Tree *) malloc(sizeof(Tree));
    constructorTree(a);
    while(op!=11){
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
            depthSearchIn(a->raiz);
            break;
        case 6:
            depthSearchPre(a->raiz);
            break;
        case 7:
            depthSearchPost(a->raiz);
            break;
        case 8:
            depthSearchInIterative(a->raiz);
            break;
        case 9:
            depthSearchPreIterative(a->raiz);
            break;
        case 10:
            depthSearchPostIterative(a->raiz);
            break;
        case 11:
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