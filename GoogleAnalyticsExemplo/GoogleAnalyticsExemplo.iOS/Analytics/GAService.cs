using Foundation;
using Google.Analytics;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(GoogleAnalyticsExemplo.iOS.Analytics.GAService))]
namespace GoogleAnalyticsExemplo.iOS.Analytics
{
    public class GAService : IAnalyticsService
    {
        //para obter seu id https://analytics.google.com/
        public string TrackingId = "ADICIONE AQUI SEU ID DO ANALYTICS";
        public ITracker Tracker;
        const string AllowTrackingKey = "AllowTracking";

        #region Instantition...
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

        public void Initialize_NativeGAS()
        {
            var optionsDict = NSDictionary.FromObjectAndKey(new NSString("YES"), new NSString(AllowTrackingKey));
            NSUserDefaults.StandardUserDefaults.RegisterDefaults(optionsDict);

            Gai.SharedInstance.OptOut = !NSUserDefaults.StandardUserDefaults.BoolForKey(AllowTrackingKey);

            Gai.SharedInstance.DispatchInterval = 10;
            Gai.SharedInstance.TrackUncaughtExceptions = true;

            Tracker = Gai.SharedInstance.GetTracker("Test App", TrackingId);
        }

        public void RastrearPage(string nomePage)
        {
            Gai.SharedInstance.DefaultTracker.Set(GaiConstants.ScreenName, nomePage);
            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateScreenView().Build());
        }

        public void RastrearEvento(string categoria, string evento)
        {
            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateEvent(categoria, evento, "AppEvent", null).Build());
            Gai.SharedInstance.Dispatch(); // Manually dispatch the event immediately
        }

        public void RastrearErros(string mensagemErro, bool erroFatal)
        {
            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateException(mensagemErro, erroFatal).Build());
        }
    }
}
