
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class CommentsForm
    {
        public IWebDriver Driver { get; }

        public CommentsForm(IWebDriver driver = default)
        {
            Driver = driver;
        }
        public CommentsForm AddText(Bitrix24Comments textComment)
        {
            var commentFrame = new WebItem("//iframe[@class='bx-editor-iframe']", "Фрейм ввода комментария");
            commentFrame.SwitchToFrame();
            var fieldInputComment = new WebItem("//body[@contenteditable='true']", "Поле ввода комментария");
            fieldInputComment.SendKeys(textComment.Comment);
            WebDriverActions.SwitchToDefaultContent();
            return new CommentsForm();
        }

        public PortalHomePage SendComment()
        {
            var btnSendComment = new WebItem("//button[@class='ui-btn ui-btn-sm ui-btn-primary'][starts-with(@id,'lhe_button_submit_blogCommentForm')]", "Кнопка отправки комментария");
            btnSendComment.Click();
            return new PortalHomePage();
        }
    }
}
