#include "Aluno.h"
#include "HashTable.h"
#define TABLE_SIZE 5
#define MAX_NOME 100

int main()
{
    Aluno dados[TABLE_SIZE];
    HashTable ht;
    initHashTable(&ht,TABLE_SIZE);
    for(int i=0;i<TABLE_SIZE;i++){
        char nome[MAX_NOME];
        long int mat;
        printf("Digite o nome %d: ",i);
        scanf("%s",nome);
        printf("Digite a matricula %d: ",i);
        scanf("%ld",&mat);
        setAluno(&dados[i],mat,nome);
    }
    for(int i=0;i<TABLE_SIZE;i++)
        insertItem(&ht,&dados[i]);
    Aluno aluno;
    setAluno(&aluno,2014,"Jose");
    insertItem(&ht,&aluno);
    displayHashTable(&ht);
    printf("\n");
    deleteItem(&ht,&aluno);
    displayHashTable(&ht);
    printf("\n");
    deleteHash(&ht);
    displayHashTable(&ht);
    return 0;
}