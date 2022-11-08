using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System.Collections.Generic;

namespace BodyBuildingApp.Service
{
    public class DailyFoodDetailService : IDailyFoodDetailService
    {
        private readonly DailyFoodDetailRepository dfdrepo;

        public DailyFoodDetailService(DailyFoodDetailRepository dfdrepo)
        {
            this.dfdrepo = dfdrepo;
        }

        public bool CreateDailyFoodDetail(DailyFoodDetail dailyFoodDetail)
        {
            if (dailyFoodDetail == null)
            {
                return false;
            }
            else
            {
                dfdrepo.CreateDailyFoodDetail(dailyFoodDetail);
                return true;
            }
        }

        public bool DeteleDailyFoodDetail(string id)
        {
            if(id == null)
            {
                return false;
            }
            else
            {
                dfdrepo.DeleteDailyFooDDetail(id);
                return true;
            }
        }

        public List<DailyFoodDetail> GetAllDailyFoodDetail()
        {
            return dfdrepo.GetAllDailyFoodDetail();
        }

        public DailyFoodDetail GetDailyFoodDetailId(string id)
        {
           if(id == null)
            {
                return null;
            }
            else
            {
                return dfdrepo.GetDailyFoodDetailID(id);
            }
        }

        public bool UpdateDailyFoodDetail(DailyFoodDetail dailyFoodDetail)
        {
            if(dailyFoodDetail == null)
            {
                return false;
            }
            else
            {
                dfdrepo.UpdateDailyFooDDetail(dailyFoodDetail);
                return true;
            }
        }
    }
}
