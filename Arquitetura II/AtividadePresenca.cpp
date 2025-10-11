#include <iostream>
#include <string>
#include <bitset>

using namespace std;

// Funções auxiliares
string int_to_bin(int n, int bits = 8) {
    unsigned int mask = (1u << bits) - 1;
    return bitset<32>(n & mask).to_string().substr(32 - bits);
}

// 1.1 - Sinal e Magnitude
int sinal_magnitude_to_int(const string& bin) {
    int sinal = (bin[0] == '1') ? -1 : 1;
    int magnitude = stoi(bin.substr(1), nullptr, 2);
    return sinal * magnitude;
}

string int_to_sinal_magnitude(int n, int bits = 8) {
    string magnitude = int_to_bin(abs(n), bits - 1);
    return (n < 0 ? "1" : "0") + magnitude;
}

// 1.2 - Complemento de 1
int complemento1_to_int(const string& bin) {
    if (bin[0] == '0') return stoi(bin, nullptr, 2);
    string inv;
    for (char c : bin) inv += (c == '0' ? '1' : '0');
    return -stoi(inv, nullptr, 2);
}

string int_to_complemento1(int n, int bits = 8) {
    if (n >= 0) return int_to_bin(n, bits);
    string pos = int_to_bin(abs(n), bits);
    string inv;
    for (char c : pos) inv += (c == '0' ? '1' : '0');
    return inv;
}

// 1.3 - Complemento de 2
int complemento2_to_int(const string& bin) {
    int n = stoi(bin, nullptr, 2);
    int bits = bin.size();
    if (bin[0] == '1') n -= (1 << bits);
    return n;
}

string int_to_complemento2(int n, int bits = 8) {
    return int_to_bin(n, bits);
}

// 1.4 - Representação Polarizada (Bias)
int polarizado_to_int(const string& bin, int bias = 7) {
    return stoi(bin, nullptr, 2) - bias;
}

string int_to_polarizado(int n, int bits = 8, int bias = 7) {
    return int_to_bin(n + bias, bits);
}

// Função principal de operação
string operar(const string& a, const string& b, string modo, string op, int bits = 8) {
    int a_int, b_int, res;

    if (modo == "sinal") {
        a_int = sinal_magnitude_to_int(a);
        b_int = sinal_magnitude_to_int(b);
    } else if (modo == "c1") {
        a_int = complemento1_to_int(a);
        b_int = complemento1_to_int(b);
    } else if (modo == "c2") {
        a_int = complemento2_to_int(a);
        b_int = complemento2_to_int(b);
    } else if (modo == "polar") {
        a_int = polarizado_to_int(a);
        b_int = polarizado_to_int(b);
    } else {
        throw invalid_argument("Modo inválido");
    }

    if (op == "soma") res = a_int + b_int;
    else if (op == "sub") res = a_int - b_int;
    else if (op == "mult") res = a_int * b_int;
    else if (op == "div") res = (b_int != 0 ? a_int / b_int : 0);
    else throw invalid_argument("Operação inválida");

    if (modo == "sinal") return int_to_sinal_magnitude(res, bits);
    else if (modo == "c1") return int_to_complemento1(res, bits);
    else if (modo == "c2") return int_to_complemento2(res, bits);
    else return int_to_polarizado(res, bits);
}

void testar_operacoes(int x, int y, int bits) {
    string modos[] = {"sinal", "c1", "c2", "polar"};
    string nomes[] = {"Sinal e Magnitude", "Complemento de 1", "Complemento de 2", "Polarizado"};

    cout << "Testando com x = " << x << ", y = " << y << " (em " << bits << " bits)\n\n";

    for (int i = 0; i < 4; i++) {
        string modo = modos[i];
        cout << "=== " << nomes[i] << " ===" << endl;

        string a, b;
        if (modo == "sinal") {
            a = int_to_sinal_magnitude(x, bits);
            b = int_to_sinal_magnitude(y, bits);
        } else if (modo == "c1") {
            a = int_to_complemento1(x, bits);
            b = int_to_complemento1(y, bits);
        } else if (modo == "c2") {
            a = int_to_complemento2(x, bits);
            b = int_to_complemento2(y, bits);
        } else {
            a = int_to_polarizado(x, bits);
            b = int_to_polarizado(y, bits);
        }

        cout << "A = " << a << "  B = " << b << endl;
        cout << "Soma: " << operar(a, b, modo, "soma", bits) << endl;
        cout << "Subtracao: " << operar(a, b, modo, "sub", bits) << endl;
        cout << "Multiplicacao: " << operar(a, b, modo, "mult", bits) << endl;
        cout << "Divisao: " << operar(a, b, modo, "div", bits) << endl;
        cout << endl;
    }
}

int main() {
    int a,b,bits;
    cout << "Digite a quantidade de Bits: ";
    cin>>bits;
    cout<<endl;
    cout<<"Digite o Primeiro Numero(Numero Inteiro o programa converte para Binario): ";
    cin>>a;
    cout<<endl;
    cout<<"Digite o Segundo Numero(Numero Inteiro o programa converte para Binario): ";
    cin>>b;
    cout<<endl;
    testar_operacoes(a,b,bits);
    return 0;
}
