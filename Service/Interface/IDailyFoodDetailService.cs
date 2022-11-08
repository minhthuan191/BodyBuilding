using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface IDailyFoodDetailService
    {
        public  List<DailyFoodDetail> GetAllDailyFoodDetail();
        public bool UpdateDailyFoodDetail(DailyFoodDetail dailyFoodDetail);
        public bool DeteleDailyFoodDetail(string id);
        public bool CreateDailyFoodDetail(DailyFoodDetail dailyFoodDetail);
        public DailyFoodDetail GetDailyFoodDetailId(string id);
    }
}
