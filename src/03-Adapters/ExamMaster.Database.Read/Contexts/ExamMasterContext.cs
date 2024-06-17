using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Database.Read.Contexts
{
    public class ExamMasterContext : DbContext
    {

        private string _userId;
        public ExamMasterContext()
        { }

        public ExamMasterContext(DbContextOptions<ExamMasterContext> options, string userId) : base(options)
        {
            _userId = userId;
        }
    
    }
}
