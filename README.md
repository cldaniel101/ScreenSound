# ScreenSound 🎵

ScreenSound é uma aplicação de console construída em C# que funciona como um sistema para gerenciar uma biblioteca de artistas e suas músicas. O projeto utiliza o Entity Framework Core para persistir os dados em um banco de dados SQL Server.

## ✨ Funcionalidades

* **Registrar Artistas:** Adicione novos artistas à sua coleção.
* **Registrar Músicas:** Adicione músicas e associe-as a um artista existente.
* **Listar Artistas:** Veja todos os artistas cadastrados no sistema.
* **Exibir Discografia:** Consulte todas as músicas de um artista específico.
* **Filtrar Músicas por Ano:** Encontre todas as músicas lançadas em um determinado ano.

## 🛠️ Tecnologias Utilizadas

* **[C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)**
* **[.NET 7](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0)** (compatível com .NET 8 ou superior)
* **[Entity Framework Core](https://learn.microsoft.com/pt-br/ef/core/)**: Para o mapeamento objeto-relacional (ORM).
* **[SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)**: Banco de dados utilizado para armazenar os dados.

## 🚀 Como Executar o Projeto

Siga os passos abaixo para configurar e rodar a aplicação localmente.

### **Pré-requisitos**

* [.NET 7.0 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/7.0) ou superior.
* Uma instância do SQL Server (a aplicação está configurada para usar o **LocalDB**, que geralmente é instalado com o Visual Studio).

### **Passos**

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/cldaniel101/ScreenSound.git
    ```

2.  **Navegue até a pasta do projeto:**
    ```bash
    cd ScreenSound
    ```

3.  **Instale as ferramentas do Entity Framework Core (se ainda não tiver):**
    ```bash
    dotnet tool install --global dotnet-ef
    ```

4.  **Restaure as dependências do projeto:**
    ```bash
    dotnet restore
    ```

5.  **Crie o banco de dados e aplique as Migrations:**
    O comando abaixo irá criar o banco `ScreenSoundV0` e todas as tabelas necessárias no seu LocalDB.
    ```bash
    dotnet ef database update
    ```

6.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```

Após o último comando, o menu principal do ScreenSound aparecerá no seu terminal e você poderá interagir com a aplicação.
