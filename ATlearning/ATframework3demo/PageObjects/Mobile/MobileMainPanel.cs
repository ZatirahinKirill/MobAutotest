using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.Mobile
{
    /// <summary>
    /// Главная панель приложения
    /// </summary>
    public class MobileMainPanel
    {
        public MobileTasksListPage SelectTasks()
        {
            var tasksTab = new MobileItem("//android.widget.TextView[@resource-id=\"com.bitrix24.android:id/bb_bottom_bar_title\" and @text=\"Tasks\"]",
                "Таб 'Задачи'");
            tasksTab.Click();

            return new MobileTasksListPage();
        }

        public MobileMorePage SelectMore()
        {
            var moreTab = new MobileItem("//android.widget.FrameLayout[@content-desc=\"bottombar_tab_more_counter_2\"]",
                "доп меню");
            moreTab.Click();
            return new MobileMorePage();
        }
    }
}