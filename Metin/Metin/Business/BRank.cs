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
    public class BRank : BaseBusiness
    {
        public DRank dRank = new DRank();

        public bool Insert(CRank RankData)
        {
            ReturnValue = dRank.Insert(RankData);
            return ReturnValue > 0 ? true : false;
        }

        public bool Update(CRank RankData)
        {
            return dRank.Update(RankData);
        }

        public bool Delete(CRank RankData)
        {
            return dRank.Delete(RankData);
        }

        public DataTable Browse(CRank RankData)
        {
            return dRank.Browse(RankData);
        }

        public DataTable Search(CRank RankData)
        {
            return dRank.Search(RankData);
        }

        public CRank BrowseOne(int rank_id)
        {
            if (rank_id < 1)
                return null;

            CRank RankData = new CRank();
            DataTable dtRank = new DataTable();

            RankData.rank_id = rank_id;
            dtRank = dRank.Browse(RankData);

            if (dtRank == null || dtRank.Rows.Count==0)
                return null;

           
            RankData.FromDataRow(dtRank.Rows[0]);
        
            return RankData;

        }

        public bool DeletOne(int rank_id)
        {
            if (rank_id < 1)
                return false;

            CRank rankData = new CRank();
            rankData.rank_id = rank_id;

            return dRank.Delete(rankData);
        }

    }
}