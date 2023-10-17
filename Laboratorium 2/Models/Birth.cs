using Laboratorium_2.Controllers;
using Microsoft.AspNetCore.Components.Forms;

namespace Laboratorium_2.Models
{
    public class Birth
    {
        public string? imie { get; set; }
        public DateTime? dataUr { get; set; }
        public DateTime? currentDate { get; set; }


        public bool IsValid()
        {
            currentDate = DateTime.Now;
            return imie != null && dataUr != null && dataUr < currentDate;
        }

        public int Years()
        {
            currentDate = DateTime.Now;
            int age = currentDate.Value.Year - dataUr.Value.Year;
            return age;
        }

    }
}
