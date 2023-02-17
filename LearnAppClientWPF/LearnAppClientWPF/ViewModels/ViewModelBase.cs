using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LearnAppClientWPF.ViewModels
{
	// musi być publiczna klasa
	public class ViewModelBase : ObservableRecipient, INotifyPropertyChanged // 1 musi po tym dziedziczyć viewmodel 2 implementujemy interfejs, on infromuje gui że coś się zmieniło i trzeba zaktualizować widok
	{
		// jeśli potrzebujemy klasy wspólne dla wszystkich modeli, to tutaj
	}
}
