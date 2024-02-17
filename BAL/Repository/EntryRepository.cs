using BAL.Repositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repository
{
    public class EntryRepository:BaseRepository
    {
        public EntryRepository()
        :base()
        { }

        public EntryRepository(BmsContext ContextBMS)
            :base(ContextBMS)
        {
            DBContext=ContextBMS;
        }
        //byte[] StampByte,
        public IEnumerable<AmStamp> TimeStamp(string? _StampBase64)
        {
            var dbquery = DBContext.AmStamps.Where(x=>x.IsActive==true).ToList();
            return dbquery;
        }


        public AmEntryLog EntryTimeStamp(AmStamp _stamp)
        {
            //AmEntryLog log = new AmEntryLog();
            //log.SUId = _stamp.StdUId;
            //log.Status = true;
            //log.TimeIn=DateTime.Now;
            var EntryStamp = DBContext.AmEntryLogs.Where(x => x.SUId == _stamp.StdUId && x.Status==true).FirstOrDefault();
            if (EntryStamp == null)
            {
                EntryStamp = SetEntryValue(_stamp, true);
                EntryStamp.TimeIn = DateTime.Now;
                DBContext.AmEntryLogs.Add(EntryStamp);
                //DBContext.Entry(EntryStamp).Property(x => x.TimeOut).IsModified = false;
            }
            else 
            {
                EntryStamp = SetEntryValue(_stamp, false);
                EntryStamp.TimeOut = DateTime.Now;
                DBContext.AmEntryLogs.Update(EntryStamp);
                //DBContext.Entry(EntryStamp).Property(x => x.TimeIn).IsModified = false;
            }
            
            DBContext.SaveChanges();
            return EntryStamp;
        }

        public AmEntryLog SetEntryValue(AmStamp _stamp,bool Status)
        {
            AmEntryLog log = new AmEntryLog();
            log.SUId = _stamp.StdUId;
            log.Status = Status;
            
            return log;
        }
    }
}
