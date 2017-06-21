using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.MediaManager;

namespace SilenceTv1._0
{
    public class appManager
    {
        
        private static appManager instance;

        private appManager() {
           
           
        }

        public static appManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new appManager();
                }
                return instance;
            }
        }



    }
}
