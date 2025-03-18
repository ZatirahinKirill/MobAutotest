using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Mobile.CRM;

namespace ATframework3demo.PageObjects.Mobile
{
    public class MobileMorePage
    {
        public MobileMorePage SelectCRM()
        {
            var CRMTab = new MobileItem("(//android.widget.LinearLayout[@content-desc=\"section_{Tools}\"])[3]", "Таб 'CRM'");
            CRMTab.Click();
            return new MobileMorePage();
        }

        public SelectCRMPage CreateCRM()
        {
            var createCRM = new MobileItem("//android.widget.TextView[@resource-id=\"com.bitrix24.android:id/tag\"]", "Таб '+'");
            createCRM.Click();
            return new SelectCRMPage();
        }
    }
}
