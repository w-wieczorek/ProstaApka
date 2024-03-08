using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProstaApka.Models;

namespace ProstaApka.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public ObservableCollection<Osoba> MyAnswerList { get; }

    [RelayCommand]
    public async Task AddCommand1()
    {
        await AddCommand(1);
    }

    [RelayCommand]
    public async Task AddCommand2()
    {
        await AddCommand(2);
    }

    [RelayCommand]
    public async Task AddCommand3()
    {
        await AddCommand(3);
    }

    private async Task AddCommand(int type)
    {
        List<Osoba> answer = await DataAccess.FindPersons(type);
        MyAnswerList.Clear();
        answer.ForEach((person) => MyAnswerList.Add(person)); 
    }
}
