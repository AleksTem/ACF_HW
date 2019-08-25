using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACF_HW.Pages
{
    using _ = TwoWeeksPage;


    [Url("ua/weather-kharkiv-5053/2-weeks")]
    [VerifyH1(TermMatch.Contains, TermCase.Sentence, Format = "Погода у Харкові на два тижні", On = TriggerEvents.Init)]
    class TwoWeeksPage : Page<_>
    {
        public H1<_> PageInfo { get; private set; }

        [FindByCss("[data-widget-id='forecast']")]
        public Clickable<_> Forecast { get; private set; }

        [FindByCss("[data-widget-id='averageTemp']")]
        public Clickable<_> AverageTemp { get; private set; }

        [FindByCss("[data-widget-id='wind']")]
        public Clickable<_> Wind { get; private set; }

        [FindByCss("[data-widget-id='pressure']")]
        public Clickable<_> Pressure { get; private set; }

        [FindByCss("[data-widget-id='humidity']")]
        public Clickable<_> Humidity { get; private set; }

        [FindByCss("[data-widget-id='gm']")]
        public Clickable<_> GeomagneticActivity { get; private set; }

        [FindByClass("map_horizontal")]
        public Clickable<_> EuroMap { get; private set; }

        public ControlList<EuroMapItem, _> EuroMapControlList { get; private set; }

        [ControlDefinition(ContainingClass = "map")]
        public class EuroMapItem : ListItem<_>
        {
            [FindByCss(".title a")]
            public Link<_> Title { get; private set; }
        }
    }
}
