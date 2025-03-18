using atFrameWork2.BaseFramework;
using ATframework3demo.BaseFramework;
using ATframework3demo.PageObjects.Mobile;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_Mobile_CRM: CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(
                new TestCase("создания сделки в CRM", mobileHomePage => CreateCRM(mobileHomePage)));
            return caseCollection;
        }

        void CreateCRM(MobileHomePage homePage)
        {
            var parametrDeal = new Bitrix24MobileCRM { Name = "Deal_name" + HelperMethods.GetDateTimeSaltString() };
            parametrDeal.Sum = "123" + HelperMethods.GetDateTimeSaltString();
            homePage.TabsPanel
                //Открыть доп меню
                .SelectMore()
                //перейти в раздел CRM
                .SelectCRM()
                //Нажать создать CRM
                .CreateCRM()
                //Выбрать сделку
                .SelectDeal()
                //Заполнить поля сделки
                .AddParametrsDeal(parametrDeal)
                //Нажать кнопку Create
                .CreateDeal()
                //Проверка созданной сделки
                .AssertDealCRM(parametrDeal);
        }
    }
}
