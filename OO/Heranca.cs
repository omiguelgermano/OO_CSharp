using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp.OO {

    public class Carro {
        protected readonly int VelocidadeMaxima; // Use o modificador readonly para declarar que
                                                 // um tipo de estrutura é imutável.
        int VelocidadeAtual;

        // Construtor
        public Carro(int velocidadeMaxima) {
            VelocidadeMaxima = velocidadeMaxima;
        }

        protected int AlterarVelocidade(int delta) {
            int novaVelocidade = VelocidadeAtual + delta;// na variavel novaVelocidade, será feito alguns testes de validação para qua a velocidade não seja negativa.

            if (novaVelocidade < 0) {
                VelocidadeAtual = 0; // se a novaVelocidade for menor q Zero, a variavel recebe o valor de 0. não permitindo que velocidade seja menor q zero.
            } else if (novaVelocidade > VelocidadeMaxima) {
                VelocidadeAtual = VelocidadeMaxima; // determina um limite maximo da velocidade
            } else {
                VelocidadeAtual = novaVelocidade; // atribui velocidade conforme expressão na função.
            }
            return VelocidadeAtual;// O método AlterarVelocidade vai apresentar erro se não tiver nenhum return.
        }

        // Método Acelerar 
        public int Acelerar() {
            return AlterarVelocidade(5); // acrescenta 5
        }

        // Método Frear
        public int Frear() {
            return AlterarVelocidade(-5);// subtrai 5
        }
    }

    public class Uno : Carro { // Uno HERDA os atribuitos de CARRO, por isso se utiliza os ' : ' (dois pontos)
        public Uno() : base(150) { //Construtor base, declaração do parametro para o contrutor herado

        }
    }

    public class Ferrari : Carro {
        public Ferrari() : base(350) {

        }
    }

    internal class Heranca {
        public static void Executar() {// declarada no Main
            Console.WriteLine("HERENÇA!");

            Console.WriteLine("Uno...");
            Uno carro1 = new Uno();
            Console.WriteLine(carro1.Acelerar());
            Console.WriteLine(carro1.Acelerar());
            Console.WriteLine(carro1.Acelerar());
            Console.WriteLine(carro1.Acelerar());
            Console.WriteLine("Frear...");
            Console.WriteLine(carro1.Frear());
            Console.WriteLine(carro1.Frear());
            Console.WriteLine();

            Console.WriteLine("Ferrari...");
            Ferrari carro2 = new Ferrari();
            Console.WriteLine(carro2.Acelerar());
            Console.WriteLine(carro2.Acelerar());
            Console.WriteLine(carro2.Acelerar());
            Console.WriteLine("FREAR...");
            Console.WriteLine(carro2.Frear());
            Console.WriteLine(carro2.Frear());
        }
    }
}
