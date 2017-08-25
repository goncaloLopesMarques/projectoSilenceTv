using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silence.ViewModel
{
    class PublicityModel
    {
        private static PublicityModel instance;
        private List<Publicity> listPublicity;

        public PublicityModel()
        {
            listPublicity = new List<Publicity>();
        }
        public static PublicityModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PublicityModel();
                }
                return instance;
            }
        }
        public List<Publicity> ListPublicity
        {
            get { return listPublicity; }
            set { listPublicity = value; }

        }
        public Publicity PickRandomPublicity()
        {
                int aux;
                Random rand = new Random();
                aux = rand.Next(0, listPublicity.Count);
                return listPublicity.ElementAt(aux);

        }
    }
}
