using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Silence.ViewModel
{
    class FacebookModel
    {
        private static FacebookModel instance;
        private List<FacebookProfile> listLogin;
        public FacebookModel()
        {
            listLogin = new List<FacebookProfile>();
        }
        public static FacebookModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FacebookModel();
                }
                return instance;
            }
        }
        public List<FacebookProfile> ListLogin
        {
            get { return listLogin; }
            
        }
    }
}
