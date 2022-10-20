using BodyBuildingApp.Models;
using System.Threading.Tasks;

namespace BodyBuildingApp.Repository.Interface
{
    public interface IDailyPlanRepository
    {
        public DailyPlan GetDailybyPlanID(string id);
        public DailyPlan GetDailybyUserID(string id);
        public DailyPlan GetDailybyDate(string date);
        public bool UpdateDailyPlan(DailyPlan dailyPlan);
        public bool DeleteDailyPlan(string id);
    }
}
