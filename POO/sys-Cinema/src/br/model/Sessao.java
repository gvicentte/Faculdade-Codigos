package br.model;

import java.util.Date;

public class Sessao {
    private long id;
    private Date horarioExibicao;
    private Filme filme;
    private Sala sala;

    public Sessao() {
    }

    public Sessao(long id, Date horarioExibicao, Filme filme, Sala sala) {
        this.id = id;
        this.horarioExibicao = horarioExibicao;
        this.filme = filme;
        this.sala = sala;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public Date getHorarioExibicao() {
        return horarioExibicao;
    }

    public void setHorarioExibicao(Date horarioExibicao) {
        this.horarioExibicao = horarioExibicao;
    }

    public Filme getFilme() {
        return filme;
    }

    public void setFilme(Filme filme) {
        this.filme = filme;
    }

    public Sala getSala() {
        return sala;
    }

    public void setSala(Sala sala) {
        this.sala = sala;
    }
}
