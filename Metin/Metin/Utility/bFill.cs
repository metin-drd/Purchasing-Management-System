using Metin.Business;
using Metin.Command;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Metin.Utility
{
    public class bFill
    {
        public bFill()
        {
        }

        #region Drop Down List
        #region Sabit Değer
        public static void Fill_SabitDeger(DropDownList ddl, bConstants.SabitDegerTipi SabitDegerTipi, bConstants.FillTypes FillType)
        {
            if (SabitDegerTipi == null)
                return;

            BSabitDeger bFill = new BSabitDeger();
            CSabitDeger SabitDegerData = new CSabitDeger();
            SabitDegerData.sabit_deger_listesi_id = (int)SabitDegerTipi;
            DataTable dtFill = bFill.Search(SabitDegerData);

            switch (FillType)
            {
                case bConstants.FillTypes.All:
                    DataRow rowAll = dtFill.NewRow();
                    rowAll["sabit_deger"] = "0";
                    rowAll["sabit_deger_adi"] = "All";

                    dtFill.Rows.InsertAt(rowAll, 0);
                    break;

                case bConstants.FillTypes.Choose:
                    DataRow rowChoose = dtFill.NewRow();
                    rowChoose["sabit_deger"] = "0";
                    rowChoose["sabit_deger_adi"] = "Choose";

                    dtFill.Rows.InsertAt(rowChoose, 0);
                    break;
            }

            if (ddl == null)
                ddl = new DropDownList();

            ddl.DataSource = dtFill;
            ddl.DataTextField = dtFill.Columns["sabit_deger_adi"].ColumnName;
            ddl.DataValueField = dtFill.Columns["sabit_deger"].ColumnName;
            ddl.DataBind();
        }
        #endregion

        #region Rank
        /// <summary>
        /// PersonnelRank bilgisini DropDownList içine doldurur.
        /// </summary>
        /// <param name="ddl">Doldurulacak DropDownList controlü.</param>
        /// <param name="RankData">Filtreleme için kullanılacak PersonnelRank bilgisi.</param>
        /// <param name="FillType">Doldurma şeklini belirtir.</param>
        public static DropDownList Rank(DropDownList ddl, CRank RankData, bConstants.FillTypes FillType)
        {
            if (RankData == null)
                RankData = new CRank();

            BRank bFill = new BRank();
            DataTable dtFill = bFill.Browse(RankData);

            switch (FillType)
            {
                case bConstants.FillTypes.All:
                    DataRow rowAll = dtFill.NewRow();
                    rowAll[0] = "0";
                    rowAll[1] = "All Ranks";

                    dtFill.Rows.InsertAt(rowAll, 0);
                    break;

                case bConstants.FillTypes.Choose:
                    DataRow rowChoose = dtFill.NewRow();
                    rowChoose[0] = "0";
                    rowChoose[1] = "Choose Rank";

                    dtFill.Rows.InsertAt(rowChoose, 0);
                    break;
            }

            if (ddl == null)
                ddl = new DropDownList();

            ddl.DataSource = dtFill;
            ddl.DataTextField = dtFill.Columns["name"].ColumnName;
            ddl.DataValueField = dtFill.Columns["rank_id"].ColumnName;
            ddl.DataBind();

            return ddl;
        }
        #endregion

        #region Department
        /// <summary>
        /// Department bilgisini DropDownList içine doldurur.
        /// </summary>
        /// <param name="ddl">Doldurulacak DropDownList controlü.</param>
        /// <param name="DepartmentData">Filtreleme için kullanılacak Department bilgisi.</param>
        /// <param name="FillType">Doldurma şeklini belirtir.</param>
        public static DropDownList Department(DropDownList ddl, CDepartment DepartmentData, bConstants.FillTypes FillType)
        {
            if (DepartmentData == null)
                DepartmentData = new CDepartment();

            BDepartment bFill = new BDepartment();
            DataTable dtFill = bFill.Browse(DepartmentData);

            switch (FillType)
            {
                case bConstants.FillTypes.All:
                    DataRow rowAll = dtFill.NewRow();
                    rowAll[0] = "0";
                    rowAll[1] = "All Departments";

                    dtFill.Rows.InsertAt(rowAll, 0);
                    break;

                case bConstants.FillTypes.Choose:
                    DataRow rowChoose = dtFill.NewRow();
                    rowChoose[0] = "0";
                    rowChoose[1] = "Choose Department";

                    dtFill.Rows.InsertAt(rowChoose, 0);
                    break;
            }

            if (ddl == null)
                ddl = new DropDownList();

            ddl.DataSource = dtFill;
            ddl.DataTextField = dtFill.Columns["name"].ColumnName;
            ddl.DataValueField = dtFill.Columns["department_id"].ColumnName;
            ddl.DataBind();

            return ddl;
        }
        #endregion

        #region Personnel
        /// <summary>
        /// Personnel bilgisini DropDownList içine doldurur.
        /// </summary>
        /// <param name="ddl">Doldurulacak DropDownList controlü.</param>
        /// <param name="PersonnelData">Filtreleme için kullanılacak Personnel bilgisi.</param>
        /// <param name="FillType">Doldurma şeklini belirtir.</param>
        public static DropDownList Personnel(DropDownList ddl, CPersonnel PersonnelData, bConstants.FillTypes FillType)
        {
            if (PersonnelData == null)
                PersonnelData = new CPersonnel();

            BPersonnel bFill = new BPersonnel();
            DataTable dtFill = bFill.Browse(PersonnelData);

            switch (FillType)
            {
                case bConstants.FillTypes.All:
                    DataRow rowAll = dtFill.NewRow();
                    rowAll["personnel_id"] = "0";
                    rowAll["personnel_full_name"] = "All Personnel";

                    dtFill.Rows.InsertAt(rowAll, 0);
                    break;

                case bConstants.FillTypes.Choose:
                    DataRow rowChoose = dtFill.NewRow();
                    rowChoose["personnel_id"] = "0";
                    rowChoose["personnel_full_name"] = "Choose Personnel";

                    dtFill.Rows.InsertAt(rowChoose, 0);
                    break;
            }

            if (ddl == null)
                ddl = new DropDownList();

            ddl.DataSource = dtFill;
            ddl.DataTextField = dtFill.Columns["personnel_full_name"].ColumnName;
            ddl.DataValueField = dtFill.Columns["personnel_id"].ColumnName;
            ddl.DataBind();

            return ddl;
        }
        #endregion

        #region Kullanici
        /// <summary>
        /// Personnel bilgisini DropDownList içine doldurur.
        /// </summary>
        /// <param name="ddl">Doldurulacak DropDownList controlü.</param>
        /// <param name="KullaniciData">Filtreleme için kullanılacak Personnel bilgisi.</param>
        /// <param name="FillType">Doldurma şeklini belirtir.</param>
        public static DropDownList Kullanici(DropDownList ddl, CKullanici KullaniciData, bConstants.FillTypes FillType)
        {
            if (KullaniciData == null)
                KullaniciData = new CKullanici();

            BKullanici bFill = new BKullanici();
            DataTable dtFill = bFill.Browse(KullaniciData);

            switch (FillType)
            {
                case bConstants.FillTypes.All:
                    DataRow rowAll = dtFill.NewRow();
                    rowAll["kullanici_id"] = "0";
                    rowAll["personnel_full_name"] = "All User";

                    dtFill.Rows.InsertAt(rowAll, 0);
                    break;

                case bConstants.FillTypes.Choose:
                    DataRow rowChoose = dtFill.NewRow();
                    rowChoose["kullanici_id"] = "0";
                    rowChoose["personnel_full_name"] = "Choose User";

                    dtFill.Rows.InsertAt(rowChoose, 0);
                    break;
            }

            if (ddl == null)
                ddl = new DropDownList();

            ddl.DataSource = dtFill;
            ddl.DataTextField = dtFill.Columns["personnel_full_name"].ColumnName;
            ddl.DataValueField = dtFill.Columns["kullanici_id"].ColumnName;
            ddl.DataBind();

            return ddl;
        }
        #endregion

        #region Vessel
        /// <summary>
        /// Vessel bilgisini DropDownList içine doldurur.
        /// </summary>
        /// <param name="ddl">Doldurulacak DropDownList controlü.</param>
        /// <param name="VesselData">Filtreleme için kullanılacak Vessel bilgisi.</param>
        /// <param name="FillType">Doldurma şeklini belirtir.</param>
        public static DropDownList Vessel(DropDownList ddl, CVessel VesselData, bConstants.FillTypes FillType)
        {
            if (VesselData == null)
                VesselData = new CVessel();

            BVessel bFill = new BVessel();
            DataTable dtFill = bFill.Browse(VesselData);

            switch (FillType)
            {
                case bConstants.FillTypes.All:
                    DataRow rowAll = dtFill.NewRow();
                    rowAll[0] = "0";
                    rowAll[1] = "All Vessel";

                    dtFill.Rows.InsertAt(rowAll, 0);
                    break;

                case bConstants.FillTypes.Choose:
                    DataRow rowChoose = dtFill.NewRow();
                    rowChoose[0] = "0";
                    rowChoose[1] = "Choose Vessel";

                    dtFill.Rows.InsertAt(rowChoose, 0);
                    break;
            }

            if (ddl == null)
                ddl = new DropDownList();

            ddl.DataSource = dtFill;
            ddl.DataTextField = dtFill.Columns["ship_name"].ColumnName;
            ddl.DataValueField = dtFill.Columns["vessel_id"].ColumnName;
            ddl.DataBind();

            return ddl;
        }
        #endregion

        #region StockCategory
        /// <summary>
        /// Stock Category bilgisini DropDownList içine doldurur.
        /// </summary>
        /// <param name="ddl">Doldurulacak DropDownList controlü.</param>
        /// <param name="StockCategoryData">Filtreleme için kullanılacak Vessel bilgisi.</param>
        /// <param name="FillType">Doldurma şeklini belirtir.</param>
        public static DropDownList StockCategory(DropDownList ddl, CStockCategory StockCategoryData, bConstants.FillTypes FillType)
        {
            if (StockCategoryData == null)
                StockCategoryData = new CStockCategory();

            BStockCategory bFill = new BStockCategory();
            DataTable dtFill = bFill.Browse(StockCategoryData);

            switch (FillType)
            {
                case bConstants.FillTypes.All:
                    DataRow rowAll = dtFill.NewRow();
                    rowAll[0] = "0";
                    rowAll[1] = "All Stock Category";

                    dtFill.Rows.InsertAt(rowAll, 0);
                    break;

                case bConstants.FillTypes.Choose:
                    DataRow rowChoose = dtFill.NewRow();
                    rowChoose[0] = "0";
                    rowChoose[1] = "Choose Stock Category";

                    dtFill.Rows.InsertAt(rowChoose, 0);
                    break;
            }

            if (ddl == null)
                ddl = new DropDownList();

            ddl.DataSource = dtFill;
            ddl.DataTextField = dtFill.Columns["name"].ColumnName;
            ddl.DataValueField = dtFill.Columns["stock_category_id"].ColumnName;
            ddl.DataBind();

            return ddl;
        }
        #endregion

        #region Stock
        /// <summary>
        /// Stock bilgisini DropDownList içine doldurur.
        /// </summary>
        /// <param name="ddl">Doldurulacak DropDownList controlü.</param>
        /// <param name="Stock">Filtreleme için kullanılacak Vessel bilgisi.</param>
        /// <param name="FillType">Doldurma şeklini belirtir.</param>
        public static DropDownList Stock(DropDownList ddl, CStock StockData, bConstants.FillTypes FillType)
        {
            if (StockData == null)
                StockData = new CStock();

            BStock bFill = new BStock();
            DataTable dtFill = bFill.Search(StockData);

            switch (FillType)
            {
                case bConstants.FillTypes.All:
                    DataRow rowAll = dtFill.NewRow();
                    rowAll[0] = "0";
                    rowAll[1] = "All Stock";

                    dtFill.Rows.InsertAt(rowAll, 0);
                    break;

                case bConstants.FillTypes.Choose:
                    DataRow rowChoose = dtFill.NewRow();
                    rowChoose[0] = "0";
                    rowChoose[1] = "Choose Stock";

                    dtFill.Rows.InsertAt(rowChoose, 0);
                    break;
            }

            if (ddl == null)
                ddl = new DropDownList();

            ddl.DataSource = dtFill;
            ddl.DataTextField = dtFill.Columns["stock_name"].ColumnName;
            ddl.DataValueField = dtFill.Columns["stock_id"].ColumnName;
            ddl.DataBind();

            return ddl;
        }
        #endregion
        
        #endregion


    }
}