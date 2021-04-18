using System;
using System.Collections.Generic;
using System.Text;
using ComposicaoObjetos.Entities.Enums;
using System.Collections.Generic;

namespace ComposicaoObjetos.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // aqui é colocado uma lista porque um Worker pode ter varios Contracts

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department) // aqui o Contracts nao tem construtor porque não é usual colocar lista no construtor, associaçao para muitos nao tem construtor
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract); //Adiciona o contrato na lista Contracts usando o .Add
        }
        
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts) // cada contrato que estiver dentro da lista
            {
                if (contract.Date.Year == year && contract.Date.Month == month) // parametros para ele só pegar o que for fornecido pelo usuario
                {
                    sum += contract.TotalValue(); //o Total Value sempre soma tudo que tiver dentro dos parametros fornecidos
                }
            }
            return sum; // retorna o valor que ta na variavel sum = BaseSalary
        }
    }


}
