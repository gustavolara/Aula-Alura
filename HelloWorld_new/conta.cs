using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld_new
{
    class Conta
    {
        public int numero { get; set; }
        public double Saldo { get; private set; }
        public int agencia;
        public Cliente titular { get; set; }
        public bool Saca(double valorASacar)
        {
            if (valorASacar < 0 || this.Saldo < valorASacar)
            {
                return false;
            }
            else
            {
                if (this.titular.maiorDeIdade())
                {
                    this.Saldo -= valorASacar;
                    return true;
                }
                else
                {
                    if(valorASacar <= 200.0)
                    {
                        this.Saldo -= valorASacar;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public void Deposita(double valorADepositar)
        {
            if (valorADepositar > 0)
            {
                this.Saldo += valorADepositar;
            }
        }
        public void Transfere(double valor, Conta destino)
        {
            this.Saca(valor);
            destino.Deposita(valor);
        }
        public double CalculaRendimentoAnual()
        {
            double saldoNaqueleMes = this.Saldo;
            for (int i = 0; i < 12; i++)
            {
                saldoNaqueleMes = saldoNaqueleMes * 1.007;
            }
            double rendimento = saldoNaqueleMes - this.Saldo;
            return rendimento;
        }
    }
}
