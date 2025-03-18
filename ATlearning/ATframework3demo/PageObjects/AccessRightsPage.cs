
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects
{
    public class AccessRightsPage
    {
        public TasksListPage CloseAccessRights()
        {
            var btnClose = new WebItem("//div[@class='side-panel-label-icon-box']/div", "Кнопка 'Закрыть' станицу Права доступа");
            btnClose.Hover();
            btnClose.Click();
            return new TasksListPage();
        }

        public AccessRightsPage CreateNewRole(Bitrix24Role textNameRole)
        {
            var pageAccessRightsFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм страницы Права доступа");
            pageAccessRightsFrame.SwitchToFrame();
            var btnCreateRole = new WebItem("//div[@class='ui-access-rights-column-item-controller-link'][text()='Создать роль']", "Кнопка 'Создать роль'");
            btnCreateRole.Click();
            var inputNameRole = new WebItem("//div[@class='ui-access-rights-role ui-access-rights-role-edit-mode']/input[@class='ui-access-rights-role-input']", "Ввод названия роли");
            inputNameRole.SendKeys(textNameRole.NameRole);
            WebDriverActions.SwitchToDefaultContent();
            return new AccessRightsPage();
        }

        public AccessRightsPage SettingConfigPermissions()
        {
            var pageAccessRightsFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм страницы Права доступа");
            pageAccessRightsFrame.SwitchToFrame();
            var btnSwitcher = new WebItem("//div[@class='ui-access-rights-section-title']", "Кнопка переключения для настройки прав");
            for (int i = 1; i < 7; i++)
            {
                btnSwitcher = new WebItem("//div[@class='ui-access-rights-section-title'][text()='Задачи']/.." +
                $"/div[2]/div[2]/div/div[last()]/div[{i}]/a" +
                "/span[@class='ui-switcher-size-sm ui-switcher ui-switcher-off']", $"Кнопка переключения для настройки прав #{i}");
                btnSwitcher.Click();
            }
            var btnSave = new WebItem("//button[@id='ui-button-panel-save']", "Кнопка 'Сохранить'");
            btnSave.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new AccessRightsPage();
        }

        public bool AssertRole(Bitrix24Role textNameRole)
        {
            var pageAccessRightsFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм страницы Права доступа");
            pageAccessRightsFrame.SwitchToFrame();
            var cursor = new WebItem("//div[@class='ui-access-rights-section-title'][text()='Задачи']/" +
                "../div[2]/div[2]/div/div[4]/div[1]/a/span[@class='ui-switcher-size-sm ui-switcher']", "Наведение курсора");
            cursor.Hover();
            var assertRole = new WebItem($"//div[@class = 'ui-access-rights-role-value'][text()='{textNameRole.NameRole}']", "название роли")
                .AssertTextContains(textNameRole.NameRole, "Роль не была создана");
            WebDriverActions.SwitchToDefaultContent();
            return assertRole;
        }

        public bool AssertAccessRights(Bitrix24Role textNameRole)
        {
            var pageAccessRightsFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм страницы Права доступа");
            pageAccessRightsFrame.SwitchToFrame();
            var btnSwitcher = new WebItem("//div[@class='ui-access-rights-section-title']", "Кнопка переключения для настройки прав");
            for (int i = 1; i < 7; i++)
            {
                btnSwitcher = new WebItem("//div[@class='ui-access-rights-section-title'][text()='Задачи']/.." +
                $"/div[2]/div[2]/div/div[last()]/div[{i}]/a" +
                "/span[@class='ui-switcher-size-sm ui-switcher']", $"Кнопка переключения для настройки прав #{i}");
                if (!btnSwitcher.WaitElementDisplayed())
                {
                    throw new Exception($"Не найдены права номер {i} роли {textNameRole.NameRole}");
                }
            }
            WebDriverActions.SwitchToDefaultContent();
            var assertSwitcher = btnSwitcher.WaitElementDisplayed();
            return assertSwitcher;
        }
    }
}
