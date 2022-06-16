using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="{0} Campo obrigatório")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="{0} o tamanho do nome deve ser entre 3 e 60 caracteres")]
        public string Name { get; set; }
        
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [Required(ErrorMessage = "{0} Campo obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "{0} Campo obrigatório")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        
        [Display (Name= "Base Salary")]
        [DisplayFormat(DataFormatString="{0:F2}")]
        [Required(ErrorMessage = "{0} Campo obrigatório")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} O salário deve ser entre {1} to {2}")]
        public double BaseSalary { get; set; }
        public Department Department {get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSaes(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public Double TotalSales(DateTime initial, DateTime final)

        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
