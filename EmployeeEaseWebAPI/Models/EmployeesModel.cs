using EmployeesEaseWebAPI.Enums;
using EmployeesEaseWebAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace EmployeesEaseWebAPI.Models
{
    public class EmployeesModel
    {
        #region Properties

        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DepartureEnum Departure { get; set; }
        public bool Actived { get; set; }
        public ShiiftWorkEnum ShiftWork { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime UpdateDate { get; set; } = DateTime.Now.ToLocalTime();
       
        #endregion

    }
}
