using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACF_HW.Components
{
    [FindSettings(ScopeSource = ScopeSource.Parent)]
    [ControlDefinition("div[contains(@class, 'js_dropmenu')]")]
    [TermFindSettings(Case = TermCase.Snake)]
    public class CustomTimeZoneSelect<TOwner> : Select<TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected Clickable<TOwner> Title { get; set; }

        protected Clickable<TOwner> DdBtn { get; set; }

        protected UnorderedList<ListItem<TOwner>, TOwner> DropList { get; set; }

        protected override void SetValue(string value)
        {
            DdBtn.Click();
            DropList[x => x.Attributes["data-tz"] == value].Click();
        }

        protected override string GetValue()
        {
            return Title.Content.Value.Replace("UTC ", "").Replace("−", "-");
        }
    }
}
