using System;
using Dio.Series.Enum;
using Dio.Series.Classes;
using System.Collections.Generic;

namespace Dio.Series.Classes
{
    class Program
    {
        private static SerieRepository serieRepository = new SerieRepository();
        private static int categoryInput, yearInput;
        private static string titleInput, descriptionInput;

        static void Main(string[] args)
        {
            string UserOption = GetUserOption();

            while (UserOption.ToUpper() != "X")
            {
                switch (UserOption)
                    {
                    case "1":
                        GetSeriesList();
                        break;
                    case "2":
                        AddSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        PrintSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção incorreta! Por favor, tente novamente.");
                        break;
                }
                UserOption = GetUserOption();
            }

        }

        private static void DeleteSeries()
        {
            Console.Write("Digite o ID da série: ");
            int serieId = int.Parse(Console.ReadLine());
        }

        private static void PrintSeries()
        {
            Console.Write("Digite o ID da série: ");
            int serieId = int.Parse(Console.ReadLine());
            Series serie = serieRepository.GetById(serieId);
            Console.WriteLine(serie);
        }

        private static void UpdateSeries()
        {
            Console.Write("Digite o ID da série: ");
            int serieId = int.Parse(Console.ReadLine());

            //Preenche os valores de entrada da série
            GetInputValues();

            Series UpdatedSerie = new Series(id: serieId,
                                       category: (Category)categoryInput,
                                       title: titleInput,
                                       year: yearInput,
                                       description: descriptionInput);
            serieRepository.Update(serieId, UpdatedSerie);
        }

        private static void GetInputValues()
        {
            foreach (int i in System.Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine($"{i}-{System.Enum.GetName(typeof(Category), i)}");
            }

            Console.WriteLine();
            Console.Write("Digite o gênero entre as opções acima: ");
            categoryInput = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome da série: ");
            titleInput = Console.ReadLine();
            Console.Write("Digite o ano de lançamento da série: ");
            yearInput = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            descriptionInput = Console.ReadLine();
        }

        private static void AddSeries()
        {
            Console.WriteLine("Inserir nova série");
            
            //Preenche os valores de entrada da série
            GetInputValues();

            Series newSerie = new Series(id: serieRepository.NextId(),
                                       category: (Category)categoryInput,
                                       title: titleInput,
                                       year: yearInput,
                                       description: descriptionInput);
            serieRepository.Add(newSerie);                                       
        }

        private static void GetSeriesList()
        {
            Console.WriteLine("Listar séries");
            List<Series> list = serieRepository.list();

            if (list.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (Series serie in list)
            {
                Console.WriteLine($"#ID {serie.Id}: - {serie.Title} {(serie.Deleted ? "- *Excluido*":"")}");
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Vizualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            return Console.ReadLine().ToUpper();
        }
    }
}
