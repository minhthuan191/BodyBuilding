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
            if(bodyid == null)
            {
                throw new Exception("Error at get Body Status by Body ID");
            }
            else
            {
                return bsrepo.GetBodyStatusByBodyID(bodyid);
            }
        }

        public BodyStatus GetBodyStatusByUserId(string userId)
        {
            if(userId == null)
            {
                throw new Exception("Error at get Body Status by User ID");
            }
            else
            {
                return bsrepo.GetBodyStatusByUserId(userId);
            }
        }
        public bool Deletebody(BodyStatus bodyid)
        {
            if (bodyid == null) 
            {
                throw new Exception("Error at DeletaBody ");
               
            }
            else
            {
                bsrepo.Deletebody(bodyid);
                return true;
            }
        }

        public bool Updatebody(BodyStatus bodyStatus)
        {
            if (bodyStatus == null) 
            {
                throw new Exception("Error at UpdateBody ");
               
            }
            else
            {
                bsrepo.Updatebody(bodyStatus);
                return true;
            }
        }
    }
}
