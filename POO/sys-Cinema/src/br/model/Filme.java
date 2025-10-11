package br.model;

import java.util.Date;
import java.util.List;

public class Filme {
    private long id;
    private String titulo;
    private String sinopse;
    private Classificao classificacao;
    private Date duracao;
    private String elenco;
    private Genero genero;
    private Date dataInicialExibicao;
    private Date dataFinalExibicao;

    public Filme() {
    }

    public Filme(long id, String titulo, String sinopse, Classificao classificacao, Date duracao, String elenco, Genero genero, Date dataInicialExibicao, Date dataFinalExibicao) {
        this.id = id;
        this.titulo = titulo;
        this.sinopse = sinopse;
        this.classificacao = classificacao;
        this.duracao = duracao;
        this.elenco = elenco;
        this.genero = genero;
        this.dataInicialExibicao = dataInicialExibicao;
        this.dataFinalExibicao = dataFinalExibicao;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public String getSinopse() {
        return sinopse;
    }

    public void setSinopse(String sinopse) {
        this.sinopse = sinopse;
    }

    public Classificao getClassificacao() {
        return classificacao;
    }

    public void setClassificacao(Classificao classificacao) {
        this.classificacao = classificacao;
    }

    public Date getDuracao() {
        return duracao;
    }

    public void setDuracao(Date duracao) {
        this.duracao = duracao;
    }

    public String getElenco() {
        return elenco;
    }

    public void setElenco(String elenco) {
        this.elenco = elenco;
    }

    public Genero getGenero() {
        return genero;
    }

    public void setGenero(Genero genero) {
        this.genero = genero;
    }

    public Date getDataInicialExibicao() {
        return dataInicialExibicao;
    }

    public void setDataInicialExibicao(Date dataInicialExibicao) {
        this.dataInicialExibicao = dataInicialExibicao;
    }

    public Date getDataFinalExibicao() {
        return dataFinalExibicao;
    }

    public void setDataFinalExibicao(Date dataFinalExibicao) {
        this.dataFinalExibicao = dataFinalExibicao;
    }
}
