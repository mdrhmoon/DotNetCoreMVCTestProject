using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreMVCTestProject.Data
{
    public class Repository
    {
        private readonly DbContext context;
        public IDbContextTransaction transaction = null;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        
        public async Task<Boolean> BEGIN_TRANSACTION()
        {
            this.transaction = await this.context.Database.BeginTransactionAsync();
            return true;
        }


        public async Task<Boolean> COMMIT()
        {
            if (this.transaction != null) await this.transaction.CommitAsync();
            return true;
        }


        public async Task<Boolean> ROLL_BACK()
        {
            if (this.transaction != null) await this.transaction.RollbackAsync();
            return true;
        }
    }
}
