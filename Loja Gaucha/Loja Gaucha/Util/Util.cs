using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaGaucha.Util
{
    public class Util
    {
        public static string RetornarCarrinhoId()
        {
            if (HttpContext.Current.Session["IdCarrinho"] == null)
            {
                Guid novoGuid = Guid.NewGuid();
                HttpContext.Current.Session["IdCarrinho"] = novoGuid.ToString();
            }
            return HttpContext.Current.Session["IdCarrinho"].ToString();
        }

        internal static void ResetarGuid()
        {
            Guid novoGuid = Guid.NewGuid();
            HttpContext.Current.Session["IdCarrinho"] = novoGuid.ToString();
        }
    }
}