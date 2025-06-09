# 🧙‍♂️ Masmorra

Feito por Kauê Santos da Silva & Yasmim de Castro Ribeiro

## 🗡️ Sobre

**Masmorra** é um programa que simula o sistema de combate dos livros-jogos da série *Fighting Fantasy* (lançados no Brasil pela Jambô Editora). O jogador percorre uma masmorra enfrentando uma série de criaturas em batalhas baseadas em dados, habilidade e sorte.

## 🎮 Como funciona

* O herói tem os seguintes atributos gerados aleatoriamente:

  * **Habilidade:** 1d6 + 6
  * **Sorte:** 2d6 + 12
  * **Energia:** 1d6 + 6

* Cada criatura inimiga possui **habilidade** e **energia** fixas. Não usam sorte.

### Combate

* A cada rodada:

  * Ambos (herói e inimigo) somam 2d6 à sua habilidade para calcular a força de ataque.
  * O que obtiver menor força de ataque perde **2 pontos de energia**.
  * Em caso de empate, nenhum dos dois sofre dano.

### Teste de Sorte

* O jogador pode testar sua sorte em cada rodada para modificar o dano:

  * Se o teste for **bem-sucedido** (2d6 ≤ sorte atual):

    * Causa **4 de dano** (se atacando) ou recebe apenas **1 de dano** (se defendendo).
  * Se o teste for **mal-sucedido**:

    * Causa apenas **1 de dano** ou recebe **3 de dano**.
  * Cada teste de sorte consome **1 ponto de sorte**.

### Inimigos

O jogador enfrentará, em sequência, os seguintes inimigos **sem recuperar energia ou sorte** entre os combates:

| Criatura           | Habilidade | Energia |
| ------------------ | ---------- | ------- |
| Lobo Cinzento      | 3          | 3       |
| Lobo Branco        | 3          | 3       |
| Goblin             | 5          | 4       |
| Orc Vesgo          | 5          | 5       |
| Orc Barbudo        | 5          | 5       |
| Zumbi Manco        | 6          | 7       |
| Zumbi Balofo       | 6          | 7       |
| Troll              | 8          | 7       |
| Ogro               | 8          | 9       |
| Ogro Furioso       | 10         | 9       |
| Necromante Maligno | 12         | 12      |

O jogo termina com a **vitória** do jogador ao derrotar todos os inimigos, ou com a **derrota** se sua energia chegar a 0.

---

## ⚙️ Como executar

### Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/) instalado (versão compatível com seu sistema operacional)

### Instruções

1. Extraia o conteúdo do arquivo de download.
2. Acesse a pasta do projeto pelo terminal ou explorador de arquivos.

### Linux

```bash
dotnet Masmorra.dll
```

### Windows

```bash
dotnet Masmorra.dll
```

Ou, se disponível, execute diretamente o arquivo:

```bash
Masmorra.exe
```

---

## 📦 Download

Acesse o programa através do seguinte [link](download/Masmorra.zip)

---
