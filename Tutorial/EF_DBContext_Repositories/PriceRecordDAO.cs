﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tutorial.EF_DBContext;
using Tutorial.MyClasses;

namespace Tutorial.EF_DBContext_Repositories
{
    public class PriceRecordDAO : IDao
    {
        public enum PriceRecordFields { lookupCode, priceBands}

        private appDBContext db;
        public PriceRecordDAO(appDBContext db)
        {
            this.db = db;
        }

        public PriceRecord addPriceRecord(PriceRecord priceRecord) {
            PriceRecord addedPriceRecord = db.PriceRecords.Add(priceRecord);
            db.SaveChanges();
            return addedPriceRecord;
        }

        public int addPriceRecordList(List<PriceRecord> priceRecords)
        {
            int addedPriceRecords = 0;
            foreach (PriceRecord priceRecord in priceRecords)
            {
                if (addPriceRecord(priceRecord) != null)
                {
                    addedPriceRecords++;
                }
            }
            return addedPriceRecords;
        }

        public List<PriceRecord> getAllEntries()
        {
            return db.PriceRecords.ToList();
        }

        public PriceRecord getPriceRecordByLookupCode(String lookupCode)
        {
            var query = from v in db.PriceRecords
                        orderby v.LookupCode
                        select v;

            foreach (PriceRecord priceRecord in query)
            {
                if (priceRecord.LookupCode.Equals(lookupCode))
                {
                    return priceRecord;
                }
            }
            return null;
        }

        public Boolean deletePriceRecordByLookupCode(string lookupCode) {


            PriceRecord priceRecord = getPriceRecordByLookupCode(lookupCode);
            Boolean deleted = priceRecord.Equals(db.PriceRecords.Remove(priceRecord));
            // Boolean deleted = priceRecord.Equals(db.PriceRecords.Remove((PriceRecord)db.PriceRecords.Where(p => p.LookupCode == lookupCode)));
            db.SaveChanges();
            return deleted;
        }

        public Boolean updateLookupCode(string lookupCode, string newLookupCode) {
            PriceRecord priceRecord = getPriceRecordByLookupCode(lookupCode);

            priceRecord.LookupCode = newLookupCode.ToString();
            db.SaveChanges();
            if (priceRecord.LookupCode.Equals(newLookupCode)){
                return true;
            }
            return false;
        }

        public Boolean updatePriceBands(string lookupCode, List<PriceBand> updatedPriceBands)
        {
            PriceRecord priceRecord = getPriceRecordByLookupCode(lookupCode);
            priceRecord.PriceBands = updatedPriceBands;
            db.SaveChanges();
            if (priceRecord.PriceBands.Count == updatedPriceBands.Count)
            {
                return true;
            }
            return false;
        }


        public bool dbIsEmpty()
        {
            return getAllEntries().Count == 0;
        }

        public bool deleteAllEntries()
        {
            Boolean deleted = (getAllEntries().Count == db.PriceRecords.RemoveRange(getAllEntries()).ToList<PriceRecord>().Count);
            db.SaveChanges();
            return deleted;
        }
    }
}