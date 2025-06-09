Console.Clear();

Heroi heroi = new(
    habilidade: RolarDado(1, 6),
    energia: RolarDado(1, 6),
    sorte: RolarDado(2, 12)
);

Console.WriteLine("================================== FIGHTING FANTASY - MASMORRA ==================================");
Console.WriteLine("Bem-Vindo Herói!\n");
heroi.MostrarStatus();
Console.WriteLine(new string('=', 97));

Console.WriteLine("Aperte qualquer tecla para começar...");
Console.ReadKey(true);

Criatura[] criaturas =
[
    new("Lobo Cinzento", 3, 3),
    new("Lobo Branco", 3, 3),
    new("Goblin", 5, 4),
    new("Orc Vesgo", 5, 5),
    new("Orc Barbudo", 5, 5),
    new("Zumbi Manco", 6, 7),
    new("Zumbi Balofo", 6, 7),
    new("Troll", 8, 7),
    new("Ogro", 8, 9),
    new("Ogro Furioso", 10, 9),
    new("Necromante Maligno", 12, 12)
];

for (int i = 0; i < criaturas.Length; i++)
{
    Thread.Sleep(1000);
    if (heroi.Energia <= 0)
    {
        FimDeJogo();
        break;
    }
    Console.WriteLine(new string('=', 97));
    Console.WriteLine($"\n ⚔️  {i + 1}-Rodada ⚔️");
    Combater(heroi, criaturas[i]);
    Thread.Sleep(1000);
}

if (heroi.Energia > 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n🎉 Você completou a masmorra! Parabéns!!! 🎉");
    Console.ResetColor();
    Console.ReadKey(true);
}

static void Combater(Heroi heroi, Criatura criatura)
{
    while (heroi.Energia > 0 && criatura.Energia > 0)
    {
        int ataqueHeroi = heroi.Habilidade + RolarDado(2, 6);
        int ataqueInimigo = criatura.Habilidade + RolarDado(2, 6);

        Console.WriteLine($"\n👑 Herói ataca com força: {ataqueHeroi} pontos");
        Console.WriteLine($"🤖 {criatura.Nome} ataca com força: {ataqueInimigo} pontos");

        Console.WriteLine($"Heroi: {heroi.Energia} ❤️  | Inimigo: {criatura.Energia} 💙");
        if (ataqueHeroi > ataqueInimigo)
        {
            if (Confirmar("✅ Você acertou o inimigo! Deseja testar sua sorte para aumentar o dano causado?"))
            {
                int testeSorte = RolarDado(2, 6);
                Console.WriteLine($"Teste de sorte: {testeSorte} (Sorte atual: {heroi.Sorte})\n");

                if (testeSorte <= heroi.Sorte)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Você foi sortudo! Causou 4 de dano. 🗡️");
                    Console.ResetColor();
                    criatura.Energia -= 4;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Você foi azarado! Causou apenas 1 de dano. 🗡️");
                    Console.ResetColor();
                    criatura.Energia -= 1;
                }
                heroi.Sorte--;
            }
            else
            {
                criatura.Energia -= 2;
            }
        }
        else if (ataqueInimigo > ataqueHeroi)
        {
            if (Confirmar("❌ Você não acertou o inimigo! Deseja testar sua sorte para reduzir o dano sofrido?"))
            {
                int testeSorte = RolarDado(2, 6);
                Console.WriteLine($"\nTeste de sorte: {testeSorte} (Sorte atual: {heroi.Sorte})\n");

                if (testeSorte <= heroi.Sorte)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Você foi sortudo! Sofreu apenas 1 de dano. 🛡️");
                    Console.ResetColor();
                    heroi.Energia -= 1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Você foi azarado! Sofreu 3 de dano. 🛡️🗡️");
                    Console.ResetColor();
                    heroi.Energia -= 3;
                }
                heroi.Sorte--;
            }
            else
            {
                heroi.Energia -= 2;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nEmpate! Ninguém causa dano.");
            Console.ResetColor();
        }
    }
    if (heroi.Energia > 0 && criatura.Energia <= 0)
    {
        Console.WriteLine(new string('-', 97));
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"✅ Você derrotou {criatura.Nome}!");
        Console.ResetColor();
        Console.WriteLine(new string('-', 97));
    }
}

static void FimDeJogo()
{
    Console.WriteLine(new string('=', 97));
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n ☠️  Sua energia acabou... FIM DE JOGO!!! ☠️\n");
    Console.ResetColor();
    Console.WriteLine(new string('=', 97));
    Console.ReadKey(true);
}

static bool Confirmar(string pergunta)
{
    while (true)
    {
        Console.Write($"\n{pergunta} (S/N): ");
        string resposta = Console.ReadLine()!.Trim().ToUpper();
        if (resposta == "S" || resposta == "SIM")
            return true;
        else if (resposta == "N" || resposta == "NAO" || resposta == "NÃO")
            return false;
        Console.WriteLine("Por favor, responda com 'S' ou 'N'.");
    }
}

static int RolarDado(int quantidade, int bonus)
{
    Random random = new();
    int total = 0;
    for (int i = 0; i < quantidade; i++)
    {
        total += random.Next(1, 7);
    }
    return total + bonus;
}

class Heroi(int habilidade, int energia, int sorte)
{
    public int Habilidade { get; set; } = habilidade;
    public int Energia { get; set; } = energia;
    public int Sorte { get; set; } = sorte;

    public void MostrarStatus()
    {
        Console.WriteLine($"Habilidade: {Habilidade} 🗡️  | Energia: {Energia} ❤️");
        return;
    }
}
class Criatura(string nome, int habilidade, int energia)
{
    public string Nome = nome;
    public int Habilidade = habilidade;
    public int Energia = energia;
    public void MostrarStatus()
    {
        Console.WriteLine($"Nome: {Nome} | Habilidade: {Habilidade} | Energia: {Energia}");
        return;
    }
}