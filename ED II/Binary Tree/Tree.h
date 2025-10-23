#ifndef TREE_H
#define TREE_H
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "Queue.h"
#include "Stack.h"
#include <stdbool.h>

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
    deleteQueue(q);
    //free(q);
}

void depthSearchPreIterative(Nodes *root) {
    //pre - do topo para tudo esquerda depois direita
    if (root == NULL) return;
    Stack stack;
    StackConstructor(&stack);
    push(&stack, root); //xuxo a raiz na pilha
    while (!isEmptyS(&stack)) {
        Nodes* current = pop(&stack); //pego o topo e retorno o valor
        printf("%d ", current->data);
        // Push right child first so that left child is processed first
        if (current->right != NULL) {
            push(&stack, current->right);
        }
        if (current->left != NULL) {
            push(&stack, current->left);
        }
    }
    freeStack(&stack);
}

void depthSearchInIterative(Nodes *root) {
    if (root == NULL) return;
    Stack stack;
    StackConstructor(&stack);
    Nodes* current = root;

    while (current != NULL || !isEmptyS(&stack)) {
        while (current != NULL) {
            push(&stack, current);
            current = current->left;
        }

        current = pop(&stack);
        printf("%d ", current->data);
        current = current->right;
    }

    freeStack(&stack);
}


void depthSearchPostIterative(Nodes *root) {
    //post - tudo esquerda, tudo direita, do topo processa
    if (root == NULL) return;

    Stack stack1, stack2;
    StackConstructor(&stack1);
    StackConstructor(&stack2);
    push(&stack1, root);

    while (!isEmptyS(&stack1)) {
        Nodes* current = pop(&stack1);
        push(&stack2, current);

        if (current->left != NULL) {
            push(&stack1, current->left);
        }
        if (current->right != NULL) {
            push(&stack1, current->right);
        }
    }

    while (!isEmptyS(&stack2)) {
        Nodes* node = pop(&stack2);
        printf("%d ", node->data);
    }

    freeStack(&stack1);
    freeStack(&stack2);
}

void depthSearchPre(Nodes *node){
    if(node == NULL) return;
    printf("%d ", node->data);
    depthSearchPre(node->left);
    depthSearchPre(node->right);
}

void depthSearchIn(Nodes *node){
    if(node == NULL) return;
    depthSearchIn(node->left);
    printf("%d ", node->data);
    depthSearchIn(node->right);
}

void depthSearchPost(Nodes *node){
    if(node == NULL) return;
    depthSearchPost(node->left);
    depthSearchPost(node->right);
    printf("%d ", node->data);
}

#endif // TREE_H