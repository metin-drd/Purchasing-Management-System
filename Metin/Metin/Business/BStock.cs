using Metin.Command;
using Metin.Data;
using Metin.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Metin.Business
{
    public class BStock : BaseBusiness
    {
        DStock dStock = new DStock();

        public bool Insert(CStock StockData)
        {
            ReturnValue = dStock.Insert(StockData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CStock StockData)
        {
            return dStock.Update(StockData);
        }

        public bool Delete(CStock StockData)
        {
            return dStock.Delete(StockData);
        }

        public DataTable Browse(CStock StockData)
        {
            return dStock.Browse(StockData);
        }

        public DataTable Search(CStock StockData)
        {
            return dStock.Search(StockData);
        }

        public CStock BrowseOne(int stock_id)
        {
            if (stock_id < 1)
                return null;

            CStock StockData = new CStock();
            DataTable dtStock = new DataTable();

            StockData.stock_id = stock_id;
            dtStock = dStock.Browse(StockData);

            if (dtStock == null || dtStock.Rows.Count == 0)
            {
                return null;
            }

            StockData.FromDataRow(dtStock.Rows[0]);
            return StockData;
        }

        public bool DeleteOne(int stock_id)
        {
            if (stock_id < 1)
                return false;

            CStock StockData = new CStock();
            StockData.stock_id = stock_id;

            return dStock.Delete(StockData);
        }

    }
}