using CarAgency.UI;

namespace CarAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new AgencyUI();
            while(true)
            {
                ui.ShowCrudMenu();
                ui.GetUserInput();
            }
        }
    }
}