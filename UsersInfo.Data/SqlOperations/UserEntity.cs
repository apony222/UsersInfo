using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersInfo.Core;

namespace UsersInfo.Data.SqlOperations
{
    public class UserEntity : IDataHelper<User>
    {
        DBContext db;
        public UserEntity()
        {
            db = new DBContext();
        }
        public async Task AddAsync(User table)
        {
            await db.Users.AddAsync(table);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var Item = await db.Users.FindAsync(Id);
            db.Users.Remove(Item);
            await db.SaveChangesAsync();
        }

        public async Task<User> FindAsync(int Id)
        {
            return await db.Users.FindAsync(Id);
        }

        public async Task<List<User>> getAllAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<List<User>> SearchAsync(string Item)
        {
           return await db.Users.Where
                (
               x=>x.Id.ToString().Equals(Item) 
               ||x.FullName.Contains(Item)
               || x.Email.Contains(Item)
               || x.PhoneNumber.Contains(Item)
               ).ToListAsync();
        }

        public async Task UpdateAsync(User table)
        {
            db.Users.Update(table);
            await db.SaveChangesAsync();
        }
    }
}
