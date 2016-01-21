using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TpFinalTDP2015.Persistence.Model;
using TpFinalTDP2015.Service.DTO;
using TpFinalTDP2015.Service.AutoMapperProfiles;

namespace TpFinalTDP2015.Service
{
    public class AutoMapperConfigurations
    {
        static public void  Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<LapseProfile>();
            });
        }
    }  
}
