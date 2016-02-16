using System.Collections.Generic;
using IdAuthority.Core;
using NUnit.Framework;

namespace IdAuthority.Tests
{
    [TestFixture]
    public class AlgoritmoBuscaTest
    {

        public Amigos Amigo1 { get; set; }
        public Amigos Amigo2 { get; set; }
        public Amigos Amigo3 { get; set; }
        public Post PostAmigo1 { get; set; }
        public Post PostAmigo2 { get; set; }
        public Post PostAmigo3 { get; set; }


        [SetUp]
        public void InicializarTeste()
        {
            #region Amigo1
            PostAmigo1 = new Post
            {
                Conteudo = "Segunda Guerra Mundial"
            };
            var postsAmigo1 = new List<Post>();
            postsAmigo1.Add(PostAmigo1);
            Amigo1 = new Amigos
            {
                Historia = true,
                Posts = postsAmigo1,
                Geografia = false
            };
            #endregion

            #region Amigo2
            PostAmigo2 = new Post
            {
                Conteudo = "Geografia da Pangeia no Início do Mundo"
            };
            var postsAmigo2 = new List<Post>();
            postsAmigo2.Add(PostAmigo2);
            Amigo2 = new Amigos
            {
                Historia = false,
                Posts = postsAmigo2,
                Geografia = true
            };
            #endregion

            #region Amigo3
            PostAmigo3 = new Post
            {
                Conteudo = "Primeira Guerra Mundial"
            };
            var postsAmigo3 = new List<Post>();
            postsAmigo3.Add(PostAmigo3);
            Amigo3 = new Amigos
            {
                Historia = false,
                Posts = postsAmigo3,
                Geografia = true
            };
            #endregion

        }

        [Test]
        public void Deve_Retornar_O_Amigo_De_Historia_Primeiro()
        {
            var listaDeAmigos = new List<Amigos>();
            listaDeAmigos.Add(Amigo1);
            listaDeAmigos.Add(Amigo2);
            var algoritmo = new AlgoritmoBuscaAutoridadeCognitiva();
            var resultado = algoritmo.BuscarAutoridadeCognitiva(listaDeAmigos, "Segunda", "Guerra", "Mundial");

            Assert.AreEqual(resultado[0].Historia, true);
            Assert.AreEqual(resultado[0].Geografia, false);
            Assert.AreEqual(resultado[0].Posts[0].Conteudo, PostAmigo1.Conteudo);
        }


        [Test]
        public void Deve_Retornar_O_Amigo_De_Geografia_Primeiro()
        {
            var listaDeAmigos = new List<Amigos>();
            listaDeAmigos.Add(Amigo1);
            listaDeAmigos.Add(Amigo2);
            var algoritmo = new AlgoritmoBuscaAutoridadeCognitiva();
            var resultado = algoritmo.BuscarAutoridadeCognitiva(listaDeAmigos, "Geografia", "Pangeia", "Início");

            Assert.AreEqual(resultado[0].Historia, false);
            Assert.AreEqual(resultado[0].Geografia, true);
            Assert.AreEqual(resultado[0].Posts[0].Conteudo, PostAmigo2.Conteudo);
        }

        [Test]
        public void Deve_Ordenar_Os_Amigos()
        {
            var listaDeAmigos = new List<Amigos>();
            listaDeAmigos.Add(Amigo1);
            listaDeAmigos.Add(Amigo2);
            listaDeAmigos.Add(Amigo3);
            var algoritmo = new AlgoritmoBuscaAutoridadeCognitiva();
            var resultado = algoritmo.BuscarAutoridadeCognitiva(listaDeAmigos, "Segunda", "Guerra", "Mundial");


            Assert.AreEqual(resultado[0].Historia, true);
            Assert.AreEqual(resultado[0].Geografia, false);
            Assert.AreEqual(resultado[0].Posts[0].Conteudo, PostAmigo1.Conteudo);

            Assert.AreEqual(resultado[1].Historia, false);
            Assert.AreEqual(resultado[1].Geografia, true);
            Assert.AreEqual(resultado[1].Posts[0].Conteudo, PostAmigo3.Conteudo);

        }
    }
}

