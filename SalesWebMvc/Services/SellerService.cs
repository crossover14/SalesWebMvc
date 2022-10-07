using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Diagnostics;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly  SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
              _context.Add(obj);
             await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {

            //return _context.Seller.FirstOrDefault(obj => obj.Id == id); ====> Este só da get no ID o de baixo pega o nome tmb !
            return await _context.Seller.Include(obj => obj.Departament).FirstOrDefaultAsync(obj => obj.Id == id);
            
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                throw new IntegrityException(e.Message);
            }
            

        }
        public async Task UpdateAsync( Seller obj)
        {
            bool HasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if ( !HasAny)
            {
                throw new NotFoundException("Id nao Existe");
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
