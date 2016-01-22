using System.Collections.Generic;

namespace IdAuthority.Core
{
    public class Amigos
    {
        public string Nome { get; set; }
        public List<Post> Posts { get; set; }
        #region Expertises
        public bool Historia { get; set; }
        public bool Geografia { get; set; }
        public bool Biologia { get; set; }
        public bool Sociologia { get; set; }
        public bool Filosofia { get; set; }
        public bool Matematica { get; set; }
        public bool Literatura { get; set; }
        public bool Gramatica { get; set; }
        public bool Fisica { get; set; }
        public bool Quimica { get; set; }
        public bool Politica { get; set; }
        public bool Musica { get; set; }
        public bool Cinema { get; set; } 
        #endregion
    }
}
