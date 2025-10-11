package br.model;

import java.util.List;

public class Pedido {
    private long id;
    private int qtdInteira;
    private int qtdMeia;
    private List<Ingresso> listaIngresso;
    private List<LancheCombo> listaLanche;
    private float valorTotal;

    public Pedido() {
        this.valorTotal=0;
    }

    public Pedido(long id, int qtdInteira, int qtdMeia, List<Ingresso> listaIngresso, List<LancheCombo> listaLanche) {
        this.id = id;
        this.qtdInteira = qtdInteira;
        this.qtdMeia = qtdMeia;
        this.listaIngresso = listaIngresso;
        this.listaLanche = listaLanche;
        float aux=0,subtotalPedido=0;
        for(int i=0;i<listaIngresso.size();i++){
            aux=0;
            Ingresso auxiliar=listaIngresso.get(i);
            aux=auxiliar.getValorInteira()*qtdInteira;
            subtotalPedido+=aux;
            aux=0;
            aux=auxiliar.getValorMeia()*qtdMeia;
            subtotalPedido+=aux;
        }
        for(int i=0;i<listaLanche.size();i++){
            aux=0;
            LancheCombo auxiliar01=listaLanche.get(i);
            aux=auxiliar01.getQtdUnidade()*auxiliar01.getValorUnitario();
            subtotalPedido+=aux;
        }
        this.valorTotal =subtotalPedido;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public int getQtdInteira() {
        return qtdInteira;
    }

    public void setQtdInteira(int qtdInteira) {
        this.qtdInteira = qtdInteira;
    }

    public int getQtdMeia() {
        return qtdMeia;
    }

    public void setQtdMeia(int qtdMeia) {
        this.qtdMeia = qtdMeia;
    }

    public List<Ingresso> getListaIngresso() {
        return listaIngresso;
    }

    public void adicionarIngresso(Ingresso ingresso) {
        this.listaIngresso.add(ingresso);
    }

    public void removerIngresso(long id){
        this.listaIngresso.remove(id);
    }

    public List<LancheCombo> getListaLanche() {
        return listaLanche;
    }

    public void adicionarLanche(LancheCombo lanche) {
        this.listaLanche.add(lanche);
    }

    public void removerLanche(long id){
        this.listaLanche.remove(id);
    }

    public float getValorTotal() {
        return valorTotal;
    }
}
