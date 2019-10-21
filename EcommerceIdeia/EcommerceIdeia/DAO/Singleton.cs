using EcommerceIdeia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EcommerceIdeia.DAO
{
    public class Singleton
    {
        private static Context contexto;

        private Singleton()
        {

        }
        public static Context GetInstance()
        {
            if (contexto == null)
                contexto = new Context();

            return contexto;
        }
    }
}