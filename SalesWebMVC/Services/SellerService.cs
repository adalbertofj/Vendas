using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;
        public SellerService(SalesWebMVCContext context)
        {
            _context = context;

        }

        //Operação Syncrona
        //public List<Seller> FindAll()
        //{
        //    return _context.Seller.ToList();
        //}

        //operação assyncrona
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        //Operação syncrona
        //public void Insert(Seller obj) 
        //{
        //    _context.Add(obj);
        //    _context.SaveChanges();
        //}

        //Operação Asyncrona
        public async Task Insert(Seller obj) 
        {
            _context.Add(obj);
           await _context.SaveChangesAsync();
        }

        // operação syncrona
        //public Seller FindById(int id)
        //{
        //    return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        //}

        //Operação Asyncrona
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }


        // operação syncrona
        //public void Remove(int id) 
        //{
        //    var obj =_context.Seller.Find(id);
        //    _context.Seller.Remove(obj);
        //    _context.SaveChanges();

        //}
        
        // operação asyncrona
        public async Task RemoveAsync(int id) 
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
           await _context.SaveChangesAsync();

        }

        //operacao assincrona
        //public void update(Seller obj)
        //{
        //    if (!_context.Seller.Any(x => x.Id == obj.Id))
        //    {
        //        throw new NotFoundException("Id not found");
        //    }
        //    try
        //    {
        //        _context.Update(obj);
        //        _context.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException e)
        //    {
        //        throw new DbConcurrencyException(e.Message);
        //    }

        //}


        //operacao sincrona
        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado!");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
