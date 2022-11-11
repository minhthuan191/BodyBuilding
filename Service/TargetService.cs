using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;
using System.Collections.Generic;

namespace BodyBuildingApp.Service
{
    public class TargetService : ITargetService
    {
        private readonly TargetRepository tgrepo;

        public TargetService(TargetRepository tgrepo)
        {
            this.tgrepo = tgrepo;
        }

        public bool CreateTarget(Target target)
        {
            return tgrepo.CreateTarget(target);

        }

        public bool DeleteTarget(Target target)
        {
            return tgrepo.DeleteTarget(target);
        }

        public List<Target> GetAllTarget()
        {
            return tgrepo.GetAllTarget();
        }

        public Target GetTargetbyID(string targetId)
        {
            return tgrepo.GetTargetbyID(targetId);
        }

        public bool UpdateTarget(Target target)
        {

            return tgrepo.UpdateTarget(target);
        }
    }
}
