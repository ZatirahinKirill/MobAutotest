using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.Mobile.CRM
{
    public class PageDeal
    {
        public bool AssertDealCRM(Bitrix24MobileCRM parametrDeal)
        {
            return new WebItem($"//android.widget.TextView[@content-desc='{parametrDeal.Name}']", "Название сделки").AssertTextContains(parametrDeal.Name, "Сделка не найденна");
        }
    }
}
