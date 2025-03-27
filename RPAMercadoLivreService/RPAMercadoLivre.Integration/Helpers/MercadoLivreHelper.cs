using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPAMercadoLivre.Integration.Helpers
{
    public static class MercadoLivreHelper
    {
        public static readonly Regex PrecosRegex = new Regex(
            pattern: @"R\$\s*\s*<\s*/\s*span\s*>\s*<\s*span\s*class\s*=\s*(?:""|')andes-money-amount__fraction\s*(?:""|')[^>]*>(?<valorAVista>[^<]*)<\s*/\s*span\s*>\s*<\s*/\s*span\s*>\s*<\s*span\s*class",
            options: RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline,
            matchTimeout: TimeSpan.FromSeconds(15)
        );

        public static string Url = "https://lista.mercadolivre.com.br/";
    }
}
