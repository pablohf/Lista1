using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {

            //Instância da lista que será preenchida
            List<Produto> listaMoodle = new List<Produto>();
            List<Produto> listaTotvs = new List<Produto>();
            List<Produto> lista3 = new List<Produto>();

            //Retorna todas as linhas do arquivo em um array
            //de string, onde cada linha será um índice do array
            string[] arrayMoodle = File.ReadAllLines("C:\\bancoMoodle.csv");
            string[] arrayTotvs = File.ReadAllLines("C:\\bancoTotvs.csv");
            //percorro o array e para cada linha
            for (int i = 0; i < arrayMoodle.Length; i++) { 

                //crio um objeto do tipo Produto
                Produto p = new Produto();

                //Uso o método Split e quebro cada linha
                //em um novo array auxiliar, ou seja, cada
                //conteúdo do arquivo txt separado por ';' será
                //um nova linha neste array auxiliar. Assim sei que
                //cada índice representa uma propriedade
                string[] auxiliar = arrayMoodle[i].Split(';');

                //Aqui recupero os itens, atribuindo
                //os mesmo as propriedade da classe
                //Cliente correspondentes, ou seja,
                //o índice zero será corresponde ao Id
                //o um ao nome e o dois ao e-mail
                p.Username = auxiliar[0];
                p.Senha = auxiliar[1];

                //Adiciono o objeto a lista
                listaMoodle.Add(p);
            }

            for (int i = 0; i < arrayTotvs.Length; i++) {

                //crio um objeto do tipo Produto
                Produto p = new Produto();

                //Uso o método Split e quebro cada linha
                //em um novo array auxiliar, ou seja, cada
                //conteúdo do arquivo txt separado por ';' será
                //um nova linha neste array auxiliar. Assim sei que
                //cada índice representa uma propriedade
                string[] auxiliar = arrayTotvs[i].Split(';');

                //Aqui recupero os itens, atribuindo
                //os mesmo as propriedade da classe
                //Cliente correspondentes, ou seja,
                //o índice zero será corresponde ao Id
                //o um ao nome e o dois ao e-mail
                p.Username = auxiliar[0];
                p.Senha = auxiliar[1];

                //Adiciono o objeto a lista
                listaTotvs.Add(p);
            }

            /*
            // Popula lista1
            lista1.Add(new Produto() { Username = 1, Senha = 123 });
            lista1.Add(new Produto() { Username = 3, Senha = 1235 });
            lista1.Add(new Produto() { Username = 4, Senha = 34 });

            // Popula lista3
            lista2.Add(new Produto() { Username = 1, Senha = 123 });

            // Popula lista3
            foreach (Produto item in lista1) {
                if (!lista2.Contains(item))
                    lista3.Add(item);
            }*/

            // Exibe valores listaMoodle
            /*foreach (var item in listaMoodle) {
                Console.WriteLine(@"User: {0}; Senha: {1}", item.Username, item.Senha);
                Console.WriteLine(@"----------------------------------------------------------");
            }*/

            // Exibe valores listaTotvs
            foreach (var item in listaTotvs) {
                Console.WriteLine(@"User: {0}; Senha: {1}", item.Username, item.Senha);
                Console.WriteLine(@"----------------------------------------------------------");
            }

            //Exibe valores lista3
            //foreach (Produto item in lista3)
            //  Console.WriteLine("Username: " + item.Username + " - Senha: " + item.Senha);

            Console.ReadLine();
        }
    }






    class Produto : IEquatable<Produto> {
        public string Username;
        //public bool Ativo;
        public string Senha;

        public bool Equals(Produto outro) {
            // Pode comparar todas as propriedades da classe se você quiser
            return (this.Username == outro.Username);
        }

        public override bool Equals(Object obj) {
            if (obj == null) return base.Equals(obj);

            if (!(obj is Produto))
                throw new InvalidCastException("The 'obj' argument is not a Produto object.");
            else
                return Equals(obj as Produto);
        }

        public override int GetHashCode() {
            return this.GetHashCode();
        }

        public static bool operator ==(Produto prod1, Produto prod2) {
            return prod1.Equals(prod2);
        }

        public static bool operator !=(Produto prod1, Produto prod2) {
            return (!prod1.Equals(prod2));
        }

    }
}