# 💳 Sistema Bancário em C#

Projeto desenvolvido para fins educacionais no **SENAI CIMATEC**, com o objetivo de aplicar conceitos de **Programação Orientada a Objetos (POO)**, **estruturação de sistemas**, **segurança de dados** e **manipulação de arquivos** utilizando **C# em ambiente de console (CMD)**.

---

# 📚 Sobre o Projeto

O **Sistema Bancário** simula o funcionamento básico de um banco, permitindo a criação e gerenciamento de contas bancárias através de um terminal.

O projeto foi desenvolvido para praticar conceitos como:

* Programação Orientada a Objetos
* Encapsulamento e herança
* Estruturação de serviços
* Persistência de dados em arquivos
* Segurança básica de dados
* Organização de código em camadas

O sistema permite que usuários criem contas, realizem operações bancárias e consultem suas informações de forma simples e segura.

---

# 🏦 Tipos de Conta

O sistema possui diferentes tipos de contas, cada uma com comportamentos específicos.

### Conta Corrente

* Permite depósitos e saques
* Possui **taxa aplicada em cada saque**
* Indicada para movimentações frequentes

### Conta Poupança

* Não possui taxa de saque
* Permite **aplicação de rendimento sobre o saldo**
* Indicada para guardar dinheiro

### Conta Empresarial

* Permite operações bancárias padrão
* Possui **limite extra para empréstimos**
* Voltada para uso empresarial

---

# ⚙️ Funcionalidades do Sistema

O sistema possui diversas funcionalidades para simular um ambiente bancário:

### 👤 Usuário

* Criar conta bancária
* Login no sistema
* Consultar saldo
* Realizar depósitos
* Realizar saques
* Aplicar rendimento (poupança)
* Solicitar empréstimo (empresarial)
* Visualizar dados da conta

### 🔐 Segurança

* Sistema de criptografia de dados
* Armazenamento protegido de informações
* Validação de acesso por login

### 🛠️ Administração (Modo Admin)

O sistema possui um modo administrativo que permite:

* Visualizar contas cadastradas
* Gerenciar dados das contas
* Monitorar operações do sistema
* Auxiliar na manutenção e controle do sistema

---

# 🗂️ Estrutura do Projeto

O projeto foi estruturado de forma organizada para facilitar manutenção e expansão:

```
📦 Sistema-Bancario
 ┣ 📂 dados
 ┃ ┗ contas.txt
 ┣ 📂 services
 ┃ ┗ BancoService.cs
 ┣ 📂 models
 ┃ ┣ ContaBancaria.cs
 ┃ ┣ ContaCorrente.cs
 ┃ ┣ ContaPoupanca.cs
 ┃ ┗ ContaEmpresarial.cs
 ┣ Program.cs
 ┗ README.md
```

---

# 💾 Armazenamento de Dados

Os dados das contas são armazenados em **arquivos locais**, permitindo persistência das informações mesmo após o encerramento do programa.

O sistema utiliza técnicas de **criptografia básica** para dificultar o acesso direto aos dados armazenados.

---

# 🧠 Conceitos Aplicados

Durante o desenvolvimento do projeto foram utilizados conceitos importantes da programação:

* Programação Orientada a Objetos (POO)
* Herança
* Encapsulamento
* Manipulação de arquivos
* Criptografia de dados
* Estruturação de serviços
* Organização de código

---

# 🖥️ Tecnologias Utilizadas

* **C#**
* **.NET**
* **Console Application**
* Manipulação de arquivos (`System.IO`)
* Criptografia (`System.Security.Cryptography`)

---

# 🎯 Objetivo Educacional

O principal objetivo deste projeto é **consolidar conhecimentos de programação**, permitindo que o desenvolvedor compreenda como estruturar um sistema real, mesmo que em versão simplificada.

Além disso, o projeto incentiva boas práticas como:

* Organização de código
* Clareza na lógica
* Segurança básica
* Estrutura modular

---

# 👨‍💻 Autor

Projeto desenvolvido por **Hyper Zim**
Aluno do **SENAI CIMATEC**

---

# 📌 Observação

Este projeto foi desenvolvido **exclusivamente para fins educacionais**, não devendo ser utilizado em ambientes bancários reais.

---
