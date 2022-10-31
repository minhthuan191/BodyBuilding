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

        public bool CreateTarget(Target target)
        {
            if (target == null)
            {
                return false;
            }
            else
            {
                return tgrepo.CreateTarget(target);
            }
        }

        public bool DeleteTarget(string targetId)
        {
            try
            {
                if (targetId == null)
                {
                    return false;
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
                if (targetId == null || tgrepo.GetTargetbyID(targetId) == null)
                {
                    return null ;
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
                    return false;
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
