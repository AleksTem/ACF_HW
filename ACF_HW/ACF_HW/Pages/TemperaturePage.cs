using ACF_HW.Components;
using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACF_HW.Pages
{
    using _ = TemperaturePage;

    [Url("ua/maps/eur/temp")]
    [VerifyH1("Температура повітря в Європі")]
    [TermFindSettings(Case = TermCase.HyphenKebab)]
    class TemperaturePage : Page<_>
    {
        [FindByClass]
        private Button<_> BtnPlay { get; set; }

        [FindById]
        private UnorderedList<ListItem<_>, _> MapList { get; set; }

        public _ RunPlayHistory()
        {
            BtnPlay.ScrollTo().BtnPlay.Click();
            return this;
        }

        public _ CheckItemsBecomingActiveFromTopToBottom()
        {
            int itemsCount = MapList.Items.Count;
            for (int i = 0; i < itemsCount; i++)
            {
                MapList.Items[i].Should.Within(0.9, retryIntervalSeconds: 0.1).HaveClass("active");
            }

            return this;
        }

        [FindByCss(".dd_cnt.float_right")]
        public CustomTimeZoneSelect<_> TimeZone { get; set; }
    }

}
