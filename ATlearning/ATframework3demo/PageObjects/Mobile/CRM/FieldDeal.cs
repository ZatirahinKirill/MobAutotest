using System.Xml.Linq;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.Mobile.CRM
{
    public class FieldDeal
    {
        public FieldDeal AddParametrsDeal(Bitrix24MobileCRM parametrDeal)
        {
            var nameDeal = new MobileItem("//android.view.ViewGroup[@content-desc=\"deal_0_details_editor_TITLE_NAME_container\"]","Таб 'NameDeal'");
            nameDeal.Click();
            var inputNameDeal = new MobileItem("//android.widget.EditText[@text=\"Deal #\"]", "Ввести имя сделки");
            inputNameDeal.Click();
            inputNameDeal.SendKeys(parametrDeal.Name);
            var saveName = new MobileItem("//android.widget.TextView[@text=\"Save\"]","Сохранить имя сделки");
            saveName.Click();
            var inputSum = new MobileItem("//android.widget.EditText[@text=\"0\"]", "Ввести сумму");
            inputSum.Click();
            inputSum.SendKeys(parametrDeal.Sum);
            var btmAddContact = new MobileItem("//android.widget.TextView[@text=\"Add contact\"]", "Кнопка добавить контакт");
            btmAddContact.Click();
            var addContact = new MobileItem("//android.widget.ImageView[@content-desc=\"check_off\"]", "Выбрать контакты");
            addContact.Click();
            var saveContact = new MobileItem("//android.widget.TextView[@text=\"Select\"]", "Сохранить контакт");
            saveContact.Click();
            return new FieldDeal();
        }

        public PageDeal CreateDeal()
        {
            var btmCreateDeal = new MobileItem("//android.widget.TextView[@text=\"Create\"]","Кнопка создать сделку");
            btmCreateDeal.Click();
            return new PageDeal();
        }
    }
}
