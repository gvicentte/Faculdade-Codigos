#ifndef TREE_H
#define TREE_H
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "Queue.h"

typedef struct Nodes{
    int data;
    struct Nodes *left, *right;
} Nodes;

typedef struct{
    Nodes *raiz;
} Tree;

// constrói árvore vazia
void constructorTree(Tree *a){
    a->raiz = NULL;
}

// cria um nó novo
Nodes* createNode(int t){
    Nodes *p = (Nodes *) malloc(sizeof(Nodes));
    p->data = t;
    p->left = NULL;
    p->right = NULL;
    return p;
}

// insere nó na BST
void insertNode(Tree *a, int t){
    Nodes *new = createNode(t);
    if(a->raiz == NULL){
        a->raiz = new;
    }
    else{
        Nodes *iterator = a->raiz;
        Nodes *prev = NULL;
        while(iterator != NULL){
            prev = iterator;
            if(t < iterator->data){
                iterator = iterator->left;
            } 
            else{
                iterator = iterator->right;
            }
        }
        if(t < prev->data){
            prev->left = new;
        } 
        else{
            prev->right = new;
        }
    }
}

// libera memória da árvore
void freeTree(Nodes *node){
    if (node == NULL) return;
    freeTree(node->left);
    freeTree(node->right);
    free(node);
}

// busca valor na árvore
bool verifyItem(Nodes *node, int t){
    if(node == NULL){
        return false;
    }
    if(node->data == t){
        return true;
    }
    if(t < node->data){
        return verifyItem(node->left, t);
    } else {
        return verifyItem(node->right, t);
    }
}

// menor valor da árvore
int getMin(Nodes *node){
    if(node == NULL){
        printf("Tree is empty\n");
        return -1;
    }
    Nodes *iterator = node;
    while(iterator->left != NULL){
        iterator = iterator->left;
    }
    return iterator->data;
}

// maior valor da árvore
int getMax(Nodes *node){
    if(node == NULL){
        printf("Tree is empty\n");
        return -1;
    }
    Nodes *iterator = node;
    while(iterator->right != NULL){
        iterator = iterator->right;
    }
    return iterator->data;
}

// busca em largura (BFS)
void breadthSearch(Tree *a){
    if(a->raiz == NULL){
        printf("Tree is empty\n");
        return;
    }
    Queue *q = (Queue *) malloc(sizeof(Queue));
    constructor(q);
    pushTail(a->raiz, q);  // coloca raiz na fila
    while(!isEmpty(q)){
        Nodes *current = popHead(q);  // pega próximo nó
        printf("%d ", current->data); // processa
        if(current->left != NULL)  pushTail(current->left, q);
        if(current->right != NULL) pushTail(current->right, q);
    }
    free(q);
}

#endif // TREE_H