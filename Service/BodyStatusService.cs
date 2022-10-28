using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Repository;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Components.Web;

namespace BodyBuildingApp.Service
{
    public class BodyStatusService : IBodyStatusService
    {
        private readonly BodyStatusRepository bsrepo;
        public BodyStatusService(BodyStatusRepository bsrepo)
        {
            this.bsrepo = bsrepo;
        }

        public List<BodyStatus> GetAllBodyStatus()
        {
            return bsrepo.GetAllBodyStatus();
        }

        public BodyStatus GetBodyStatusByBodyID(string bodyid)
        {
            if (bodyid == null || bsrepo.GetBodyStatusByBodyID == null)
            {
                return null; 
            }
            else
            {
                return bsrepo.GetBodyStatusByBodyID(bodyid);
            }
        }

        public BodyStatus GetBodyStatusByUserId(string userId)
        {
            if(userId == null || bsrepo.GetBodyStatusByUserId(userId) == null)
            {
                return null;
            }
            else
            {
                return bsrepo.GetBodyStatusByUserId(userId);
            }
        }
        public bool Deletebody(string bodyid)
        {
            if (bodyid == null || bsrepo.GetBodyStatusByUserId(bodyid) == null) 
            {
                return false ;
               
            }
            else
            {
                bsrepo.Deletebody(bodyid);
                return true;
            }
        }

        public bool Updatebody(BodyStatus bodyStatus)
        {
            if (bodyStatus == null || bsrepo.GetBodyStatusByUserId(bodyStatus.BodyStatusId) == null) 
            {
                return false;
               
            }
            else
            {
                bsrepo.Updatebody(bodyStatus);
                return true;
            }
        }
    }
}
