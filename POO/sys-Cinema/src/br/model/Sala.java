package br.model;

public class Sala {
    private long id;
    private int numero;
    private int capacidade;
    private int[][] poutronas;
    private int qtdFilas;
    private int qtdPoutronasFila;

    public Sala() {
        this.poutronas = criarPoutronas();
    }

    public Sala(long id, int numero, int qtdFilas, int qtdPoutronasFila) {
        this.id = id;
        this.numero = numero;
        this.qtdFilas = qtdFilas;
        this.qtdPoutronasFila = qtdPoutronasFila;
        this.poutronas = criarPoutronas();
    }

    public int [][] criarPoutronas(){
        return new int[this.qtdFilas][this.qtdPoutronasFila];
    }

    public int calcularCapacidade(){
        this.capacidade = qtdFilas * qtdPoutronasFila;
        return this.capacidade;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public int getNumero() {
        return numero;
    }

    public void setNumero(int numero) {
        this.numero = numero;
    }

    public int getCapacidade() {
        return capacidade;
    }

    public int[][] getPoutronas() {
        return poutronas;
    }

    public void reservarPoutronas(int fila, int poutronafila) {
        this.poutronas[fila][poutronafila] = 1;
    }

    public int getQtdFilas() {
        return qtdFilas;
    }

    public void setQtdFilas(int qtdFilas) {
        this.qtdFilas = qtdFilas;
    }

    public int getQtdPoutronasFila() {
        return qtdPoutronasFila;
    }

    public void setQtdPoutronasFila(int qtdPoutronasFila) {
        this.qtdPoutronasFila = qtdPoutronasFila;
    }
}
