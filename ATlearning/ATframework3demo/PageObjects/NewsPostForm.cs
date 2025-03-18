using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Форма добавления нового сообщения в новости
    /// </summary>
    public class NewsPostForm
    {
        public NewsPostForm(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public bool IsRecipientPresent(string recipientName)
        {
            //проверить наличие шильдика
            var recipientsArea = new WebItem("//div[@id='entity-selector-oPostFormLHE_blogPostForm']//div[@class='ui-tag-selector-items']",
                "Область получателей поста");
            bool isRecipientPresent = Waiters.WaitForCondition(() => recipientsArea.AssertTextContains(recipientName, default, Driver), 2, 6,
                $"Ожидание появления строки '{recipientName}' в '{recipientsArea.Description}'");
            return isRecipientPresent;
        }

        public NewsPostForm AddText(Bitrix24Comments textNewsPost)
        {
            var massageFrame = new WebItem("//iframe[@class='bx-editor-iframe']", "Фрейм ввода сообщения");
            massageFrame.SwitchToFrame();
            var fieldInputMassage = new WebItem("//body[@contenteditable='true']", "Поле ввода сообщения");
            fieldInputMassage.SendKeys(textNewsPost.NewsPost);
            WebDriverActions.SwitchToDefaultContent(); 
            return new NewsPostForm();
        }

        public PortalHomePage SendPost()
        {
            var btnSendPost = new WebItem("//span[@class='ui-btn ui-btn-lg ui-btn-primary']", "Кнопка отправки сообщения");
            btnSendPost.Click();
            return new PortalHomePage();
        }

    }
}
