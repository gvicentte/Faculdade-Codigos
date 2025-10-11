package br.model;

public class LancheCombo {
    private long id;
    private String nome;
    private String descricao;
    private float valorUnitario;
    private int qtdUnidade;
    private float subTotal;

    public LancheCombo() {
    }

    public LancheCombo(long id, String nome, String descricao, float valorUnitario, int qtdUnidade) {
        this.id = id;
        this.nome = nome;
        this.descricao = descricao;
        this.valorUnitario = valorUnitario;
        this.qtdUnidade = qtdUnidade;
        this.subTotal = valorUnitario * qtdUnidade;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getDescricao() {
        return descricao;
    }

    public void setDescricao(String descricao) {
        this.descricao = descricao;
    }

    public float getValorUnitario() {
        return valorUnitario;
    }

    public void setValorUnitario(float valorUnitario) {
        this.valorUnitario = valorUnitario;
    }

    public int getQtdUnidade() {
        return qtdUnidade;
    }

    public void setQtdUnidade(int qtdUnidade) {
        this.qtdUnidade = qtdUnidade;
    }

    public float getSubTotal() {
        return subTotal;
    }
}
