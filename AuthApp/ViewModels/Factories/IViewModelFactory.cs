using AuthApp.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.ViewModels.Factories
{
    public interface IViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
