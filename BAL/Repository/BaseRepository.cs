using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repositories
{
    public class BaseRepository
    {

        public BmsContext DBContext;
        public BaseRepository() 
        {
            DBContext = new BmsContext();   
        }
        public BaseRepository(BmsContext ContextDB)
        { 
            DBContext=ContextDB;
        }

        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }
        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing) 
        {
            if(disposing) 
            {
                if (DBContext != null)
                { 
                    DBContext.Dispose();
                    DBContext = null;
                }
            }    
        }
        ~BaseRepository() 
        {
            Dispose(false);
        }
    }
}
