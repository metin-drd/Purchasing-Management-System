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
    public class BStockCategory : BaseBusiness
    {
        public DStockCategory dStockCategory = new DStockCategory();

        public bool Insert(CStockCategory StockCategory)
        {
            ReturnValue = dStockCategory.Insert(StockCategory);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CStockCategory StockCategory)
        {
            return dStockCategory.Update(StockCategory);
        }

        public bool Delete(CStockCategory StockCategory)
        {
            return dStockCategory.Delete(StockCategory);
        }

        public DataTable Browse(CStockCategory StockCategory)
        {
            return dStockCategory.Browse(StockCategory);
        }

        public DataTable Search(CStockCategory StockCategory)
        {
            return dStockCategory.Search(StockCategory);
        }

        public CStockCategory BrowseOne(int stock_category_id)
        {
            if (stock_category_id < 1)
                return null;

            CStockCategory StockCategoryData = new CStockCategory();
            DataTable dtStockCategory = new DataTable();

            StockCategoryData.stock_category_id = stock_category_id;
            dtStockCategory = dStockCategory.Browse(StockCategoryData);

            if (dtStockCategory == null || dtStockCategory.Rows.Count == 0)
                return null;


            StockCategoryData.FromDataRow(dtStockCategory.Rows[0]);

            return StockCategoryData;

        }

        public bool DeletOne(int stock_category_id)
        {
            if (stock_category_id < 1)
                return false;

            CStockCategory StockCategoryData = new CStockCategory();
            StockCategoryData.stock_category_id = stock_category_id;

            return dStockCategory.Delete(StockCategoryData);
        }

    }
}