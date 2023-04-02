using CursoCSharp.OO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

////  HERENÇA:
//Up - Herança, sobrescrevendo e ocultando método.	
//Sobrescrever um método: Sobrescreve o método em qlqr novo objeto instânciado, mantendo o novo valor ou função do método para esta determinada classe.
//	operadores -> override, abstrat, virtual

//Ocultar um método: atribui apenas ao obejto instânciado, não sendo replicado para todos os outros objetos, pois foi alterado apenas 'nesta' instância e não em todos as outras, a novas instâncias voltam a receber o valor do método principal (PAI).
//	operador(opcional) - new

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
        public virtual int Acelerar() { // corrigindo o erro Error CS0506, para alterar o metodo Acelerar na class Ferrari
            return AlterarVelocidade(5); // acrescenta 5
        }

        // Método Frear
        public int Frear() {
            return AlterarVelocidade(-5);// subtrai 5
        }
    }

    public class Uno : Carro { // Uno HERDA os atribuitos de CARRO, por isso se utiliza os ' : ' (dois pontos)
        public Uno() : base(150) { //Construtor base, declaração do parametro para o contrutor herado
                       // construtor base obrigatório por não ter construtor padrão declarado.
        }
    }

    public class Ferrari : Carro {
        public Ferrari() : base(350) {

        }

        public override int Acelerar() { // o operador 'override' trabalha em conjunto com o 'virtual' p Sobrescrevendo um metodo Acelerar da classe pai
            return AlterarVelocidade(15);
        }

        public new int Frear() => AlterarVelocidade(-15); // o operador 'new' permite ocultar o método da classe Pai
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

            Console.WriteLine("Ferrari com tipo Carro de variavel...");
            Carro carro3 = new Ferrari(); // Class Carro mais generica
            Console.WriteLine(carro3.Acelerar());
            Console.WriteLine(carro3.Acelerar());
            Console.WriteLine(carro3.Frear());
            Console.WriteLine(carro3.Frear());
            Console.WriteLine(carro3.Frear());

            Console.WriteLine("Uno com tipo Carro de variavel...");
            carro3 = new Uno(); // Polimorfismo
            Console.WriteLine(carro3.Acelerar());
            Console.WriteLine(carro3.Acelerar());
            Console.WriteLine(carro3.Frear());
            Console.WriteLine(carro3.Frear());
            Console.WriteLine(carro3.Frear());

        }
    }
}
