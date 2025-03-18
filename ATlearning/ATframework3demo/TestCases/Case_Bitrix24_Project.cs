using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.BaseFramework;
using ATframework3demo.BaseFramework.BitrixCPinterraction;
using ATframework3demo.PageObjects.Groups;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_Project : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание проекта + поста в ленту проекта", homePage => CreateProjectAndPost(homePage)));
            return caseCollection;
        }
        void CreateProjectAndPost(PortalHomePage homePage)
        {
            var textNewsPost = new Bitrix24Project { NewsPost = "Message" + HelperMethods.GetDateTimeSaltString() };
            var textNameProject = new Bitrix24Project { NameProject = "Project" + HelperMethods.GetDateTimeSaltString() };
            textNameProject.ProjectDescription = "Description" + HelperMethods.GetDateTimeSaltString();
            //добавить пользователя

            var projectPage = homePage
                .LeftMenu
                //перейти в Группы
                .OpenGroups()
                //перейти в создание проекта
                .CreateProject()
                //выбрать тип
                .ChooseType()
                //заполнить поля о проекте
                .SetNameProject(textNameProject)
                //выбрать уровень конфиденциальности
                .ChoosePrivacy()
                //заполнить поля участников
                .SetNameParticipants()
                //перейти на странице проекта в создание поста
                .CreatePost()
                //написать пост в ленте проекта
                .AddText(textNewsPost)
                //отправить пост
                .SendPost();
            //обновить страницу
            WebDriverActions.Refresh();
            //проверить наличие проекта
            var groupPage = projectPage
                .OpenGroups()
                //открываем созданный проект
                .OpenProject(textNameProject)
                //проверить наличие поста в ленте проекта
                .AssertPost(textNewsPost);
        }
    }
}
