CREATE TABLE produtos (
    id SERIAL PRIMARY KEY,
    nome TEXT NOT NULL,
    descricao TEXT NULL,
    preco NUMERIC(10,2) NOT NULL,
    quantidade_estoque INT NOT NULL
);

CREATE TABLE pedidos (
    id SERIAL PRIMARY KEY,
    cliente TEXT NOT NULL,
    data_pedido TIMESTAMP NOT NULL DEFAULT NOW(),
    valor_total NUMERIC(10,2) NOT NULL
);

CREATE TABLE itens_pedido (
    id SERIAL PRIMARY KEY,
    pedido_id INT NOT NULL REFERENCES pedidos(id) ON DELETE CASCADE,
    produto_id INT NOT NULL REFERENCES produtos(id) ON DELETE ,
    nome_produto TEXT NOT NULL,
    preco_unitario NUMERIC(10,2) NOT NULL,
    quantidade INT NOT NULL,
    valor_total_item NUMERIC(10,2) NOT NULL
);
