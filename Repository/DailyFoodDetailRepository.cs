using BodyBuildingApp.Models;
using BodyBuildingApp.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BodyBuildingApp.Repository
{
    public class DailyFoodDetailRepository
    {
        private readonly DBContext DBContext;

        public DailyFoodDetailRepository(DBContext dBContext)
        {
            this.DBContext = dBContext;
        }
        public List<DailyFoodDetail> GetAllDailyFoodDetail()
        {
            List<DailyFoodDetail> list= this.DBContext.Set<DailyFoodDetail>().ToList<DailyFoodDetail>();
            if(list.Count == 0)
            {
                return null;
            }
            else
            {
                return list;
            }
        }

        public DailyFoodDetail GetDailyFoodDetailID(string id)
        {
            DailyFoodDetail dailyFoodDetail = this.DBContext.DailyFoodDetails.FirstOrDefault(item => item.DailyFoodDetailId == id);
            if (dailyFoodDetail == null) return null;
            return dailyFoodDetail;
        }

        public bool UpdateDailyFooDDetail(DailyFoodDetail dailyFoodDetail)
        {
            this.DBContext.Entry(dailyFoodDetail).State = EntityState.Modified;
            if(dailyFoodDetail == null)
            {
                return false;
            }
            else
            {
                this.DBContext.DailyFoodDetails.Update(dailyFoodDetail);
                this.DBContext.SaveChanges();
                return true;
            }
        }
        public bool DeleteDailyFooDDetail(string id)
        {
            var dailyfooddetail = GetDailyFoodDetailID(id);
            if(dailyfooddetail == null)
            {
                return false;
            }
            else
            {
                this.DBContext.DailyFoodDetails.Remove(dailyfooddetail);
                this.DBContext.SaveChanges();
                return true;
            }
        }
        public bool CreateDailyFoodDetail(DailyFoodDetail dailyFoodDetail)
        {
            if(dailyFoodDetail == null)
            {
                return false;
            }
            else
            {
                this.DBContext.DailyFoodDetails.Add(dailyFoodDetail);
                this.DBContext.SaveChanges();
                return true;
            }
        }
    }
}
