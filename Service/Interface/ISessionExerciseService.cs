using BodyBuildingApp.Models;

namespace BodyBuildingApp.Service.Interface
{
    public interface ISessionExerciseService
    {
        public bool UpdateSessionExercise(SessionExercise sessionExercise);
        public bool DeleteSessionExercise(string seid);
        public bool CreateSessionExercise(SessionExercise sessionExercise);
        public SessionExercise GetSessionExerciseID(string seid);
    }
}
