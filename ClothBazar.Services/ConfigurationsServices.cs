using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
   public class ConfigurationsServices
    {
        //public static ConfigurationsServices ClassObject { 
        //    get {
        //        if (privateinmemoryobj == null) privateinmemoryobj = new ConfigurationsServices();

        //        return privateinmemoryobj;
        //    }
        //}
        //private static ConfigurationsServices privateinmemoryobj { get; set; }
        //private ConfigurationsServices()
        //{
           
        //}
        public Config GetConfig (string Key)
        {
            using(var context = new CBContext())
            {
                return context.Configurations.Find(Key);
            }
        }
    }
}
