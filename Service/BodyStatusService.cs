using BodyBuildingApp.Models;
using BodyBuildingApp.Service.Interface;
using BodyBuildingApp.Repository;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

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
            if (bodyid == null || bsrepo.GetBodyStatusByBodyID(bodyid) == null)
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
        public bool Deletebody(BodyStatus bodyStatus)
        {
            return this.bsrepo.DeleteBody(bodyStatus);
        }

        public bool Updatebody(BodyStatus bodyStatus)
        {
            return this.bsrepo.Updatebody(bodyStatus);
        }

        public bool Createbody(BodyStatus bodyStatus)
        {
            return this.bsrepo.CreateBodyStatus(bodyStatus);
        }
    }
}
