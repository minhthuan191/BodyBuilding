using BodyBuildingApp.Models;
using System.Collections.Generic;

namespace BodyBuildingApp.Service.Interface
{
    public interface IFoodDetailService
    {
        public List<FoodDetail> GetListFoodDetail();
        public FoodDetail GetFoodbyName(string name);

        public FoodDetail GetFoodByCalories(string calories);

        public bool CreateFoodDetail(FoodDetail foodDetail);

        public bool UpdateFoodDetail(FoodDetail foodDetail);

        public bool DeleteFoodDetail(string foodDId);
    }
}
