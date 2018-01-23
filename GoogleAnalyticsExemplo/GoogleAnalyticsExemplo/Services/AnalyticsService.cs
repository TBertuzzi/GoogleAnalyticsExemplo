using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoogleAnalyticsExemplo.Services
{
    public static class AnalyticsService
    {
        public static void RastrearPage(string nomePage)
        {
            DependencyService.Get<IAnalyticsService>().RastrearPage(nomePage);
        }

        public static void RastrearEvento(string categoria, string evento)
        {
            DependencyService.Get<IAnalyticsService>().RastrearEvento(categoria, evento);
        }

        public static void RastrearErros(string mensagemErro, bool erroFatal)
        {
            DependencyService.Get<IAnalyticsService>().RastrearErros(mensagemErro, erroFatal);
        }
    }
}
