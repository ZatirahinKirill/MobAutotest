using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using ATframework3demo.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ATframework3demo.TestEntities;
using ATframework3demo.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_Comments : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание комментария от другого юзера под постом в ленте", homePage => CreateComments(homePage)));
            return caseCollection;
        }

        void CreateComments (PortalHomePage homePage)
        {
            var textNewsPost = new Bitrix24Comments { NewsPost = "Message" + HelperMethods.GetDateTimeSaltString()};
            var textComment = new Bitrix24Comments { Comment = "Comment" + HelperMethods.GetDateTimeSaltString()};

            var newUser = TestCase.RunningTestCase.CreatePortalTestUser(false);

            //зайти первым пользователем
            homePage
            //зайти в создание сообщения
                .ClickPost()
            //ввести сообщение
                .AddText(textNewsPost)
            //отправить
                .SendPost()
            //проверить пост в ленте
                .AssertPost(textNewsPost);

            //зайти вторым пользователем
            WebItem.DefaultDriver.Quit();
            WebItem.DefaultDriver = default;
            new PortalLoginPage(TestCase.RunningTestCase.TestPortal)
                .Login(newUser)
            //Добавить комментарий
                .ClickComment(textNewsPost)
            //ввести текст
                .AddText(textComment)
            //отправить
                .SendComment()
            //проверить комментарий под постом
                .AssertComment(textComment);
        }
    }
}
