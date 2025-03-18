
using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.Groups
{
    public class ProjectPage
    {
        public ProjectNewsPostForm CreatePost()
        {
            var pageProjectFrame = new WebItem("//div[@class='side-panel-content-container bitrix24-group-slider-content']" +
                "/iframe[@class='side-panel-iframe']", "Фрейм страницы проекта");
            pageProjectFrame.SwitchToFrame();
            var btnPostCreate = new WebItem("//div[@id='microoPostFormLHE_blogPostForm_inner']", "Область в Ленте 'Написать сообщение'");
            btnPostCreate.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new ProjectNewsPostForm();
        }

        public bool AssertPost(Bitrix24Project textNewsPost)
        {
            var pageProjectFrame = new WebItem("//div[@class='side-panel-content-container bitrix24-group-slider-content']" +
                "/iframe[@class='side-panel-iframe']", "Фрейм страницы проекта");
            pageProjectFrame.SwitchToFrame();
            var assertText = new WebItem($"//div[@class='feed-post-text'][text()='{textNewsPost.NewsPost}']", "Текст сообщения")
                .AssertTextContains(textNewsPost.NewsPost, "Пост в ленте проекта не появился");
            WebDriverActions.SwitchToDefaultContent();
            return assertText;
        }

        public GroupsPage OpenGroups()
        {
            var btnGroups = new WebItem("//li[@id='bx_left_menu_menu_all_groups']", "Пункт левого меню Группы");
            btnGroups.Click();
            return new GroupsPage();
        }
    }
}
