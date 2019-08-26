using Atata;

namespace ACF_HW.Components
{
    /// <summary>
    /// Represents Timezone element.
    /// </summary>
    /// <typeparam name="TOwner">The type of the owner page object.</typeparam>
    [ControlDefinition("div[contains(@class, 'js_dropmenu')]", ComponentTypeName = "timezone dropdown")]
    [FindSettings(ScopeSource = ScopeSource.Parent)]
    [TermFindSettings(Case = TermCase.Snake)]
    public class CustomTimeZoneSelect<TOwner> : Select<TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByCss("span.js_timezone_title")]
        protected Clickable<TOwner> TimezoneTitle { get; set; }

        protected Clickable<TOwner> DdBtn { get; set; }

        protected UnorderedList<ListItem<TOwner>, TOwner> DropList { get; set; }

        protected override void SetValue(string value)
        {
            DdBtn.Click();
            DropList[x => x.Attributes["data-tz"] == value].Click();
        }

        protected override string GetValue()
        {
            return TimezoneTitle.Attributes["data-tz"].Value;
        }
    }
}
