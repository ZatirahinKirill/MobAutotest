
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.Groups
{
    public class CreateProjectPage
    {
        public CreateProjectPage ChooseType()
        {
            var createProjectFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм создания проекта");
            createProjectFrame.SwitchToFrame();
            var typeProject = new WebItem("//div[@data-bx-project-type='project']", "Выбор тип 'Проект'");
            typeProject.Click();
            var btnContinue = new WebItem("//button[@id='sonet_group_create_popup_form_button_submit']", "Кнопка Продолжить после выбора типа");
            btnContinue.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new CreateProjectPage();
        }

        public CreateProjectPage SetNameProject(Bitrix24Project textNameProject)
        {
            var createProjectFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм создания проекта");
            createProjectFrame.SwitchToFrame();
            var inputGroupName = new WebItem("//input[@id='GROUP_NAME_input']", "Ввод названия проекта");
            inputGroupName.SendKeys(textNameProject.NameProject);
            var addDescription = new WebItem("//div[@data-sonet-control-id='add-description']", "Добавить описание проекта");
            addDescription.Click();
            var inputProjectDescription = new WebItem("//textarea[@id='GROUP_DESCRIPTION_input']", "Поле ввода описания проекта");
            inputProjectDescription.SendKeys(textNameProject.ProjectDescription);
            var btnContinue = new WebItem("//button[@id='sonet_group_create_popup_form_button_submit']/span", "Кнопка Продолжить после описания проекта");
            btnContinue.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new CreateProjectPage();
        }

        public CreateProjectPage ChoosePrivacy()
        {
            var createProjectFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм создания проекта");
            createProjectFrame.SwitchToFrame();
            var typeConfidentiality = new WebItem("//div[@data-bx-confidentiality-type='closed']", "Тип конфиденциальности 'Закрытый'");
            typeConfidentiality.Click();
            var btnContinue = new WebItem("//button[@id='sonet_group_create_popup_form_button_submit']/span", "Кнопка Продолжить после выбора типа конфиденциальности");
            btnContinue.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new CreateProjectPage();
        }

        public ProjectPage SetNameParticipants()
        {
            var createProjectFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм создания проекта");
            createProjectFrame.SwitchToFrame();
            var btnContinue = new WebItem("//button[@id='sonet_group_create_popup_form_button_submit']/span", "Кнопка Продолжить после настройки участников");
            btnContinue.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new ProjectPage();
        }
    }
}
