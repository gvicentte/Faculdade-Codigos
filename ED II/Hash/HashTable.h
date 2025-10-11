#ifndef HASHTABLE_H
#define HASHTABLE_H

#include "Aluno.h"

typedef struct  Node{
    Aluno *ptr;
    struct Node *prox;
}Node;

typedef struct{
    int tamanho;
    Node **hash;
}HashTable;

long int hashFunction(long int mat,int TABLE_SIZE){
    return mat % TABLE_SIZE;
}

void initHashTable(HashTable *ht,int tam){
    ht->tamanho = tam;
    ht->hash = (Node**) malloc(tam * sizeof(Node*));
    for(int i=0; i<tam; i++){
        ht->hash[i] = NULL;
    }
}

void insertItem(HashTable *ht,Aluno *aluno){
    long int id=hashFunction(aluno->matricula,ht->tamanho);
    Node *p=(Node*)malloc(sizeof(Node));
    p->ptr=aluno;
    p->prox=ht->hash[id];
    ht->hash[id]=p;
}

void deleteItem(HashTable *ht,Aluno *aluno){
    int id=hashFunction(aluno->matricula,ht->tamanho);
    Node *p=ht->hash[id];
    Node *prev=NULL;
    while(p!=NULL){
        if(p->ptr->matricula==aluno->matricula){
            if(prev==NULL){
                ht->hash[id]=p->prox;    
            }
            else{
                prev->prox=p->prox;
            }
            free(p);
            return;
        }
        prev=p;
        p=p->prox;
    }
}

void displayHashTable(HashTable *ht){
    for(int i=0;i<ht->tamanho;i++){
        printf("[%d]: ",i);
        Node *p=ht->hash[i];
        while(p!=NULL){
            printf("(%ld, %s) -> ",p->ptr->matricula,p->ptr->nome);
            p=p->prox;
        }
        printf("NULL\n");
    }
}

void deleteHash(HashTable *ht){
    for(int i=0;i<ht->tamanho;i++){
        Node *p=ht->hash[i];
        while(p!=NULL){
            Node *aux=p;
            p=p->prox;
            free(aux);
        }
        ht->hash[i]=NULL;
    }
    free(ht->hash);
    ht->hash=NULL;
    ht->tamanho=0;
}


#endif //HASHTABLE_H