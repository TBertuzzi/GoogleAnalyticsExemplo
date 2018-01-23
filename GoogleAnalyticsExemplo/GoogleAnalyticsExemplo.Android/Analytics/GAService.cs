using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Dependency(typeof(GoogleAnalyticsExemplo.Droid.GAService))]
namespace GoogleAnalyticsExemplo.Droid.Analytics
{
    class GAService : IAnalyticsService
    {
        //para obter seu id https://analytics.google.com/
        public string TrackingId = "ADICIONE AQUI SEU ID DO ANALYTICS";

        private static GoogleAnalytics GAInstance;
        private static Tracker GATracker;

        #region Instantiation ...
        private static GAService thisRef;
        public GAService()
        {
           
        }

        public static GAService GetGASInstance()
        {
            if (thisRef == null)
                thisRef = new GAService();
            return thisRef;
        }
        #endregion

        public void Initialize_NativeGAS(Context AppContext = null)
        {
            GAInstance = GoogleAnalytics.GetInstance(AppContext.ApplicationContext);
            GAInstance.SetLocalDispatchPeriod(10);

            GATracker = GAInstance.NewTracker(TrackingId);
            GATracker.EnableExceptionReporting(true);
            GATracker.EnableAdvertisingIdCollection(true);
            GATracker.EnableAutoActivityTracking(true);
        }

        public void RastrearPage(string nomePage)
        {
            GATracker.SetScreenName(nomePage);
            GATracker.Send(new HitBuilders.ScreenViewBuilder().Build());
        }

        public void RastrearEvento(string categoria, string evento)
        {
            HitBuilders.EventBuilder builder = new HitBuilders.EventBuilder();
            builder.SetCategory(categoria);
            builder.SetAction(evento);
            builder.SetLabel("AppEvent");

            GATracker.Send(builder.Build());
        }

        public void RastrearErros(string mensagemErro, bool erroFatal)
        {
            HitBuilders.ExceptionBuilder builder = new HitBuilders.ExceptionBuilder();
            builder.SetDescription(mensagemErro);
            builder.SetFatal(erroFatal);

            GATracker.Send(builder.Build());
        }
    }
}