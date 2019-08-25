using Atata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACF_HW.Components
{
    //[TermFindSettings(Case = TermCase.Snake, ScopeSource = ScopeSource.Parent)]
    [FindSettings(ScopeSource = ScopeSource.Parent)]
    public class CustomDropDown<TOwner> : Clickable<TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByClass("dd_btn")]
        protected Clickable<TOwner> DdBtn { get; set; }

        [FindByClass]
        protected UnorderedList<ListItem<TOwner>, TOwner> DropList { get; set; }

        public TOwner Set(string value)
        {
            DdBtn.Click();
            DropList[x => x.Attributes["data-tz"] == value].Click();
            return Owner;
        }
    }
}
