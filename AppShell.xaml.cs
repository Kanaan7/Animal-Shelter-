using Microsoft.Maui.Controls;

namespace Assignment2._1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("EditAnimalPage", typeof(EditAnimalPage));
        }
    }
}
