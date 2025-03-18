using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.Groups;
using OpenQA.Selenium;

namespace atFrameWork2.PageObjects
{
    public class TasksListPage
    {
        public TasksListPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public TasksListPage OpenOther()
        {
            var btnOther = new WebItem("//div[@id='tasks_panel_menu_more_button']/span", "Кнопка 'Еще' на странице Задачи");
            btnOther.Hover();
            return new TasksListPage();
        }

        public AccessRightsPage OpenAccessRights()
        {
            var btnConfigPermission = new WebItem("//span[@onclick='BX.Tasks.Component.TopMenu.getInstance(\"topmenu\").showConfigPermissions();']", "Кнопка 'Права доступа' на странице Задачи");
            btnConfigPermission.Click();
            return new AccessRightsPage();
        }
    }
}