namespace BolinhasApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxGrupos = 0;
            var bolas = new List<int> { 1, 1, 1, 1, 2, 1, 1, 1, 1 }; 
            var totalDeBolas = bolas.Count;

            // Determina o número máximo de grupos possíveis
            for (int i = 2; i <= totalDeBolas; i++)
            {
                if (totalDeBolas % i == 0)
                {
                    maxGrupos = i;
                }
            }

            // Divide as bolas em grupos
            var grupos = CriarGrupos(bolas, maxGrupos);

            // Encontra o grupo com bola diferente usando recursividade
            int grupoComPesoDiferente = LocalizarGrupo(grupos, 0, grupos.Count - 1);

            // Exibe o resultado
            if (grupoComPesoDiferente != -1)
            {
                Console.WriteLine($"A bolinha mais pesada está no grupo {grupoComPesoDiferente + 1}");
            }
            else
            {
                Console.WriteLine("Erro: grupo não identificado.");
            }
        }

        // Função para criar grupos de bolas
        static List<List<int>> CriarGrupos(List<int> bolas, int qtdGrupos)
        {
            if (qtdGrupos > bolas.Count)
            {
                qtdGrupos = bolas.Count;
            }

            var tamGrupo = bolas.Count / qtdGrupos;
            var grupos = new List<List<int>>();

            // Distribui as bolas nos grupos
            for (int i = 0; i < qtdGrupos; i++)
            {
                var grupo = new List<int>();

                for (int j = 0; j < tamGrupo; j++)
                {
                    grupo.Add(bolas[i * tamGrupo + j]);
                }

                grupos.Add(grupo);
            }

            // Se houver sobra, distribui as bolas restantes
            int sobra = bolas.Count % qtdGrupos;
            if (sobra > 0)
            {
                grupos[grupos.Count - 1].AddRange(bolas.Skip(qtdGrupos * tamGrupo));
            }

            return grupos;
        }

        // Função recursiva para encontrar o grupo com peso diferente
        static int LocalizarGrupo(List<List<int>> grupos, int inicio, int fim)
        {
            if (inicio == fim)
            {
                return inicio;
            }

            // Compara os grupos nas posições de início e fim
            int comparacao = Comparar(grupos[inicio], grupos[fim]);

            if (comparacao == 0)
            {
                return LocalizarGrupo(grupos, inicio + 1, fim - 1);
            }
            else if (comparacao > 0)
            {
                return LocalizarGrupo(grupos, inicio, fim - 1);
            }
            else
            {
                return LocalizarGrupo(grupos, inicio + 1, fim);
            }
        }

        // Função para comparar a soma dos pesos dos grupos
        static int Comparar(List<int> grupo1, List<int> grupo2)
        {
            var peso1 = grupo1.Sum();
            var peso2 = grupo2.Sum();

            return peso1.CompareTo(peso2);
        }
    }
}