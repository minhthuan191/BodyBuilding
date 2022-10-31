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
        public bool Deletebody(string id)
        {
            if (id == null) 
            {
                return false ;
               
            }
            else
            {
                bsrepo.DeleteBody(id);
                return true;
            }
        }

        public bool Updatebody(BodyStatus bodyStatus)

        {
            if (bodyStatus == null)
            {
                throw new Exception("null value");

            }
            else
            {
                bsrepo.Updatebody(bodyStatus);
                return true;
            }
        }

        public bool Createbody(BodyStatus bodyStatus)
        {
            if (bodyStatus == null)
            {
                throw new Exception("null value");

            }
            else
            {
                bsrepo.CreateBodyStatus(bodyStatus);
                return true;
            }
        }
    }
}
