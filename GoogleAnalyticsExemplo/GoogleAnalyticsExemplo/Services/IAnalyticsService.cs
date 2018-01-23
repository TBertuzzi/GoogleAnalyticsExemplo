using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleAnalyticsExemplo
{
    public interface IAnalyticsService
    {
        void RastrearPage(string nomePage);

		void RastrearEvento(string categoria, string evento);

		void RastrearErros(string mensagemErro, bool erroFatal);
    }
}
