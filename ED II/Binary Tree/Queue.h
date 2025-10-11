#ifndef QUEUE_H
#define QUEUE_H
#include <stdbool.h>
#include <stdlib.h>
#include <stdio.h>

// forward declaration (avisa ao compilador que existe struct Nodes)
struct Nodes;

// Nó da fila
typedef struct Node{
    struct Nodes *data;   // cada elemento da fila aponta para um nó da árvore
    struct Node *next;
} Node;

// Estrutura da fila
typedef struct{
    int n;
    Node *head;
    Node *tail;
} Queue;

// verifica se a fila está vazia
bool isEmpty(Queue *a){
    return a->n == 0;
}

// inicializa fila
void constructor(Queue *a){
    a->n = 0;
    a->head = NULL;
    a->tail = NULL;
}

// insere no final da fila
void pushTail(struct Nodes *t, Queue *a){
    Node *p = (Node *)malloc(sizeof(Node));
    p->data = t;
    p->next = NULL;
    if(a->tail){
        a->tail->next = p;
    } 
    else{
        a->head = p;
    }
    a->tail = p;
    a->n++;
}

// remove do início da fila e retorna o nó
struct Nodes* popHead(Queue *a){
    if(a->head == NULL) return NULL;
    Node *p = a->head;
    struct Nodes *value = p->data;
    a->head = a->head->next;
    if(a->head == NULL) a->tail = NULL;
    free(p);
    a->n--;
    return value;
}

#endif // QUEUE_H