using fishing_tool.Core.ViewModel;

namespace fishing_tool
{
    public class ViewModelLocator
    {
        public ViewModelLocator() { }
        public static ViewModelLocator Current { get; } = new();
 
        public MainViewModel MainViewModel => Ioc.Resolve<MainViewModel>();
        public HelpViewModel HelpViewModel => Ioc.Resolve<HelpViewModel>();
        public FirstViewModel FirstViewModel => Ioc.Resolve<FirstViewModel>();
    }
}
