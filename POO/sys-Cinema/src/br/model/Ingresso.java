package br.model;

public class Ingresso {
    private long id;
    private float valorInteira;
    private float valorMeia;
    private Sessao sessao;

    public Ingresso() {
    }

    public Ingresso(long id, float valorInteira, float valorMeia, Sessao sessao) {
        this.id = id;
        this.valorInteira = valorInteira;
        this.valorMeia = valorMeia;
        this.sessao = sessao;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public float getValorInteira() {
        return valorInteira;
    }

    public void setValorInteira(float valorInteira) {
        this.valorInteira = valorInteira;
    }

    public float getValorMeia() {
        return valorMeia;
    }

    public void setValorMeia(float valorMeia) {
        this.valorMeia = valorMeia;
    }

    public Sessao getSessao() {
        return sessao;
    }

    public void setSessao(Sessao sessao) {
        this.sessao = sessao;
    }
}
