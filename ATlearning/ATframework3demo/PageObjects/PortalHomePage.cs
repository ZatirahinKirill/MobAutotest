using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    public class PortalHomePage
    {
        public IWebDriver Driver { get; }

        public PortalHomePage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public PortalLeftMenu LeftMenu => new PortalLeftMenu(Driver);

        public NewsPostForm ClickPost()
        {
            var btnNewMassage = new WebItem("//div[@id='microoPostFormLHE_blogPostForm_inner']", "Кнопка создания нового сообщения");
            btnNewMassage.Click();
            return new NewsPostForm();
        }

        public CommentsForm ClickComment(Bitrix24Comments textNewsPost)
        {
            var btnNewComment = new WebItem($"//div[contains(@id,'record-BLOG')]/../div[@class='feed-com-footer']/div/a", "Кнопка создания комментария");
            btnNewComment.Click();
            return new CommentsForm();
        }

        public bool AssertPost(Bitrix24Comments textNewsPost)
        {
            return new WebItem($"//div[@class='feed-post-text'][text()='{textNewsPost.NewsPost}']", "Текст сообщения")
                .AssertTextContains(textNewsPost.NewsPost, "Пост в ленте не появился");
        }

        public bool AssertComment(Bitrix24Comments textComment)
        {
            return new WebItem("//div[@class='feed-com-text-inner-inner']/div[text()='Комментарий']", "Текст комментария")
                .AssertTextContains(textComment.Comment, "Комментарий под постом не появился");
        }
    }
}
