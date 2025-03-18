using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.Mobile.CRM
{
    public class SelectCRMPage
    {
        public FieldDeal SelectDeal()
        {
            var dealCRM = new MobileItem("//android.view.ViewGroup[@content-desc=\"CRM_ENTITY_TAB_DEAL_CONTEXT_MENU_2\"]/android.view.ViewGroup[1]", "Выбрать сделку");
            dealCRM.Click();
            return new FieldDeal();
        }
    }
}
