#ifndef ALUNO_H
#define ALUNO_H
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct{
    long int matricula;
    char nome[100];
}Aluno;

void setAluno(Aluno *a,long int mat,const char *nome){
    a->matricula=mat;
    strcpy(a->nome,nome);
}

#endif // ALUNO_H