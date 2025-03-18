
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.Groups
{
    public class GroupsPage
    {
        public CreateProjectPage CreateProject()
        {
            var btnCreate = new WebItem("//a[@id='projectAddButton']", "Кнопка 'Создать' на странице Группы");
            btnCreate.Click();
            return new CreateProjectPage();
        }

        public ProjectPage OpenProject(Bitrix24Project textNameProject)
        {
            var btnOpenProject = new WebItem($"//a[@class='sonet-group-grid-name-text'][text()='{textNameProject.NameProject}']", 
                $"Открыть страницу проекта '{textNameProject.NameProject}'");
            btnOpenProject.Click();
            return new ProjectPage();
        }
    }
}
