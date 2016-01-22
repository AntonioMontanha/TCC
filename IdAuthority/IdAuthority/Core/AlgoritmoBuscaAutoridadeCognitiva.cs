using System.Collections.Generic;

namespace IdAuthority.Core
{
    public class AlgoritmoBuscaAutoridadeCognitiva
    {
        public List<Amigos> BuscarAutoridadeCognitiva(List<Amigos> amigos, string palavraChave1, string palavraChave2, string palavraChave3)
        {
            var autoridadesCognitivas = new List<Amigos>();
            foreach (var amigo in amigos)
            {
                foreach (var post in amigo.Posts)
                {
                    // Pesquisar aqui se o post tem alguma das palavras chave
                    //Se tiver, deve adicionar o cara na lista de autoridades cognitivas.
                    autoridadesCognitivas.Add(amigo);
                }
            }

            //Com a lista preenchida, deve ordenar pela expertise

            return autoridadesCognitivas;
        }
    }
}
