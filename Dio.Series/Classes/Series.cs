using System;
using Dio.Series.Enum;

namespace Dio.Series.Classes
{
    public class Series : BaseEntity
    {
        private Category Category { get; set; }
        public string Title { get; private set; }
        private string Description { get; set; }
        private int Year { get; set; }
        public bool Deleted { get; set; }

        public Series(int id, Category category, string title, string description, int year)
        {
            Category = category;
            Title = title;
            Description = description;
            Year = year;
            Id = id;
            Deleted = false;
        }
        
        public override string ToString()
        {
            return  $"Gênero: {Category + Environment.NewLine}" +
                    $"Titulo: {Title + Environment.NewLine}" +
                    $"Descrição: {Description + Environment.NewLine}" +
                    $"Ano de inicio: {Year + Environment.NewLine}" +
                    $"Excluído: {(Deleted ? "Sim":"Não")}";
        }
    }
}