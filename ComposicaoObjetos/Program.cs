using System;
using ComposicaoObjetos.Entities.Enums;
using ComposicaoObjetos.Entities;
using System.Globalization;

namespace ComposicaoObjetos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worder Data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("level (Junior / MidLevel / Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName); //instancia o departamento dentro do Department, ele pega o valor que foi digitado e coloca dentro pela variavel deptNaem
            Worker worker = new Worker(name, level, baseSalary, dept); // aqui tem mais variaveis dentro pq sempre tem que colocar todas que tem la no construtor public Worker

            Console.Write("How many Contracts to this workers: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) // for é apara ele digitar os valores abaixo para o numero de contratos que solicitou
            {
                Console.WriteLine($"Enter with the #{n} contract data: ");
                Console.Write("Date (DD/MM/YYYY):" );
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour:");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours):");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours); // instanciando as informações no construtor HourContract
                worker.AddContract(contract); // colocando essas infos para o Worker informado na lista por isso o AddContract
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2)); // aqui ele usa o substring pra pegar o valor da variavel monthAndYera e cortar só o mes
            int year = int.Parse(monthAndYear.Substring(3));// aqui ele pega o ano
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " +worker.Department.Name);
            Console.WriteLine("Income for" +monthAndYear +": " + worker.Income(year, month));

        }
    }
}
