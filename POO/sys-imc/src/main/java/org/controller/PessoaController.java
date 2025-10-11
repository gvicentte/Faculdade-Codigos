package org.controller;

import javafx.application.Platform;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import org.model.Pessoa;

import java.text.DecimalFormat;

public class PessoaController {

    //Itens do FXML
    Pessoa pessoa = new Pessoa();
    @FXML
    private TextField txtNome;
    @FXML
    private TextField txtIdade;
    @FXML
    private TextField txtAltura;
    @FXML
    private TextField txtPeso;
    @FXML
    private Label lblIMC;
    @FXML
    private Label lblClassificacao;

    //Metodos

    @FXML
    public void lerFormulario(){
        pessoa.setNome(txtNome.getText());
        pessoa.setIdade(Integer.parseInt(txtIdade.getText()));
        pessoa.setAltura(Float.parseFloat(txtAltura.getText()));
        pessoa.setPeso(Float.parseFloat(txtPeso.getText()));
        calcularIMC();
    }

    @FXML
    public void calcularIMC(){
        float imc;
        DecimalFormat df = new DecimalFormat();
        imc = pessoa.getPeso()/(pessoa.getAltura() * pessoa.getAltura());
        df.applyPattern("#0.00");
        lblIMC.setText(df.format(imc));
        df.applyPattern("#0.00");
        if(imc <= 18.50){
            lblClassificacao.setText("Magra");
        } else if (imc > 18.50 && imc <= 24.99) {
            lblClassificacao.setText("Saudável");
        } else if (imc > 24.99 && imc <= 29.99) {
            lblClassificacao.setText("Obesidade I");
        } else if (imc > 29.99 && imc <= 39.99) {
            lblClassificacao.setText("Obesidade II");
        } else if (imc > 39.99) {
            lblClassificacao.setText("Obesidade III");
        }
    }

    @FXML
    public void fecharJanela(){
        System.exit(0);
    }
}
