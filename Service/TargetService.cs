using BodyBuildingApp.Models;
using BodyBuildingApp.Repository;
using BodyBuildingApp.Service.Interface;
using System;

namespace BodyBuildingApp.Service
{
    public class TargetService : ITargetService
    {
        private readonly TargetRepository tgrepo;

        public TargetService(TargetRepository tgrepo)
        {
            this.tgrepo = tgrepo;
        }

        public bool DeleteTarget(Target targetId)
        {
            try
            {
                if (targetId == null)
                {
                    throw new Exception("Error at get DeleteTarget");
                }
                else
                {
                    return tgrepo.DeleteTarget(targetId);
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Target GetTargetbyID(string targetId)
        {
            try
            {
                if (targetId == null)
                {
                    throw new Exception("Error at get GetTargetbyID");
                }
                else
                {
                    return tgrepo.GetTargetbyID(targetId);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateTarget(Target target)
        {
            try
            {
                if (target == null)
                {
                    throw new Exception("Error at get UpdateTarget");
                }
                else
                {
                    return tgrepo.UpdateTarget(target);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
