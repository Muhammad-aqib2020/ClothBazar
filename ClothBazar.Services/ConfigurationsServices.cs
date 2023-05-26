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
        #region Singleton
        public static ConfigurationsServices Instance
        {
            get
            {
                if (instance == null) instance = new ConfigurationsServices();

                return instance;
            }
        }
        private static ConfigurationsServices instance { get; set; }
        private ConfigurationsServices()
        {

        }
        #endregion
        public Config GetConfig (string Key)
        {
            using(var context = new CBContext())
            {
                return context.Configurations.Find(Key);
            }
        }
    }
}
