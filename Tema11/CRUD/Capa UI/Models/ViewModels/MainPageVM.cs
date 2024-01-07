using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Capa_UI.Models.ViewModels
{
    public class MainPageVM
    {

        public ICommand navPagInicio => new Command(
            async () => await Navigation.PushAsync(new PagInicio()
          ));

    }
}
