#ifndef STACK_H
#define STACK_H
#include "Tree.h"

struct Nodes;

typedef struct NodeStack
{
    struct Nodes* data;
    struct NodeStack* next;
} NodeStack;


typedef struct Stack {
    int n;
    NodeStack* TOP;
} Stack;

void StackConstructor(Stack* stack) {
    stack->n = 0;
    stack->TOP = NULL;
}

bool isEmptyS(Stack* stack) {
    return stack->n==0;
}

void push(Stack* stack, struct Nodes* value) {
    NodeStack* newNode = (NodeStack*)malloc(sizeof(NodeStack));
    newNode->data = value;
    newNode->next = stack->TOP;
    stack->TOP = newNode;
    stack->n++;
}

struct Nodes* pop(Stack* stack) {
    if (isEmptyS(stack)) {
        printf("Stack is empty\n");
        return NULL; // Indica que a pilha está vazia
    }
    NodeStack* temp = stack->TOP;
    struct Nodes *value = temp->data;
    stack->TOP = stack->TOP->next;
    free(temp);
    stack->n--;
    return value;
}

void freeStack(Stack* stack) {
    while (!isEmptyS(stack)) {
        pop(stack);
    }
}

#endif // STACK_H