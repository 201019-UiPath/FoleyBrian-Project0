using System;
using AdminUI.Menu;

namespace AdminUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu startMenu = new AdminWizardMenu();
            startMenu.Start();
        }
    }
}
