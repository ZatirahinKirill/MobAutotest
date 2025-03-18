
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.Groups
{
    public class ProjectNewsPostForm
    {
        public ProjectNewsPostForm AddText(Bitrix24Project textNewsPost)
        {
            var pageProjectFrame = new WebItem("//div[@class='side-panel-content-container bitrix24-group-slider-content']" +
                "/iframe[@class='side-panel-iframe']", "Фрейм страницы проекта");
            pageProjectFrame.SwitchToFrame();
            var massageFrame = new WebItem("//iframe[@class='bx-editor-iframe']", "Фрейм ввода сообщения");
            massageFrame.SwitchToFrame();
            var fieldInputMassage = new WebItem("//body[@contenteditable='true']", "Поле ввода сообщения");
            fieldInputMassage.SendKeys(textNewsPost.NewsPost);
            WebDriverActions.SwitchToDefaultContent();
            return new ProjectNewsPostForm();
        }

        public ProjectPage SendPost()
        {
            var pageProjectFrame = new WebItem("//div[@class='side-panel-content-container bitrix24-group-slider-content']" +
                "/iframe[@class='side-panel-iframe']", "Фрейм страницы проекта");
            pageProjectFrame.SwitchToFrame();
            var btnSendPost = new WebItem("//span[@id='blog-submit-button-save']", "Кнопка отправки сообщения");
            btnSendPost.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new ProjectPage();
        }
    }
}
