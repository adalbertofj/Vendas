using SalesWebMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _context;
        public DepartmentService(SalesWebMVCContext context)
        {
            _context = context;

        }

        // Operação Syncrona (mais lento)
        //public List<Department> FindAll() 
        //{
        //    return _context.Department.OrderBy(x => x.Name).ToList();

        //}

        // Operação Assincrona
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();

        }


    }
}
