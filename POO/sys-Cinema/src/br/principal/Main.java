package br.principal;
import br.model.*;

import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner cin=new Scanner(System.in);
        int v1=0,v2=0,v3=0;
        while (v1!=2){
            System.out.println("Seja Bem Vindo ao Sistema de Cinema o que deseja fazer?\n");
            System.out.println("0 - Acessar Sistema de Administrador");
            System.out.println("1 - Acessar Sistema de Usuario");
            System.out.println("2 - Sair do Sistema");
            v1= cin.nextInt();
            switch (v1){
                case 0:
                    while (v2!=8) {
                        System.out.println("Bem Vindo ao Sistema de Administrador, o que deseja fazer?!\n");
                        System.out.println("0 - Cadastrar Cinema");
                        System.out.println("1 - Remover Cinema");
                        System.out.println("2 - Cadastrar Sala");
                        System.out.println("3 - Remover Sala");
                        System.out.println("4 - Cadastrar Filme");
                        System.out.println("5 - Remover Filme");
                        System.out.println("6 - Cadastrar Sessao");
                        System.out.println("7 - Remover Sessao");
                        System.out.println("8 - Voltar");
                        v2 = cin.nextInt();
                    }
                    break;
                case 1:
                    while(v3!=12) {
                        System.out.println("Bem Vindo ao Sistema de Usuario!\n");
                        v3= cin.nextInt();
                    }
                    break;
                case 2:
                    System.out.println("Obrigado por usar nosso Sistema, saindo...");
                    break;
                default:
                    System.out.println("Escolha invalida, selecione uma opcao valida!\n");
                    break;
            }
        }
    }
}