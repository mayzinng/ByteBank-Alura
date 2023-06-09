﻿using ByteBank.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Contas
{
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; private set; }
        private int agencia;
        
        public int Agencia
        {
            get { return agencia; }
            private set 
            { 
                if(value > 0)
                {
                    this.agencia = value;
                }
            }
        }

        public string Conta { get; set; }

        public  Cliente Titular { get; set; }

        private double saldo;

        public void Depositar(double valor)
        {
            this.saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor <= this.saldo)
            {
                this.saldo -= valor;
                return true; ;
            }
            else
            {
                return false;
            }
            
        }

        public bool Transferir(double valor, ContaCorrente destino)
        {
            if(this.saldo < valor)
            {
                return false;
            }
            else
            {
                this.Sacar(valor);
                destino.Depositar(valor);
                return true;
            }
        }

        public void SetSaldo(double valor)
        {
            if (valor < 0 )
            {
                return;
            }
            else
            {
                this.saldo = valor;
            }
        }

        public double GetSaldo()
        {
            return this.saldo;
        }

        public ContaCorrente(int agencia, string conta)
        {
            this.agencia = agencia;
            this.Conta = conta;
            TotalDeContasCriadas++;
        }
    }

}
