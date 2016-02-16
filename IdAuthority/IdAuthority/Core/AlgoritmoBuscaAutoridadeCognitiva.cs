using System.Collections.Generic;
using System.Linq;

namespace IdAuthority.Core
{
    public class AlgoritmoBuscaAutoridadeCognitiva
    {
        public List<Amigos> BuscarAutoridadeCognitiva(List<Amigos> amigos, string palavraChave1, string palavraChave2, string palavraChave3)
        {
            var autoridadesCognitivas = new List<Amigos>();
            foreach (var amigo in amigos) //para cada amigo
            {
                foreach (var post in amigo.Posts) // Para cada Post
                {
                    if (post.Conteudo.Contains(palavraChave1)) // Verificar se o post tem as palavras-chave
                        autoridadesCognitivas.Add(amigo); // Caso tenha, Adiciona o amigo na lista de autoridades cognitivas
                    if (post.Conteudo.Contains(palavraChave2) && !(autoridadesCognitivas.Contains(amigo)))
                        autoridadesCognitivas.Add(amigo);
                    if (post.Conteudo.Contains(palavraChave3) && !(autoridadesCognitivas.Contains(amigo)))
                        autoridadesCognitivas.Add(amigo);
                }
            }

            autoridadesCognitivas = OdernarListaDeAmigosPorExpertise(autoridadesCognitivas); // Ordenar a lista de amigos por especialidade.

            return autoridadesCognitivas;
        }

        private List<Amigos> OdernarListaDeAmigosPorExpertise(List<Amigos> amigos)
        {
            amigos = amigos.OrderBy(x => x.Historia).ToList();
            amigos = amigos.OrderBy(x => x.Biologia).ToList();
            amigos = amigos.OrderBy(x => x.Cinema).ToList();
            amigos = amigos.OrderBy(x => x.Filosofia).ToList();
            amigos = amigos.OrderBy(x => x.Fisica).ToList();
            amigos = amigos.OrderBy(x => x.Geografia).ToList();
            amigos = amigos.OrderBy(x => x.Gramatica).ToList();
            amigos = amigos.OrderBy(x => x.Literatura).ToList();
            amigos = amigos.OrderBy(x => x.Matematica).ToList();
            amigos = amigos.OrderBy(x => x.Musica).ToList();
            amigos = amigos.OrderBy(x => x.Politica).ToList();
            amigos = amigos.OrderBy(x => x.Quimica).ToList();
            amigos = amigos.OrderBy(x => x.Sociologia).ToList();
            return amigos;
        }
    }
}