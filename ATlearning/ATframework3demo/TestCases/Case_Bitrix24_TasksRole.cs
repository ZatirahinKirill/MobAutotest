using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.BaseFramework;
using ATframework3demo.PageObjects.Groups;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_TasksRole : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание новой роли в задачах", homePage => CreateNewRoleInTasks(homePage)));
            return caseCollection;
        }
        void CreateNewRoleInTasks(PortalHomePage homePage)
        {
            var textNameRole = new Bitrix24Role { NameRole = "Супер Исполнитель " + HelperMethods.GetDateTimeSaltString() };

            var tasksPage = homePage
                .LeftMenu
                //открыть Задачи
                .OpenTasks()
                //открыть вкладку "Еще"
                .OpenOther()
                //перейти в Права доступа
                .OpenAccessRights()
                //создать роль
                .CreateNewRole(textNameRole)
                //настроить права/ограничения
                .SettingConfigPermissions()
                //закрыть страницу права доступа
                .CloseAccessRights();
            //обновить страницу
            WebDriverActions.Refresh();
            //проверить наличие созданной роли
            var accessRightsPage = tasksPage
                .OpenOther()
                .OpenAccessRights();
            accessRightsPage.AssertRole(textNameRole);
            accessRightsPage.AssertAccessRights(textNameRole);
        }
    }
}
