package br.model;

import java.util.List;

public class Cinema {
    private long id;
    private String nome;
    private String endereco;
    private List<Sala> listaSalas;
    private List<Sessao> listaSessoes;
    private List<Filme> listaFilmes;

    public Cinema() {
    }

    public Cinema(long id, String nome, String endereco, List<Sala> listaSalas, List<Sessao> listaSessoes, List<Filme> listaFilmes) {
        this.id = id;
        this.nome = nome;
        this.endereco = endereco;
        this.listaSalas = listaSalas;
        this.listaSessoes = listaSessoes;
        this.listaFilmes = listaFilmes;
    }

    public void cadastrarSala(Sala sala){
        this.listaSalas.add(sala);
    }

    public void removerSala(long id){
        this.listaSalas.remove(id);
    }

    public void cadastrarSessao(Sessao sessao){
        this.listaSessoes.add(sessao);
    }

    public void removerSessao(long id){
        this.listaSessoes.remove(id);
    }

    public void cadastrarFilme(Filme filme){
        this.listaFilmes.add(filme);
    }

    public void removerFilme(long id){
        this.listaFilmes.remove(id);
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

    public String getEndereco() {
        return endereco;
    }

    public void setEndereco(String endereco) {
        this.endereco = endereco;
    }

    public List<Sala> getListaSalas() {
        return listaSalas;
    }

    public List<Sessao> getListaSessoes() {
        return listaSessoes;
    }

    public List<Filme> getListaFilmes() {
        return listaFilmes;
    }
}
